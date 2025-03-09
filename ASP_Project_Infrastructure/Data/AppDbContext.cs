using ASP_Project_Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Project_Infrastructure.Data
{
    public class AppDbContext :IdentityDbContext<Users,IdentityRole<int>,int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
            builder.Entity<ItemsUnits>().HasKey(i => new { i.Unit_Id, i.Item_Id }); //primary key لعمل كومبوست 
            builder.Entity<CustomersStores>().HasKey(a => new { a.Store_Id, a.Cus_Id });
            builder.Entity<InvItemStore>().HasKey(e => new { e.Store_Id, e.Item_Id });
            builder.Entity<ShoppingCartItems>().HasKey(e => new { e.Store_Id, e.Item_Id,e.Cus_Id });
            builder.Entity<InvoiceDetails>().HasKey(e => new { e.Invoice_Id, e.Item_Id });




            // جدول المحافظات
            builder.Entity<Goverments>().HasData(
                 new Goverments { Id = 1, Name = "القاهرة" },
                 new Goverments { Id = 2, Name = "الإسكندرية" }
            );

            // جدول المدن
            builder.Entity<Cities>().HasData(
                 new Cities { Id = 1, Name = "مدينة نصر", Gov_Id = 1 },
                 new Cities { Id = 2, Name = "المعادي", Gov_Id = 1 },
                 new Cities { Id = 3, Name = "سموحة", Gov_Id = 2 }
            );

            // جدول الأحياء (المناطق)
            builder.Entity<Zones>().HasData(
                 new Zones { Id = 1, Name = "الحي الأول", Gov_Id = 1, City_Id = 1 },
                 new Zones { Id = 2, Name = "الحي الثاني", Gov_Id = 1, City_Id = 2 },
                 new Zones { Id = 3, Name = "حي المعمورة", Gov_Id = 2, City_Id = 3 }
            );

            // جدول التصنيفات الرئيسية (الفئات الرئيسية)
            builder.Entity<MainGroup>().HasData(
                 new MainGroup { Id = 1, Name = "الأغذية" },
                 new MainGroup { Id = 2, Name = "الإلكترونيات" }
            );

            // جدول الفئات الفرعية المستوى الأول
            builder.Entity<SubGroup>().HasData(
                 new SubGroup { Id = 1, Name = "الحليب والمنتجات", MG_Id = 1 },
                 new SubGroup { Id = 2, Name = "الهواتف", MG_Id = 2 }
            );

            // جدول الفئات الفرعية المستوى الثاني
            builder.Entity<SubGroup2>().HasData(
                 new SubGroup2 { Id = 1, Name = "حليب كامل الدسم", Sub_Id = 1, MG_Id = 1 },
                 new SubGroup2 { Id = 2, Name = "هواتف ذكية", Sub_Id = 2, MG_Id = 2 }
            );

            // جدول تصنيفات المستخدمين (مثل سوبرماركت، مطعم، منزل …)
            builder.Entity<Classifications>().HasData(
                 new Classifications { Id = 1, Name = "سوبرماركت" },
                 new Classifications { Id = 2, Name = "مطعم" },
                 new Classifications { Id = 3, Name = "منزل" }
            );

            // جدول المستخدمين (ملاحظة: بيانات الهوية تحتاج إعدادات إضافية)


            // جدول الأصناف
            builder.Entity<Items>().HasData(
                 new Items
                 {
                     Id = 1,
                     Name = "حليب كامل الدسم",
                     Description = "حليب عالي الجودة",
                     Price = 20.0,
                     MG_Id = 1,
                     Sub_Id = 1,
                     Sub2_Id = 1
                 },
                 new Items
                 {
                     Id = 2,
                     Name = "آيفون 13",
                     Description = "هاتف ذكي عالي الجودة",
                     Price = 15000.0,
                     MG_Id = 2,
                     Sub_Id = 2,
                     Sub2_Id = 2
                 }
            );

            // جدول المتاجر
            builder.Entity<Stores>().HasData(
                 new Stores { Id = 1, Name = "سوبرماركت الزمالك", Gov_Id = 1, City_Id = 1, Zone_Id = 1 },
                 new Stores { Id = 2, Name = "متجر الإسكندرية", Gov_Id = 2, City_Id = 3, Zone_Id = 3 }
            );

            // جدول الوحدات
            builder.Entity<Units>().HasData(
                 new Units { Id = 1, Name = "علبة" },
                 new Units { Id = 2, Name = "قطعة" },
                 new Units { Id = 3, Name = "كيلو" }
            );

            // جدول ItemsUnits (علاقة متعدد لمتعدد بين الأصناف والوحدات)
            builder.Entity<ItemsUnits>().HasData(
                 new ItemsUnits { Item_Id = 1, Unit_Id = 1, Factor = 1 },
                 new ItemsUnits { Item_Id = 2, Unit_Id = 2, Factor = 1 }
            );

            // جدول InvItemStore (علاقة متعدد لمتعدد بين الأصناف والمتاجر)
            builder.Entity<InvItemStore>().HasData(
                 new InvItemStore
                 {
                     Store_Id = 1,
                     Item_Id = 1,
                     Balance = 100,
                     ReservedQuantity = 0,
                     Factor = 1,
                     LastUpdated = DateTime.Now
                 },
                 new InvItemStore
                 {
                     Store_Id = 2,
                     Item_Id = 2,
                     Balance = 50,
                     ReservedQuantity = 0,
                     Factor = 1,
                     LastUpdated = DateTime.Now
                 }
            );

            // جدول الفواتير
           

            // جدول تفاصيل الفواتير
           

            // جدول عناصر عربة التسوق
           









        }

      
        public DbSet<Users> Users { get; set; }
        public DbSet<Cities> Cities { get; set; }

        public DbSet<Goverments> Goverments { get; set; }
        public DbSet<Zones> Zones { get; set; }
        public DbSet<Classifications> Classifications { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<MainGroup> MainGroups { get; set; }
        public DbSet<SubGroup> SubGroups { get; set; }
        public DbSet<SubGroup2> subGroups2 { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceDetails> invoiceDetails { get; set; }
        public DbSet<ShoppingCartItems> ShoppingCartItems { get; set; }
        public DbSet<InvItemStore> invItemStores { get; set; }
        public DbSet<ItemsUnits> ItemsUnits { get; set; }
        public DbSet<CustomersStores> CustomersStores { get; set; }
        public DbSet<Stores> Stores { get; set; }

















    }
}
