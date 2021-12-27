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
        
        public DbSet<Service> Services { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Package> HealthPackages { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public object TreatmentTypes { get; internal set; }
    }
}
