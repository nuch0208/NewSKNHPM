using SKNHPM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SKNHPM.Data;
public class AppDbContext : IdentityDbContext<AppUser>
{
    // public AppicationDbContext(DbContextOptions<AppicationDbContext> options)
    //     : base(options)
    //     {

    //     }
   public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Department> Departments {get; set;}
    public DbSet<JobStatus> JobStatuses {get; set;}
    public DbSet<Material> Materials {get; set;}
    public DbSet<MaterialStatus> MaterialStatuses {get; set;}
    public DbSet<NurseRequest> NurseRequests {get; set;}
    public DbSet<Patient> Patients {get; set;}
    public DbSet<Poter> Poters {get; set;}
    public DbSet<Urgent> Urgents {get; set;}
    public DbSet<UserLogin> UserLogins {get; set;}
    public DbSet<UserRole> UserRoles {get; set;}
}
