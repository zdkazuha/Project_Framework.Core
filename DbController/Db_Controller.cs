using DbController.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController
{
    public class Db_Controller : DbContext
    {
        public Db_Controller()
        {
            if (!this.Database.CanConnect())  
            {
                this.Database.EnsureCreated();  
            }
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
                                          Initial Catalog=DbBookStore;
                                          Integrated Security=True;
                                          Encrypt=False;
                                          TrustServerCertificate=False;
                                          Application Intent=ReadWrite;
                                          Multi Subnet Failover=False;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Trilogies)
                .WithMany(t => t.Books)
                .HasForeignKey(b => b.TrilogiesId);

            modelBuilder.Entity<SalesArchive>()
                .HasOne(s => s.Book)
                .WithMany(b => b.SalesArchives)
                .HasForeignKey(s => s.BookId);

            modelBuilder.Entity<SalesArchive>()
                .HasOne(s => s.User)
                .WithMany(u => u.SalesArchives)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<BookPostponed>()
                .HasOne(bp => bp.Book)
                .WithMany(b => b.BookPostponed)
                .HasForeignKey(bp => bp.BookId);

            modelBuilder.Entity<BookPostponed>()
                .HasOne(bp => bp.User)
                .WithMany(u => u.BookPostponeds)
                .HasForeignKey(bp => bp.UserId);

            modelBuilder.SeedBook();
            modelBuilder.SeedAuthors();
            modelBuilder.SeedTrilogies();
            modelBuilder.SeedUsers();
            modelBuilder.SeedSalesArchives();
            modelBuilder.SeedBookPostponed();
        }


        public DbSet<SalesArchive> SalesArchives { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Trilogies> Trilogies { get; set; }
        public DbSet<BookPostponed> BookPostponed { get; set; }
    }
}