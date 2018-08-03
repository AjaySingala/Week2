using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo_CodeBasedMigrations
{
    public class BloggingContext : DbContext
    {
        public BloggingContext()
            : base("name=BloggingContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BloggingContext, 
                    EFDemo_CodeBasedMigrations.Migrations.Configuration>());
        }

        public DbSet<Blog> Blogs { get; set; }

    }
}
