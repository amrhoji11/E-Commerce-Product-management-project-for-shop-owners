
using ASP_Project_Core.Interfaces;
using ASP_Project_Core.Models;
using ASP_Project_Infrastructure.Data;
using ASP_Project_Infrastructure.Repositories;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASP_Project_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddIdentity<Users, IdentityRole<int>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 1;
            })
                .AddRoles<IdentityRole<int>>()
                .AddEntityFrameworkStores<AppDbContext>();//والامبلمنتيشن تاعتو فلازم اكتب هاذ الكود عشان يتفعلن جواتو interface  هاذ جواتو في  CreateAsync هون مثلا عنا الميثود ال 
            /*builder.Services.AddScoped<IAuthRepository, AuthRepository>();*///AuthRepository والامبلمنتيشن تاعتها IAuthRepository عشان اقدر افعل ال
            /*builder.Services.AddScoped<IItemRepository, ItemReopsitory>();
            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();*/
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<RoleManager<IdentityRole<int>>>();

            var config = TypeAdapterConfig.GlobalSettings; //هيك بقدر يستخدم برا كلاسه TypeAdapterConfig معناها انو متغير اللي نوعو  
            builder.Services.AddSingleton(config); //غالبا ما بتتغير فليس هناك حاجة ان اعرف اوبجكت جديد  config لانو هو الوحيد اللي بعرف الاوبجكت مرة واحد طوال فترة حياتو لان ال AddSinglton اخترنا ال
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
