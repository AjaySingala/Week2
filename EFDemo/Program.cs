using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Install-Package Microsoft.EntityFrameworkCore.SqlServer
// Install-Package Microsoft.EntityFrameworkCore.Tools

namespace EFDemo
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

                foreach (var b in db.Blogs)
                {
                    Console.WriteLine($"{b.BlogId} - {b.Url}");
                }
            }
        }
    }
}
