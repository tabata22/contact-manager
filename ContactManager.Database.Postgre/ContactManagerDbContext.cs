using ContactManager.Database.Postgre.Configurations;
using ContactManager.Database.Postgre.DalEntities;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Database.Postgre;

public class ContactManagerDbContext : DbContext
{
    public ContactManagerDbContext(DbContextOptions<ContactManagerDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContactManagerConfiguration).Assembly);
    }
    
    public DbSet<ContactManagerDal> ContactManagers { get; set; }
}