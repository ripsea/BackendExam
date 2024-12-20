using Microsoft.EntityFrameworkCore;

namespace BackendExam
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<MyOffice_ACPD> MyOffice_ACPD { get; set; }        
        public DbSet<MyOffice_ExcuteionLog> MyOffice_ExcuteionLog { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyOffice_ACPD>()
                .HasKey(x => x.ACPD_SID);

            modelBuilder.Entity<MyOffice_ExcuteionLog>()
                .HasKey(x => x.DeLog_AutoID);
        }

    }
}
