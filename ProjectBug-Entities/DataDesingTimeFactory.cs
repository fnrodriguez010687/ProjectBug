using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProjectBug_Entities
{
    public class DataDesignTimeFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var ops = new DbContextOptionsBuilder<DataContext>();
            ops.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BugsManager;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            return new DataContext(ops.Options);
        }
    }
}
