using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DAL
{
    public class HospitalDbContext:DbContext
    {

        #pragma warning disable CS8618
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
                : base(options)
            {
            }
        
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmergencyServiceType> EmergencyServiceTypes { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<HealthPackages> HealthPackages { get; set; }
        public DbSet<Treatments> Treatments { get; set; }
    }
}
