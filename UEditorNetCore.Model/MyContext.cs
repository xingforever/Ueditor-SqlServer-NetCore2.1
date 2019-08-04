using Microsoft.EntityFrameworkCore;
using System;
using UEditorNetCore.Model.Entity;

namespace UEditorNetCore.Model
{
    public class MyContext : DbContext
    {
        public MyContext()
        {

        }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var articleInfo = modelBuilder.Entity<Article>();
            articleInfo.Property(e => e.Context).IsRequired();
            articleInfo.Property(e => e.Title).IsRequired().HasMaxLength(60);
            articleInfo.Property(e => e.CreateTime).IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=DESKTOP-BLVR9FG\\SQL2017;Initial Catalog=ArticleShowAddDemo;uid=sa;pwd=123456;");
        }
        public DbSet<Article> Articles { get; set; }

    }
}
