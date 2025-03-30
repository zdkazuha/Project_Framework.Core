using DbController.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController
{
    public static class InitializerDb
    {
        public static void SeedBook(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new Book[]
            {
                new Book()
                {
                    Id = 1,
                    Title = "The Lord of the Rings",
                    Genre = "Fantasy",
                    PublishingHouseName = "Allen & Unwin",
                    NumberOfPages = 1178,
                    YearOfPublication = 1954,
                    SellingPrice = 20,
                    CostPrice = 10,
                    IsItASequel = true,
                    AuthorId = 1,
                    TrilogiesId = 1
                },
                new Book()
                {
                    Id = 2,
                    Title = "The Hobbit",
                    Genre = "Fantasy",
                    PublishingHouseName = "Allen & Unwin",
                    NumberOfPages = 310,
                    YearOfPublication = 1937,
                    SellingPrice = 15,
                    CostPrice = 7,
                    IsItASequel = false,
                    AuthorId = 1,
                    TrilogiesId = 1
                },
                new Book()
                {
                    Id = 3,
                    Title = "The Silmarillion",
                    Genre = "Fantasy",
                    PublishingHouseName = "Allen & Unwin",
                    NumberOfPages = 365,
                    YearOfPublication = 1977,
                    SellingPrice = 25,
                    CostPrice = 12,
                    IsItASequel = true,
                    AuthorId = 1,
                    TrilogiesId = 1
                },
                new Book()
                {
                    Id = 4,
                    Title = "Harry Potter and the Philosopher's Stone",
                    Genre = "Fantasy",
                    PublishingHouseName = "Bloomsbury",
                    NumberOfPages = 223,
                    YearOfPublication = 1997,
                    SellingPrice = 18,
                    CostPrice = 9,
                    IsItASequel = false,
                    AuthorId = 2,
                    TrilogiesId = 2
                },
                new Book()
                {
                    Id = 5,
                    Title = "Harry Potter and the Chamber of Secrets",
                    Genre = "Fantasy",
                    PublishingHouseName = "Bloomsbury",
                    NumberOfPages = 251,
                    YearOfPublication = 1998,
                    SellingPrice = 20,
                    CostPrice = 10,
                    IsItASequel = true,
                    AuthorId = 2,
                    TrilogiesId = 2
                },
            });
        }
        public static void SeedAuthors(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Tolkien"
                },
                new Author()
                {
                    Id = 2,
                    FirstName = "Joanne",
                    LastName = "Rowling"
                },
                new Author()
                {
                    Id = 3,
                    FirstName = "George",
                    LastName = "Martin"
                },
                new Author()
                {
                    Id = 4,
                    FirstName = "J.R.R.",
                    LastName = "Martin"
                },
                new Author()
                {
                    Id = 5,
                    FirstName = "J.K.",
                    LastName = "Rowling"
                }
            });
        }
        public static void SeedTrilogies(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trilogies>().HasData(new Trilogies[]
            {
                new Trilogies()
                {
                    Id = 1,
                    NameTrilogie = "The Lord of the Rings"
                },
                new Trilogies()
                {
                    Id = 2,
                    NameTrilogie = "Harry Potter"
                },
                new Trilogies()
                {
                    Id = 3,
                    NameTrilogie = "A Song of Ice and Fire"
                },
                new Trilogies()
                {
                    Id = 4,
                    NameTrilogie = "The Chronicles of Narnia"
                },  
                new Trilogies()
                {
                    Id = 5,
                    NameTrilogie = "The Hunger Games"
                }
            });
        }
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User()
                {
                    Id = 1,
                    UserName = "UserName 1",
                    Password = "Password 1",
                    Money = 100
                },
                new User()
                {
                    Id = 2,
                    UserName = "UserName 2",
                    Password = "Password 2",
                    Money = 120
                },
                new User()
                {
                    Id = 3,
                    UserName = "UserName 3",
                    Password = "Password 3",
                    Money = 70
                },
                new User()
                {
                    Id = 4,
                    UserName = "UserName 4",
                    Password = "Password 4",
                    Money = 50
                },
                new User()
                {
                    Id = 5,
                    UserName = "UserName 5",
                    Password = "Password 5",
                    Money = 80
                }
            });
        }
        public static void SeedSalesArchives(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesArchive>().HasData(new SalesArchive[]
            {
                new SalesArchive()
                {
                    Id = 1,
                    UserId = 1,
                    BookId = 1,
                    AuthorId = 1,
                    DateOfSale = new DateTime(2025, 3, 24),
                    SellingPrice = 20
                },
                new SalesArchive()
                {
                    Id = 2,
                    UserId = 1,
                    BookId = 4,
                    AuthorId = 1,
                    DateOfSale = new DateTime(2025, 1, 24),
                    SellingPrice = 15
                },
                new SalesArchive()
                {
                    Id = 3,
                    UserId = 1,
                    BookId = 2,
                    AuthorId = 1,
                    DateOfSale = new DateTime(2025, 2, 11),
                    SellingPrice = 25
                },
                new SalesArchive()
                {
                    Id = 4,
                    UserId = 1,
                    BookId = 4,
                    AuthorId = 2,
                    DateOfSale = new DateTime(2025, 3, 14),
                    SellingPrice = 18
                },
                new SalesArchive()
                {
                    Id = 5,
                    UserId = 3,
                    BookId = 5,
                    AuthorId = 2,
                    DateOfSale = new DateTime(2025, 3, 12),
                    SellingPrice = 20
                }
            });
        }
        public static void SeedBookPostponed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookPostponed>().HasData(new BookPostponed[]
            {
                new BookPostponed()
                {
                    Id = 1,
                    UserId = 1,
                    BookId = 1,
                },
                new BookPostponed()
                {
                    Id = 2,
                    UserId = 1,
                    BookId = 3,
                },
            });
        }
    }
}
