using Microsoft.EntityFrameworkCore;
using System;

namespace ProcessInfo.DB.Models
{
    public partial class ProcessInfoDbContext : DbContext
    {
        public ProcessInfoDbContext()
        {
        }

        public ProcessInfoDbContext(DbContextOptions<ProcessInfoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Application> Application { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=processinfo;user=root;password=root;Allow User Variables=True;");
                // optionsBuilder.UseSqlServer("Server=localhost;Database=ProcessInformation;Trusted_Connection=True;User Id=sa;Password=admin!@#123;Integrated Security=false;");
            }
        }


    }
}
