using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo_CodeBasedMigrations
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                var blog = new Blog
                {
                    Url = "http://www.google.com"
                };

                db.Blogs.Add(blog);
                db.SaveChanges();
            }
        }
    }
}
