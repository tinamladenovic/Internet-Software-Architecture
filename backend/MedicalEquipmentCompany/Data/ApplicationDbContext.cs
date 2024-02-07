using MedicalEquipmentCompany.Model;
using Microsoft.EntityFrameworkCore;
namespace MedicalEquipmentCompany.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyAdministratorProfile> CompanyAdministratorProfiles { get; set; }
        public DbSet<CompanyRating> CompanyRatings { get; set; }
        public DbSet<CompanyWorkingHours> CompanyWorkingHours { get; set; }
        public DbSet<Complain> Complains { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentPickup> EquipmentPickups { get; set; }
        public DbSet<EquipmentReservation> EquipmentReservations { get; set; }
        public DbSet<LoyaltyClassEntry> LoyaltyClassEntries { get; set; }
        public DbSet<LoyaltyProgram> LoyaltyPrograms { get; set; }
        public DbSet<Reply> Replies { get; set; }



        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

    }
}
