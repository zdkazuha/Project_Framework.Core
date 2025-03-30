using DbController.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace DbController
{
    public class DbFunctionality
    {
        private readonly Db_Controller context;

        public DbFunctionality()
        {
            context = new Db_Controller();
        }

        public void AddBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }
        public void DeleteBook(int id)
        {
            var book = context.Books.Find(id);

            if (book != null)
            {
                var salesArchives = context.SalesArchives.Where(sa => sa.BookId == id).ToList();
                context.SalesArchives.RemoveRange(salesArchives);

                var postponedBooks = context.BookPostponed.Where(b => b.BookId == id).ToList();
                context.BookPostponed.RemoveRange(postponedBooks);

                context.Books.Remove(book);
                context.SaveChanges();
            }
            else
                Console.WriteLine("Id Книги не знайдено.");
        }
        public void UpdateBook(Book book)
        {
            var existingBook = context.Books.FirstOrDefault(b => b.Id == book.Id);

            if (existingBook != null)
            {
                context.Books.Update(book);
                Console.WriteLine("Книга успішно оновлена.");
            }
            else
            {
                context.Books.Add(book);
                Console.WriteLine("Книга додана як нова.");
            }

            context.SaveChanges();
        }
        public void AddBookToTrilogy(string trilogyName, Book book)
        {
            var trilogy = context.Trilogies.FirstOrDefault(t => t.NameTrilogie == trilogyName);

            if (trilogy != null)
            {
                trilogy.Books.Add(book);
                context.SaveChanges();
            }
            else
                Console.WriteLine("Імя трилогії не знайдено");
        }
        public void SellBook(int bookId, int userId)
        {
            var book = context.Books.Find(bookId);

            if (book == null)
            {
                Console.WriteLine("Книга не знайдена");
                return;
            }

            var user = context.Users.Find(userId);
            if (user == null)
            {
                Console.WriteLine("Користувач не знайдений");
                return;
            }

            if (IsBookPostponed(bookId,userId))
            {
                Console.WriteLine("\nКнига відкладена для іншого користувача\n");
                return;
            }

            var sale = new SalesArchive
            {
                BookId = book.Id,
                UserId = userId,
                AuthorId = book.AuthorId,
                DateOfSale = DateTime.Now,
                SellingPrice = book.SellingPrice
            };

            if(user.Money < book.SellingPrice)
            {
                Console.WriteLine("У користувача недостатньо кошів щоб купить книгу");
                return;
            }
            user.Money -= book.SellingPrice;

            context.SalesArchives.Add(sale);
            context.SaveChanges();
            Console.WriteLine("Книга успішно продана і додана в архів.");
        }
        public void AddToPromotion(string Name)
        {
            var promotion = context.Books.FirstOrDefault(b => b.Title == Name);
            if (promotion != null)
            {
                promotion.SellingPrice = (int)(promotion.SellingPrice * 0.9);
                context.SaveChanges();
            }
            else
                Console.WriteLine("Назву книги не знайдено");
        }
        public void AddToPromotion(Book book)
        {
            var promotion = context.Books.Find(book.Id);

            if (promotion != null)
            {
                promotion.SellingPrice = (int)(promotion.SellingPrice * 0.9);
                context.SaveChanges();
            }
            else
                Console.WriteLine("Книга не знайдена");
        }
        private bool IsBookPostponed(int bookId, int userId)
        {
            var p = context.BookPostponed.FirstOrDefault(b => b.BookId == bookId && b.UserId == userId);
            if (p != null)
                return true;
            else
                return false;
        }
        public void Postponed(int bookId, int userId)
        {
            var Book = context.Books.Find(bookId);
            if (Book == null)
            {
                Console.WriteLine("Книга не знайдена");
                return;
            }

            var User = context.Users.Find(userId);
            if (User == null)
            {
                Console.WriteLine("Користувач не знайдена");
                return;
            }

            var bookPostponed = new BookPostponed
            {
                BookId = bookId,
                UserId = userId,
            };

            context.BookPostponed.Add(bookPostponed);
            context.SaveChanges();

            Console.WriteLine($"Книга '{Book.Title}' відкладена для користувача {User.UserName}.");
        }
        public void SearchBookById(int id)
        {
            var book = context.Books.Find(id);
            if (book != null)
            {
                Console.WriteLine(book.Id);
                Console.WriteLine(book.Title);
                Console.WriteLine(book.Author);
                Console.WriteLine(book.SellingPrice);
            }
            else
                Console.WriteLine("Id Книги не знайдено");
        }
        public void SearchBookByTitle(string title)
        {
            var book = context.Books
                .Where(b => b.Title == title)
                .ToList();
            if (book.Count() != 0)
            {
                foreach (var item in book)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Title);
                    Console.WriteLine(item.Author);
                    Console.WriteLine(item.SellingPrice);
                }
            }
            else
                Console.WriteLine("Назву книги не знайдено");
        }
        public void SearchBookByAuthor(string author)
        {
            var book = context.Books
                .Where(b => b.Author.FirstName == author)
                .ToList();
            if (book.Count() != 0)
            {
                foreach (var item in book)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Title);
                    Console.WriteLine(item.Author);
                    Console.WriteLine(item.SellingPrice);
                }
            }
            else
                Console.WriteLine("Автора книги не знайдено");
        }
        public void SearchBookByGenre(string genre)
        {
            var book = context.Books
                .Where(b => b.Genre == genre)
                .ToList();
            if (book.Count() != 0)
            {
                foreach (var item in book)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Title);
                    Console.WriteLine(item.Author);
                    Console.WriteLine(item.SellingPrice);
                }
            }
            else
                Console.WriteLine("Жанр книги не знайдено");
        }
        public void NewBooks()
        {
            var books = context.Books
                .OrderByDescending(b => b.YearOfPublication)
                .Take(5)
                .ToList();

            Console.WriteLine("Новинки:");
            foreach (var book in books)
            {
                Console.WriteLine($"Id :: {book.Id}");
                Console.WriteLine($"\tTitle            :: {book.Id}");
                Console.WriteLine($"\tYear publication :: {book.YearOfPublication}");
            }

        }
        public void PopularBooks()
        {
            var topBook = context.SalesArchives
                .GroupBy(s => s.BookId)
                .Select(g => new
                {
                    BookId = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(b => b.Count)
                .FirstOrDefault();

            if (topBook != null)
            {
                var book = context.Books.Find(topBook.BookId);

                if (book != null)
                {
                    Console.WriteLine($"Most popular book:");
                    Console.WriteLine($"Name: {book.Title}, Number of sales: {topBook.Count}, Price: {book.SellingPrice}");
                }
                else
                    Console.WriteLine("Book is not found.");
            }
            else
                Console.WriteLine("No sales found.");
        }
        public void PopularAuthors()
        {
            var topAuthor = context.SalesArchives
                .GroupBy(s => s.Book.AuthorId)
                .Select(g => new
                {
                    AuthorId = g.Key,
                    SalesCount = g.Count()
                })
                .OrderByDescending(a => a.SalesCount)
                .FirstOrDefault();

            if (topAuthor != null)
            {
                var author = context.Authors.Find(topAuthor.AuthorId);

                if (author != null)
                {
                    Console.WriteLine($"Most popular author:");
                    Console.WriteLine($"Name: {author.FirstName} {author.LastName}, Number of sales: {topAuthor.SalesCount}");
                }
                else
                    Console.WriteLine("Author not found.");
            }
            else
                Console.WriteLine("No sales found.");
        }
        public void MostPopularGenresPerDay()
        {
            var topGenre = context.SalesArchives
                .Where(s => s.DateOfSale.Date.Day == DateTime.Now.Date.Day)
                .GroupBy(s => s.Book.Genre)
                .Select(g => new
                {
                    Genre = g.Key,
                    SalesCount = g.Count()
                })

                .OrderByDescending(g => g.SalesCount)
                .FirstOrDefault();

            if (topGenre != null)
            {
                Console.WriteLine($"Most popular genre:");
                Console.WriteLine($"Genre: {topGenre.Genre}, Number of sales: {topGenre.SalesCount}");
            }
            else
                Console.WriteLine("No sales found.");
        }
        public void MostPopularGenresPerMonth()
        {
            var topGenre = context.SalesArchives
                .Where(s => s.DateOfSale.Date.Month == DateTime.Now.Date.Month)
                .GroupBy(s => s.Book.Genre)
                .Select(g => new
                {
                    Genre = g.Key,
                    SalesCount = g.Count()
                })

                .OrderByDescending(g => g.SalesCount)
                .FirstOrDefault();

            if (topGenre != null)
            {
                Console.WriteLine($"Most popular genre:");
                Console.WriteLine($"Genre: {topGenre.Genre}, Number of sales: {topGenre.SalesCount}");
            }
            else
                Console.WriteLine("No sales found.");
        }
        public void MostPopularGenresPerYear()
        {
            var topGenre = context.SalesArchives
                .Where(s => s.DateOfSale.Date.Year == DateTime.Now.Date.Year)
                .GroupBy(s => s.Book.Genre)
                .Select(g => new
                {
                    Genre = g.Key,
                    SalesCount = g.Count()
                })

                .OrderByDescending(g => g.SalesCount)
                .FirstOrDefault();

            if (topGenre != null)
            {
                Console.WriteLine($"Most popular genre:");
                Console.WriteLine($"Genre: {topGenre.Genre}, Number of sales: {topGenre.SalesCount}");
            }
            else
                Console.WriteLine("No sales found.");
        }
        public User Registration()
        {
            Console.WriteLine("Введіть ім'я користувача :: ");
            string userName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userName))
            {
                Console.WriteLine("Ім'я користувача не може бути порожнім");
                return null;
            }

            Console.WriteLine("Введіть пароль :: ");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Пароль не може бути порожнім");
                return null;
            }

            return context.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
        }
        public void ViewAllBooks()
        {
            var books = context.Books
                .Include(b => b.Trilogies)
                .Include(b => b.Author)
                .ToList();
            Console.WriteLine("Books :: ");
            foreach (var book in books)
            {
                Console.WriteLine($"\nId :: {book.Id}");
                Console.WriteLine($"\t{book.Title}");
                Console.WriteLine($"\t{book.Genre}");
                Console.WriteLine($"\t{book.PublishingHouseName}");
                Console.WriteLine($"\t{book.NumberOfPages}");
                Console.WriteLine($"\t{book.YearOfPublication}");
                Console.WriteLine($"\t{book.Trilogies?.NameTrilogie ?? "Немає трилогії"}");
                Console.WriteLine($"\t{book.Author.LastName} {book.Author.FirstName}");
            }
        }
        public void ViewAllAuthors()
        {
            var authors = context.Authors
                .Include(a => a.Books)
                .Include(a => a.SalesArchives)
                .ToList();

            Console.WriteLine("Authors :: ");
            foreach (var author in authors)
            {
                Console.WriteLine($"\nId :: {author.Id}");
                Console.WriteLine($"\t{author.FirstName}");
                Console.WriteLine($"\t{author.LastName}");

                Console.WriteLine("\tBooks:");
                if (author.Books.Count() == 0)
                {
                    foreach (var book in author.Books)
                        Console.WriteLine($"\t\t{book.Title} ({book.YearOfPublication})");
                }
                else
                    Console.WriteLine("\t\tNo books found.");

                Console.WriteLine("\tSales Archives:");
                if (author.SalesArchives.Count() == 0)
                {
                    foreach (var salesArchive in author.SalesArchives)
                        Console.WriteLine($"\t\t{salesArchive.DateOfSale} - {salesArchive.SellingPrice}");
                }
                else
                    Console.WriteLine("\t\tNo sales archives found.");
            }
        }
        public void ViewAllTrilogies()
        {
            var trilogies = context.Trilogies
                    .Include(a => a.Books)
                    .ToList();

            Console.WriteLine("Trilogies :: ");
            foreach (var trilogie in trilogies)
            {
                Console.WriteLine($"\nId :: {trilogie.Id}");
                Console.WriteLine($"\t{trilogie.NameTrilogie}");

                Console.WriteLine("\tBooks:");
                if (trilogie.Books.Count() == 0)
                {
                    foreach (var book in trilogie.Books)
                        Console.WriteLine($"\t\t{book.Title} ({book.YearOfPublication})");
                }
                else
                    Console.WriteLine("\t\tNo books found.");
            }
        }
        public void ViewAllSalesArchives()
        {
            Console.WriteLine("SalesArchives :: ");
            foreach (var SalesArchive in context.SalesArchives)
            {
                Console.WriteLine($"\nId :: {SalesArchive.Id}");
                Console.WriteLine($"\t{SalesArchive.UserId}");
                Console.WriteLine($"\t{SalesArchive.BookId}");
                Console.WriteLine($"\t{SalesArchive.AuthorId}");
                Console.WriteLine($"\t{SalesArchive.DateOfSale}");
                Console.WriteLine($"\t{SalesArchive.SellingPrice}");
            }
        }
        public void ViewAllUsers()
        {
            Console.WriteLine("Users :: ");
            foreach (var user in context.Users)
            {
                Console.WriteLine($"\t{user.Id}");
                Console.WriteLine($"\t{user.Id}");
                Console.WriteLine($"\t{user.UserName}");
                Console.WriteLine($"\t{user.Password}");
                Console.WriteLine($"\t{user.Money}");
            }
        }
        public void ViewAllBookPostponed()
        {
            Console.WriteLine("Book Postponed :: ");
            foreach (var book in context.BookPostponed)
            {
                Console.WriteLine($"\t{book.Id}");
                Console.WriteLine($"\t{book.UserId}");
                Console.WriteLine($"\t{book.BookId}");
            }
        }
    }
}