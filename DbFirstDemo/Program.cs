using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer<BloggingContext>(new BlogsInitializer());

            using (var context = new BloggingContext())
            {
                #region Lazy and Eager Loading

                // Lazy loading:
                // It is the process whereby an entity or collection of entities is 
                // automatically loaded from the database the first time that a property 
                // referring to the entity/entities is accessed.
                // Acheived by defining the property (List or Object) as "virtual"

                // Eager Loading:
                // Eager loading is the process whereby a query for one type of entity 
                // also loads related entities as part of the query

                // Load all blogs and related comments.
                //.Include(b => b.Comments)

                #endregion

                var blogs = context.Blogs
                    .Include(b => b.Comments)
                    .ToList<Blog>();

                Console.WriteLine("Blog Id - Url - Author");
                foreach (var blog in blogs)
                {
                    Console.WriteLine($"{blog.Id} - {blog.Url}, - {blog.Author}");
                    foreach (var comment in blog.Comments)
                    {
                        Console.WriteLine($"\t{comment.Id}: {comment.CommentText}");
                    }
                }

                Console.WriteLine("");
                Console.WriteLine("All Comments:");
                //var comments = context.Comments.ToList<Comment>();
                var comments = from c in context.Comments
                               select c;

                foreach (var comment in comments)
                {
                    Console.WriteLine($"{comment.Id}: {comment.CommentText}");
                }

                // Load 1 blog and it's related comments.
                var aBlog = context.Blogs
                    .Where(b => b.Id == 1)
                    .Include(b => b.Comments)
                    .FirstOrDefault<Blog>();

                Console.WriteLine("Press <ENTER>...");
                Console.ReadLine();
            }
        }
    }
}
