using Core.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Web.Models.EF
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().HasData(
                new Group()
                {
                    Id = Guid.Parse("EB6B4076-AE9A-4D83-9522-F71760BF27B4"),
                    Name = "Quản trị viên"
                }
            );
            modelBuilder.Entity<Member>().HasData(
                new Member()
                {
                    Id = Guid.Parse("98D64F50-D8CE-4C84-90CC-4131AF413F2A"),
                    Name = "Bùi Ngọc Thảo Mi",
                    Picture = "/img/users/thaomi.jpg",
                    LoginName = "bui.mi",
                    Password = "c4ca4238a0b923820dcc509a6f75849b",
                    Email = "mibn.24th@sv.dla.edu.vn",
                    CreatedOn = DateTime.Now,
                    GroupId = Guid.Parse("EB6B4076-AE9A-4D83-9522-F71760BF27B4")
                }
            );
            modelBuilder.Entity<Category>().HasData(
               new Category()
               {
                   Id = Guid.Parse("F3DADF45-7DB1-4EC9-89BC-F29EED14D099"),
                   Name = "Root",
                   CreatedBy = Guid.Parse("98D64F50-D8CE-4C84-90CC-4131AF413F2A"),
                   CreatedOn = DateTime.Now
               },
               new Category()
                {
                    Id = Guid.Parse("4D84C1F5-3DAA-439A-93CD-8B60DC29192D"),
                    Name = "Authorized",
                    CreatedBy = Guid.Parse("98D64F50-D8CE-4C84-90CC-4131AF413F2A"),
                    CreatedOn = DateTime.Now,
                    ParentId = Guid.Parse("F3DADF45-7DB1-4EC9-89BC-F29EED14D099")
               },
               new Category()
               {
                   Id = Guid.Parse("FE7F810C-72B9-44CB-AB4B-3FAF28CDC443"),
                   Name = "Nhóm quyền",
                   CreatedBy = Guid.Parse("98D64F50-D8CE-4C84-90CC-4131AF413F2A"),
                   CreatedOn = DateTime.Now,
                   ParentId = Guid.Parse("4D84C1F5-3DAA-439A-93CD-8B60DC29192D")
               },
               new Category()
               {
                    Id = Guid.Parse("348B75CD-56A7-4094-97F1-284AB85C3AB9"),
                    Name = "Article",
                    CreatedBy = Guid.Parse("98D64F50-D8CE-4C84-90CC-4131AF413F2A"),
                    CreatedOn = DateTime.Now,
                    ParentId = Guid.Parse("F3DADF45-7DB1-4EC9-89BC-F29EED14D099")
               },
               new Category()
               {
                    Id = Guid.Parse("D4F86670-A689-4CC2-90DF-0E89BA79276D"),
                    Name = "Product",
                    CreatedBy = Guid.Parse("98D64F50-D8CE-4C84-90CC-4131AF413F2A"),
                    CreatedOn = DateTime.Now,
                    ParentId = Guid.Parse("F3DADF45-7DB1-4EC9-89BC-F29EED14D099")
               }
            );
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = Guid.Parse("B643E139-B6BF-41D7-A251-AD3BD2AE5574"),
                    Name = "Xem danh sách",
                    Code = "view-groups",
                    CategoryId = Guid.Parse("FE7F810C-72B9-44CB-AB4B-3FAF28CDC443")
                },
                 new Role()
                 {
                     Id = Guid.Parse("CE1C61AC-219E-40D3-B780-9732052B4375"),
                     Name = "Cập nhật",
                     Code = "edit-group",
                     CategoryId = Guid.Parse("FE7F810C-72B9-44CB-AB4B-3FAF28CDC443")
                 }
            );
            modelBuilder.Entity<Authorized>().HasData(
               new Authorized()
               {
                   Id = Guid.NewGuid(),
                   GroupId = Guid.Parse("EB6B4076-AE9A-4D83-9522-F71760BF27B4"),
                   RoleId = Guid.Parse("B643E139-B6BF-41D7-A251-AD3BD2AE5574")
               }
            );
           base.OnModelCreating(modelBuilder);
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Authorized> Authorizeds { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
       
    }
}
