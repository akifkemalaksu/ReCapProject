using Microsoft.EntityFrameworkCore;
using ReCapProject.Core.Entities.Concrete;
using ReCapProject.Data.Entities;

namespace ReCapProject.Data.Access.EntityFramework
{
    public class EFReCapContext : DbContext
    {
        public EFReCapContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-6TL0L84;Initial Catalog=ReCapContext;Integrated Security=True;");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentRentalMap> PaymentRentalMaps { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}