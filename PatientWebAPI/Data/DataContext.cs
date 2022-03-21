using Microsoft.EntityFrameworkCore;
namespace PatientWebAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }
        public DbSet<Patient> Patients { get; set; }
    }
}
