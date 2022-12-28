using Microsoft.EntityFrameworkCore;
using PortsAndAdapters_And_CleanArchitecture.Models;

namespace PortsAndAdapters_And_CleanArchitecture.Data
{
    public class EfSqliteAdapter : DbContext
    {
        public DbSet<Conta> Contas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=C:\\WorkSpace\\VisualStudio\\PortsAndAdapters_And_CleanArchitecture\\PortsAndAdapters_And_CleanArchitecture\\Conta.db");
        }
    }
}
