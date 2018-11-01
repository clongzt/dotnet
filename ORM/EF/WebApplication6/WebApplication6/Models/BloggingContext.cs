﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class BloggingContext : DbContext
    {
        public BloggingContext()
            : base("name=testEntities")
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<user> Users { get; set; }

        public virtual DbSet<MemCard> MemCards { get; set; }

        public virtual DbSet<MemcardSale> MemcardSales { get; set; }

        public virtual DbSet<ScoreOnline> ScoreOnlines { get; set; }

        public virtual DbSet<GoodsStorage> GoodsStorages { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}