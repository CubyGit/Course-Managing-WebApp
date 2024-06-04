using Microsoft.EntityFrameworkCore;
using Asp.netMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asp.netMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TestTable> TestTable { get; set; }

        public async Task InsertTestTable(TestTable model)
        {
            TestTable.Add(model);
            await SaveChangesAsync();
        }

        public async Task<List<TestTable>> GetAllTestTables()
        {
            return await TestTable.ToListAsync();
        }
    }
}
