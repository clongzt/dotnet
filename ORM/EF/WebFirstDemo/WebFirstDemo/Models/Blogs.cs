using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFirstDemo.Models
{
    public class Blog
    {
        public Blog()
        {
            //Posts = new HashSet<Post>();
        }

        public int BlogId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Url { get; set; }
    }
}