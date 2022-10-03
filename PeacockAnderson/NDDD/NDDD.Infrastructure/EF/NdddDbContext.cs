using Microsoft.EntityFrameworkCore;
using NDDD.Domain.Entities;

namespace NDDD.Infrastructure.EF
{
    public class NdddDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=.\blogging.db");
    }



   
}
