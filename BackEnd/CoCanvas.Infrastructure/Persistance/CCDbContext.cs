using Azure;
using CoCanvas.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCanvas.Infrastructure.Persistance
{
    public class CCDbContext : IdentityDbContext<User>
    {

        public CCDbContext(DbContextOptions<CCDbContext> options) : base(options)
        {
        }

        // Domain entities
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Critique> Critiques { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Reply> Replies { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<CritiqueCanvas> CritiqueCanvas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().Property(u => u.Initials).HasMaxLength(5);

            builder.HasDefaultSchema("identity");

            builder.Entity<Post>().ToTable("Posts", "app");
            builder.Entity<Critique>().ToTable("Critiques", "app");
            builder.Entity<Comment>().ToTable("Comments", "app");
            builder.Entity<Reply>().ToTable("Replies", "app");
            builder.Entity<Tag>().ToTable("Tags", "app");
            builder.Entity<CritiqueCanvas>().ToTable("CritiqueCanvases", "app");

            // Post → User
            builder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Post → Critiques
            builder.Entity<Critique>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Critiques)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            // Critique → User
            builder.Entity<Critique>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Critique → Comments
            builder.Entity<Comment>()
                .HasOne(c => c.Critique)
                .WithMany(cr => cr.Comments)
                .HasForeignKey(c => c.CritiqueId)
                .OnDelete(DeleteBehavior.Cascade);

            // Critique → Replies (Restrict to avoid cascade cycle)
            builder.Entity<Reply>()
                .HasOne(r => r.Critique)
                .WithMany(r => r.Replies)
                .HasForeignKey(r => r.CritiqueId)
                .OnDelete(DeleteBehavior.Restrict);

            // Reply → User (Restrict too)
            builder.Entity<Reply>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Post ↔ Tags (many-to-many)
            builder.Entity<Post>()
                .HasMany(p => p.Tags)
                .WithMany(t => t.Posts)
                .UsingEntity(j => j.ToTable("PostTags", "app"));

            // Critique -> Canvas (One to One)
            // Need to specify HasKey because PK = FK 
            builder.Entity<CritiqueCanvas>()
                .HasKey(cc => cc.CritiqueId);

            builder.Entity<CritiqueCanvas>()
                .HasOne(cc => cc.Critique)
                .WithOne(c => c.Canvas)
                .HasForeignKey<CritiqueCanvas>(c => c.CritiqueId)
                .OnDelete(DeleteBehavior.Cascade);

            // Just to be specific about this column holding a lot of data
            builder.Entity<CritiqueCanvas>()
                .Property(cc => cc.CanvasJson)
                .HasColumnType("nvarchar(max)");
        }
    }
}
