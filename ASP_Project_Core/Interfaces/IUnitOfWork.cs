using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthRepository AuthRepository { get; }
        ICartRepository CartRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IItemRepository ItemRepository { get; }
        Task<int> SaveAsync();
    }
}
