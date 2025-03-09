using ASP_Project_Core.DTO_s;
using ASP_Project_Core.DTO_s;
using ASP_Project_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.Interfaces
{
    public interface IItemRepository
    {
        Task<PagedRespones<ItemDto>> GetItemsAsync(int page_index, int page_size);

       Task<PagedRespones<ItemDto>> PaginationAsync(IQueryable<ItemDto> query , int page_index , int page_size);
        Task<AddItems> AddItems(AddItems items);

        Task<string> DeleteItems(int itemId);

        Task<UpdateDto> UpdateItem(UpdateDto dto , int itemId);
    }
}
