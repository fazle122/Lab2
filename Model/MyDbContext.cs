using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Teacher>().HasIndex(teacher => teacher.Name);
        }
    }
}
