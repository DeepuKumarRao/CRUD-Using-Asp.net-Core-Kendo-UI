using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Tablebindcore.Models
{
    public class ConnectionStringClass : DbContext
    {
        private readonly string connectionString;
        public ConnectionStringClass(DbContextOptions<ConnectionStringClass> options, IConfiguration configuration) : base(options)
        {
            this.connectionString = configuration.GetSection("ConnectionStrings:MyConnection").Value;
            Database.SetCommandTimeout(600);


        }
        public virtual DbSet<EmpClass> Empdata { get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(this.connectionString);
            }
        }
    }
}
