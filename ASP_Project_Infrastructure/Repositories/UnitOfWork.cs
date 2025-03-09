using ASP_Project_Core.Interfaces;
using ASP_Project_Core.Models;
using ASP_Project_Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {

        private readonly AppDbContext appDbContext;
        public IAuthRepository AuthRepository { get; }

        public ICartRepository CartRepository { get; }

        public IInvoiceRepository InvoiceRepository { get; }

        public IItemRepository ItemRepository { get; }

        public UnitOfWork(AppDbContext appDbContext , UserManager<Users> userManager, SignInManager<Users> signInManager ,IConfiguration configuration, RoleManager<IdentityRole<int>> roleManager)
        {
            this.appDbContext=appDbContext;
            AuthRepository = new AuthRepository(userManager,signInManager,configuration, roleManager);
            CartRepository = new CartRepository(appDbContext);
            InvoiceRepository = new InvoiceRepository(appDbContext);
            ItemRepository = new ItemReopsitory(appDbContext);

        }

        public async Task<int> SaveAsync()
        {
           return await appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
           appDbContext.Dispose();
        }
    }
}
