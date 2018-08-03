using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstDemo
{
    public class BloggingContext : DbContext
    {
        public BloggingContext()
            : base("name=BloggingContext")
        {
            
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //public DbSet<Post> Posts { get; set; }
        //public DbSet<Student> Students { get; set; }

    }
}
