using MauiSqliteDB.Models;
using MauiSqliteDB.Utilities;
using Microsoft.EntityFrameworkCore;

namespace MauiSqliteDB.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<StudentDT> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionDb = $"Filename={PathDB.GetPath("Test.db")}";
                optionsBuilder.UseSqlite(connectionDb);
            }
        }
    }
}
