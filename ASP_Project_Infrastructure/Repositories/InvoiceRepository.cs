using ASP_Project_Core.DTO_s;
using ASP_Project_Core.Interfaces;
using ASP_Project_Core.Models;
using ASP_Project_Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext appDbContext;

        public InvoiceRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<string> CreateInvoiceAsync(int customerId)
        {
           var cartItems= await appDbContext.ShoppingCartItems
                .Include(a=>a.Items)
                .Where(a=>a.Cus_Id==customerId)
                .ToListAsync();

            if (cartItems==null || !cartItems.Any())
            {
                return "no items in the cart to create invoice";
            }
            var unavailabelItems = new List<string>();
            double TotalNetPrice = 0;
            foreach (var item in cartItems)
            {
                var itemStore = appDbContext.invItemStores
                    .FirstOrDefault(i => i.Item_Id == item.Item_Id && i.Store_Id == item.Store_Id);
                if (itemStore == null)
                {
                    unavailabelItems.Add(item.Items.Name);
                    continue;

                }

                double availabelQuantity = itemStore.Balance - itemStore.ReservedQuantity;
                if (item.Quantity > availabelQuantity)
                {
                    unavailabelItems.Add(item.Items.Name);
                    continue;

                }
            }

            var unavailabelitemcount= unavailabelItems.Count();
            var numberofCartItems= cartItems.Count();
            if (unavailabelitemcount == numberofCartItems)
            {
                return "All items in cart are unavailabel :(";
            }

            var invoice = new Invoice
            {
                Cus_Id = customerId,
                CreatedAt = DateTime.Now,
                NetPrice = 0,
                Transaction_Types = 1,
                Payment_Type = 1,
                IsPosted = true,
                IsClosed = false,
                IsReviewed = false

            };

            await appDbContext.Invoice.AddAsync(invoice);
            await appDbContext.SaveChangesAsync();
            

            foreach (var item in cartItems) 
            {
                var itemStore = appDbContext.invItemStores
                    .FirstOrDefault(i => i.Item_Id == item.Item_Id && i.Store_Id == item.Store_Id);

                double unitPrice = item.Items.Price;
                double ItemTotalPrice = item.Quantity * unitPrice;
                TotalNetPrice += ItemTotalPrice;

                var invoiceDetails = new InvoiceDetails
                {
                    Invoice_Id = invoice.Id,
                    Item_Id = item.Item_Id,
                    Quantity = item.Quantity,
                    Factor = 1,
                    Price=(int)unitPrice,
                    Unit_Id=item.Unit_Id,
                    CreatedAt = DateTime.Now


                };
                appDbContext.invoiceDetails.Add(invoiceDetails);
                itemStore.ReservedQuantity += item.Quantity;
                appDbContext.invItemStores.Update(itemStore);

            }

            invoice.NetPrice = TotalNetPrice;
            appDbContext.ShoppingCartItems.RemoveRange(
                cartItems.Where(i=> !unavailabelItems.Contains(i.Items.Name))
                );
               await appDbContext.SaveChangesAsync();
            if (unavailabelItems.Any())
            {
                var unavialabelItemsMassage = string.Join(", ", unavailabelItems.Select(item =>
                {
                    var cartItem = cartItems.FirstOrDefault(i=>i.Items.Name==item);
                    if (cartItem !=null)
                    {
                        var itemStore = appDbContext.invItemStores.FirstOrDefault(i=>i.Item_Id==cartItem.Item_Id);
                        if (itemStore != null)
                        {
                            double availabelQuantity = itemStore.Balance - itemStore.ReservedQuantity;
                            return $"{item} (Available Quantity = {availabelQuantity})";

                        }
                    }
                    return item;

                    
                }));
                return $"Invoice created successfully with ID: {invoice.Id} and total price : {TotalNetPrice},However the following items were unavailabel {unavialabelItemsMassage}";
            }

            return $"Invoice created successfully with ID: {invoice.Id} and total price : {TotalNetPrice} ";


        }

        public async Task<InvoiceRecieptDto> GetInvoiceReciept(int customerId, int invoiceId)
        {
            var invoice = await appDbContext.Invoice
                                .Include(i => i.invoiceDetails)
                                .ThenInclude(a => a.Items)
                                .FirstOrDefaultAsync(x=>x.Cus_Id == customerId && x.Id == invoiceId);
            if (invoice == null)
            {
                return null;
            }

            double total_price = 0;
            foreach (var item in invoice.invoiceDetails)
            {
                double item_price = item.Price * item.Quantity; 
                total_price+=item_price;

            }

            invoice.NetPrice = total_price;
            await appDbContext.SaveChangesAsync();

            var reciept = new InvoiceRecieptDto
            {
                invoice_id = invoiceId,
                customer_id = customerId,
                created_at = invoice.CreatedAt,
                total_price = total_price,
                items = invoice.invoiceDetails.Select(x => new InvoiceItemDto
                {
                    item_name = x.Items.Name,
                    quantity = x.Quantity,
                    unit_name = appDbContext.Units.FirstOrDefault(a => a.Id == x.Unit_Id)?.Name ?? "UnKnown",
                    price_per_unit = x.Price,
                    total_price = x.Price * x.Quantity


                }).ToList()

            };
            return reciept;
        }
    }
}
