using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BlazorBlog.Server.Models
{
    public partial class AMCDbContext : DbContext
    {
        public AMCDbContext()
        {
        }

        public AMCDbContext(DbContextOptions<AMCDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=blogger;password=password;database=blazorblog", x => x.ServerVersion("10.3.27-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("posts");

                entity.Property(e => e.Id)
                    .HasColumnType("int(254)")
                    .HasColumnName("id");

                entity.Property(e => e.Author)
                    .HasColumnType("int(20)")
                    .HasColumnName("author");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasColumnName("content")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Edited)
                    .HasColumnType("datetime")
                    .HasColumnName("edited")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Ispublished).HasColumnName("ispublished");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("title")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnType("varchar(254)")
                    .HasColumnName("url")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Userid)
                    .IsRequired()
                    .HasColumnType("varchar(254)")
                    .HasColumnName("userid")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
