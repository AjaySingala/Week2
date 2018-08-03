using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstDemo
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public string Author { get; set; }
        
        public virtual List<Comment> Comments { get; set; }
    }
}
