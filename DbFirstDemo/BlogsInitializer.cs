using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DbFirstDemo
{
    public class BlogsInitializer : CreateDatabaseIfNotExists<BloggingContext>
    //public class BlogsInitializer : DropCreateDatabaseAlways<BloggingContext>
    //public class BlogsInitializer : DropCreateDatabaseIfModelChanges<BloggingContext>
    {
        protected override void Seed(BloggingContext context)
        {
            base.Seed(context);

            var blogs = new List<Blog>
            {
                new Blog { Id = 1, Url = "www.myblog.com", Author = "Ajay Singala"},
                new Blog { Id = 2, Url = "www.yourblog.com", Author = "John Smith" },
                new Blog { Id = 3, Url = "www.otherblogs.com", Author = "Mary Jane" }
            };

            blogs.ForEach(b => context.Blogs.Add(b));

            var comments = new List<Comment>
            {
                new Comment { Id = 11, CommentText = "Comment 1", BlogId = 1 },
                new Comment { Id = 12, CommentText = "Comment 2", BlogId = 2 },
                new Comment { Id = 13, CommentText = "Comment 3", BlogId = 2 },
                new Comment { Id = 14, CommentText = "Comment 4", BlogId = 3 },
                new Comment { Id = 15, CommentText = "Comment 5", BlogId = 3 }
            };

            blogs.ForEach(b => context.Blogs.Add(b));
            comments.ForEach(c => context.Comments.Add(c));

            context.SaveChanges();
        }
    }
}
