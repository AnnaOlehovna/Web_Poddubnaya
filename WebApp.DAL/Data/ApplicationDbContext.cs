using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Entities;

namespace WebApp.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<CertificateGroup> CertificateGroups { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
    }
}
