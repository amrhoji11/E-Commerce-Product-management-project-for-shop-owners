using ASP_Project_Core.DTO_s;
using ASP_Project_Core.Interfaces;
using ASP_Project_Core.Mapping_Profiles;
using ASP_Project_Core.Models;
using ASP_Project_Infrastructure.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Infrastructure.Repositories
{
    public class ItemReopsitory : IItemRepository
    {
        private readonly AppDbContext appDbContext;

        public ItemReopsitory(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<AddItems> AddItems(AddItems items)
        {
            var item = new Items
            {
                Name = items.Name,
                Description = items.Description,
                Price = items.Price,
                MG_Id = items.MG_Id,
                Sub_Id = items.Sub_Id,
                Sub2_Id = items.Sub2_Id,


            };
            await appDbContext.Items.AddAsync(item);
           await appDbContext.SaveChangesAsync();
            return items;
        }

        public async Task<string> DeleteItems(int itemId)
        {
            var item = await appDbContext.Items.FirstOrDefaultAsync(a=>a.Id == itemId);
            if (item == null)
            {
                return "the item not found";
            }

             appDbContext.Items.Remove(item);
            await appDbContext.SaveChangesAsync();
            return "the item is deleted";
        }

        /*public async Task<IEnumerable<ItemDto>> GetItemsAsync()
{
   var items = await appDbContext.Items.
       Include(a => a.ItemsUnits).
       Select(x=>new ItemDto
       {
           Id = x.Id,
           Name = x.Name,
           Description = x.Description,
           Price = x.Price,
           ItemUnits=x.ItemsUnits.Select(unit=>unit.Units.Name).ToList(),
           Stores=x.InvItemStore.Select(store=>store.Stores.Name).ToList()

       }).
       ToListAsync();
   return items;
}*/


        public async Task<PagedRespones<ItemDto>> GetItemsAsync(int page_index , int page_size)
        {
            var config = Mapping_Profile.Config;

            var items =  appDbContext.Items.ProjectToType<ItemDto>(config).AsQueryable();

            var result = await PaginationAsync(items, page_index , page_size);
            return result;
            
        }

        public async Task<PagedRespones<ItemDto>> PaginationAsync(IQueryable<ItemDto> query, int page_index, int page_size)
        {
            var total_items = await query.CountAsync();
            var items = await query
                .Skip((page_index - 1) * page_size)
                .Take(page_size).ToListAsync();

            var result = new PagedRespones<ItemDto> 
            {
            total_items=total_items,
            page_index=page_index,
            page_size=page_size,
            items=items
            
            
            };
            return result;
        }

        public async Task<UpdateDto> UpdateItem(UpdateDto dto, int itemId)
        {
            var item = await appDbContext.Items.FirstOrDefaultAsync(a=>a.Id == itemId);
            if (item == null)
            {
                return null;
            }
            item.Name= dto.Name;
            item.Description= dto.Description;
            item.Price= dto.Price;
            item.MG_Id= dto.MG_Id;
            item.Sub_Id= dto.Sub_Id;
            item.Sub2_Id= dto.Sub2_Id;

             appDbContext.Items.Update(item);


            await appDbContext.SaveChangesAsync();
            
            return dto;

        }
    }
}
