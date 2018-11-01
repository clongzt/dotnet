using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebFirstDemo.Models
{
    public class BloggingContext : DbContext
    {
        public BloggingContext()
            : base("name=testEntities")
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
      
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}