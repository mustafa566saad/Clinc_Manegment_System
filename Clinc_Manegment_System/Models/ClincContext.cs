using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clinc_Manegment_System.Models;

public class ClincContext : IdentityDbContext<ApplicationUser>
{
    public ClincContext(DbContextOptions<ClincContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Pationts>().HasIndex(e => e.Email).IsUnique();
        modelBuilder.Entity<Doctors>().HasIndex(e => e.Email).IsUnique();
        modelBuilder.Entity<Department>().HasIndex(e => e.Name).IsUnique();
    }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Doctors> Doctors { get; set; }
    public DbSet<Pationts> Pationts { get; set; }
    public DbSet<Diagnosis> Diagnoses { get; set; }
    public DbSet<Medication> Medications { get; set; }

    public DbSet<Appointments> Appointments { get; set; }
}

