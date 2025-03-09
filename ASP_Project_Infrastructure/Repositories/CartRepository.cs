using ASP_Project_Core.DTO_s;
using ASP_Project_Core.Interfaces;
using ASP_Project_Core.Models;
using ASP_Project_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext appDbContext;

        public CartRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<string> AddBulkQuantityToCartAsync(CartItemDto dto, int userId)
        {
            var items = await appDbContext.Items.FindAsync(dto.ItemCode);
            var stores = await appDbContext.Stores.FindAsync(dto.StoreId);
            if (items == null || stores == null)
            {
                return "items or store not found";
            }

            var existingItem = appDbContext.ShoppingCartItems
                .FirstOrDefault(a => a.Cus_Id == userId && a.Item_Id == dto.ItemCode && a.Store_Id == dto.StoreId);

            if (existingItem != null)
            {
                existingItem.Quantity = dto.Quantity;
                existingItem.Unit_Id = dto.UnitCode;
                existingItem.Store_Id = dto.StoreId;
                existingItem.UpdateAt = DateTime.Now;

            }
            else
            {
                var ShoppingCartItem = new ShoppingCartItems
                {
                    Cus_Id = userId,
                    Item_Id = dto.ItemCode,
                    CreateAt = DateTime.Now,
                    Quantity = dto.Quantity,
                    Unit_Id = dto.UnitCode,
                    Store_Id = dto.StoreId,
                    UpdateAt = null

                };

                await appDbContext.ShoppingCartItems.AddAsync(ShoppingCartItem);

            }

            await appDbContext.SaveChangesAsync();

            return "item added to card successfully";
        }

        public async Task<string> AddOneQuantityToCartAsync(CartItemDto dto, int userId)
        {
            var item = await appDbContext.Items.FindAsync(dto.ItemCode);
            var store = await appDbContext.Stores.FindAsync(dto.StoreId);
            if (item == null || store==null)
            {
                return "item or store are not found";

            }

            var existingItem = await appDbContext.ShoppingCartItems.FirstOrDefaultAsync( a=>a.Cus_Id==userId && a.Item_Id==dto.ItemCode && a.Store_Id==dto.StoreId);
            if (existingItem != null) 
            {
                existingItem.Quantity += 1;
                existingItem.UpdateAt=DateTime.Now;
           
            
            }
            else
            {
                var ShoppingCartItem = new ShoppingCartItems
                {
                    Cus_Id = userId,
                    Item_Id = dto.ItemCode,
                    Store_Id = dto.StoreId,
                    Unit_Id = dto.UnitCode,
                    CreateAt = DateTime.Now,
                    UpdateAt = null,
                    Quantity = 1
                };

               await appDbContext.ShoppingCartItems.AddAsync(ShoppingCartItem);
             }
            await appDbContext.SaveChangesAsync();
            return "items added to cart successfuly";


        }

        public async Task<string> DeleteOneQuantityToCartAsync(CartItemDto dto, int userId)
        {
            var item = await appDbContext.Items.FindAsync(dto.ItemCode);
            var store = await appDbContext.Stores.FindAsync(dto.StoreId);
            if (item == null || store == null)
            {
                return "item or store are not found";

            }

            var existingItem = await appDbContext.ShoppingCartItems.FirstOrDefaultAsync(a => a.Cus_Id == userId && a.Item_Id == dto.ItemCode && a.Store_Id == dto.StoreId);
            if (existingItem != null && existingItem.Quantity>1)
            {
                existingItem.Quantity -= 1;
                existingItem.UpdateAt = DateTime.Now;


            }
            else if (existingItem != null && existingItem.Quantity == 1)
            {
                 appDbContext.ShoppingCartItems.Remove(existingItem);


            }

            else
            {
                return "items or store are not found";
            }
           
            await appDbContext.SaveChangesAsync();
            return "items remove to cart successfuly";


        }

        public async Task<IEnumerable<UserCartItemDto>> GetAllItemsFromCart(int customerId)
        {
            var cartItems = await appDbContext.ShoppingCartItems.Where(a => a.Cus_Id == customerId)
                .Include(a => a.Items)
                .Include(a => a.Items.ItemsUnits)
                .ThenInclude(a => a.Units)
                .ToListAsync();

            var itemDto = cartItems.Select(x => new UserCartItemDto
            {
                name = x.Items.Name,
                price = x.Items.Price,
                Quantity=x.Quantity,
                itemUnits = x.Items.ItemsUnits
                .Where(a => a.Unit_Id == x.Unit_Id && a.Unit_Id==x.Unit_Id)
                .Select(a => a.Units.Name).FirstOrDefault()
            }).ToList();

            return itemDto;

        }
    }
}
