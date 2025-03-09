using ASP_Project_Core.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.Interfaces
{
    public  interface ICartRepository
    {

        Task<string> AddBulkQuantityToCartAsync(CartItemDto dto, int userId);
        Task<string> AddOneQuantityToCartAsync(CartItemDto dto, int userId);
        Task<string> DeleteOneQuantityToCartAsync(CartItemDto dto, int userId);
        Task<IEnumerable<UserCartItemDto>> GetAllItemsFromCart(int customerId);

    }
}
