using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Hackathon.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<PassedTests> PassedTests { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
        public DbSet<Color> Colors { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<ContentType> ContentTypes { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<EducationalMaterial> EducationalMaterials { get; set; } = null!;
        public DbSet<Option> Options { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Tariff> Tariffs { get; set; } = null!;
        public DbSet<Organization> Organizations { get; set; } = null!;
        public DbSet<Test> Tests { get; set; } = null!;
        public DbSet<Answer> Answers { get; set; } = null!;


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            InitializeDb.Initialize(modelBuilder);

            //modelBuilder.Entity<Role>().HasData(
            //    new Role() { Id = 1, Name = "superadmin" },
            //    new Role() { Id = 2, Name = "admin" },
            //    new Role() { Id = 3, Name = "hr" },
            //    new Role() { Id = 4, Name = "user" }
            //    );

            //modelBuilder.Entity<Color>().HasData(
            //    new Color() { Id = 1, Name = "default" }
            //    );

            //modelBuilder.Entity<Status>().HasData(
            //    new Role() { Id = 1, Name = "работает" },
            //    new Role() { Id = 2, Name = "в отпуске" },
            //    new Role() { Id = 3, Name = "в командировке" },
            //    new Role() { Id = 4, Name = "уволен" }
            //    );

            //modelBuilder.Entity<ContentType>().HasData(
            //   new Role() { Id = 1, Name = "текст" },
            //   new Role() { Id = 2, Name = "иллюстрация" },
            //   new Role() { Id = 3, Name = "видео" },
            //   new Role() { Id = 4, Name = "ссылка на учебный материал" }
            //   );

            //modelBuilder.Entity<Tariff>().HasData(
            //   new Tariff() { Id = 1, Name = "бесплатный", EmployeeLimit = 5, Decription = "Тариф для личного пользования и  небольших компаний", Price = 0 },
            //   new Tariff() { Id = 2, Name = "малый бизнес", EmployeeLimit = 50, Decription = "Тариф для ИП и малого бизнеса", Price = 5000 },
            //   new Tariff() { Id = 3, Name = "средний", EmployeeLimit = 500, Decription = "Тариф для средних предприятий", Price = 10000 },
            //   new Tariff() { Id = 4, Name = "корпорация", EmployeeLimit = -1, Decription = "Тариф для копораций без лимита по пользователям", Price = 100000 }
            //   ); 
        }
    }
}
