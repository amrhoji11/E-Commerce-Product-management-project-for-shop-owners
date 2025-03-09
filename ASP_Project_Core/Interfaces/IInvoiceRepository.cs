using ASP_Project_Core.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Core.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<string> CreateInvoiceAsync(int customerId);
       Task<InvoiceRecieptDto> GetInvoiceReciept(int customerId,int invoiceId);

    }
}
