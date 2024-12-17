using RadinikMAUIDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace RadinikMAUIDemo.Db
{
    public class LocalDatabase : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public LocalDatabase()
        {
            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Radinik.db3");

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }
    }
}
