namespace NTDShop.Data.Migrations
{
    using Model.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NTDShop.Data.NTDShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NTDShop.Data.NTDShopDbContext context)
        {
            CreateProductCategorySample(context);
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new NTDShopDbContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new NTDShopDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "tedu",
            //    Email = "tedu.international@gmail.com",
            //    EmailConfirmed = true,
            //    BirthDay = DateTime.Now,
            //    FullName = "Technology Education"

            //};

            //manager.Create(user, "123654$");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("tedu.international@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateProductCategorySample(NTDShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> newListProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() {Name="Điện Thoại",Alias="dien-thoai",Status=true },
                new ProductCategory() {Name="Laptop",Alias="laptop",Status=true },
                new ProductCategory() {Name="Đồ Gia Dụng",Alias="do-gia-dung",Status=true },
                new ProductCategory() {Name="Mỹ Phẩm",Alias="my-pham",Status=true },
                new ProductCategory() {Name="Thời Trang",Alias="thoi-trang",Status=true },
            };
                context.ProductCategories.AddRange(newListProductCategory);
                context.SaveChanges();
            }
        }
    }
}