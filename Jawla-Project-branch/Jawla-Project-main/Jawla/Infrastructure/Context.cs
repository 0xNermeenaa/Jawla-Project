using Microsoft.EntityFrameworkCore;

namespace Jawla
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseSqlServer(" Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = master; Integrated Security = True;");

    }
}
