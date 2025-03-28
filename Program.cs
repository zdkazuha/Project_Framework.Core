using DbController;
using DbController.Entities;
using System.Numerics;
using System.Text;

internal class Program
{
    public static Book ReturnBook()
    {
        Console.WriteLine("Введіть Title :: ");
        string title = Console.ReadLine();

        Console.WriteLine("Введіть Genre :: ");
        string genre = Console.ReadLine();

        Console.WriteLine("Введіть PublishingHouseName :: ");
        string publishingHouseName = Console.ReadLine();

        int numberOfPages;
        while (true)
        {
            Console.WriteLine("Введіть NumberOfPages :: ");
            if (int.TryParse(Console.ReadLine(), out numberOfPages))
                break;
            else
                Console.WriteLine("Будь ласка, введіть коректне ціле число для NumberOfPages.");
        }

        int yearOfPublication;
        while (true)
        {
            Console.WriteLine("Введіть YearOfPublication :: ");
            if (int.TryParse(Console.ReadLine(), out yearOfPublication))
                break;
            else
                Console.WriteLine("Будь ласка, введіть коректне ціле число для YearOfPublication.");
        }

        int sellingPrice;
        while (true)
        {
            Console.WriteLine("Введіть SellingPrice :: ");
            if (int.TryParse(Console.ReadLine(), out sellingPrice))
                break;
            else
                Console.WriteLine("Будь ласка, введіть коректне ціле число для SellingPrice.");
        }

        int costPrice;
        while (true)
        {
            Console.WriteLine("Введіть CostPrice :: ");
            if (int.TryParse(Console.ReadLine(), out costPrice))
                break;
            else
                Console.WriteLine("Будь ласка, введіть коректне ціле число для CostPrice.");
        }

        bool isItASequel;
        while (true)
        {
            Console.WriteLine("Введіть IsItASequel (true/false) :: ");
            if (bool.TryParse(Console.ReadLine(), out isItASequel))
                break;
            else
                Console.WriteLine("Будь ласка, введіть правильне значення для IsItASequel (true або false).");
        }

        int authorId;
        while (true)
        {
            Console.WriteLine("Введіть AuthorId :: ");
            if (int.TryParse(Console.ReadLine(), out authorId))
                break;
            else
                Console.WriteLine("Будь ласка, введіть коректне ціле число для AuthorId.");
        }

        int trilogiesId;
        while (true)
        {
            Console.WriteLine("Введіть TrilogiesId :: ");
            if (int.TryParse(Console.ReadLine(), out trilogiesId))
                break;
            else
                Console.WriteLine("Будь ласка, введіть коректне ціле число для TrilogiesId.");
        }

        Book book = new Book()
        {
            Title = title,
            Genre = genre,
            PublishingHouseName = publishingHouseName,
            NumberOfPages = numberOfPages,
            YearOfPublication = yearOfPublication,
            SellingPrice = sellingPrice,
            CostPrice = costPrice,
            IsItASequel = isItASequel,
            AuthorId = authorId,
            TrilogiesId = trilogiesId,
        };
        return book;
    }
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        DbFunctionality context = new DbFunctionality();

        var user = context.Registration();
        if (user == null)
        {
            Console.WriteLine("\nНе вдалося увійти");
            return;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"\nІмя користувача :: {user.UserName} Кошти :: {user.Money}\n");
            Console.WriteLine("\n1. Додати нову книгу");
            Console.WriteLine("2. Видалити книгу");
            Console.WriteLine("3. Оновити параметри книги");
            Console.WriteLine("4. Продати книгу");
            Console.WriteLine("5. Списати книгу");
            Console.WriteLine("6. Внести книгу в акцію");
            Console.WriteLine("7. Відкласти книгу для окремого користувача");
            Console.WriteLine("8. Знайти книгу за параметрами");
            Console.WriteLine("9. Переглянути список новинок");
            Console.WriteLine("10. Переглянути найпопулярніше");
            Console.WriteLine("11. Переглянути всі таблиці");
            Console.WriteLine("0. Вийти ");
            Console.Write("\nВиберать дію :: ");

            string choice = Console.ReadLine()!;
            switch (choice)
            {
                case "1":
                    Book Addbook = ReturnBook();
                    context.AddBook(Addbook);
                    Console.WriteLine("Книга успішно додана.");
                    break;
                case "2":
                    Console.WriteLine("Введіть Id киниг яку хочете видалити :: ");
                    int id;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out id))
                            break;
                        else
                            Console.WriteLine("Будь ласка, введіть коректне ціле число для Id.");
                    }
                    context.DeleteBook(id);
                    Console.WriteLine("Книга успішно видалена.");
                    break;
                case "3":
                    Book Updatebook = ReturnBook();
                    context.UpdateBook(Updatebook);
                    Console.WriteLine("Книга успішно оновлена.");
                    break;
                case "4":
                    int bookId;
                    while (true)
                    {
                        Console.WriteLine("Введіть Id книги яку хочете продати :: ");
                        if (int.TryParse(Console.ReadLine(), out bookId))
                            break;
                        else
                            Console.WriteLine("Будь ласка, введіть коректне ціле число для Id.");
                    }
                    context.SellBook(bookId, user.Id);
                    break;
                case "5":
                    Console.WriteLine("Введіть Id киниг яку хочете списати :: ");
                    int idb;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out idb))
                            break;
                        else
                            Console.WriteLine("Будь ласка, введіть коректне ціле число для Id.");
                    }
                    context.DeleteBook(idb);
                    Console.WriteLine("Книга успішно списана.");
                    break;
                case "6":
                    Console.WriteLine("Введіть Id киниг яку хочете додати до акції :: ");
                    int ida;
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out ida))
                            break;
                        else
                            Console.WriteLine("Будь ласка, введіть коректне ціле число для Id.");
                    }
                    context.DeleteBook(ida);
                    Console.WriteLine("Книга успішно додана до акції \"Тиждень книг\".");
                    break;
                case "7":
                    Console.WriteLine("Ведіть id книги яку хочете відклати дял себе");
                    int tmp3;

                    if (int.TryParse(Console.ReadLine(), out tmp3))
                    {
                        context.Postponed(tmp3, user.Id);
                    }
                    else
                    {
                        Console.WriteLine("Некоректне значення");
                        break;
                    }
                    break;
                case "8":
                    Console.WriteLine("За яким параметром ви хочете знайти книгу (id/title/author/genre)");
                    string searchParam = Console.ReadLine();

                    switch (searchParam.ToLower())
                    {
                        case "id":
                            Console.WriteLine("Введіть id :: ");
                            if (int.TryParse(Console.ReadLine(), out int bid))
                                context.SearchBookById(bid);
                            else
                                Console.WriteLine("Невірний формат ID");
                            break;
                        case "title":
                            Console.WriteLine("Введіть назву :: ");
                            context.SearchBookByTitle(Console.ReadLine());
                            break;
                        case "author":
                            Console.WriteLine("Введіть автора :: ");
                            context.SearchBookByAuthor(Console.ReadLine());
                            break;
                        case "genre":
                            Console.WriteLine("Введіть жанр :: ");
                            context.SearchBookByGenre(Console.ReadLine());
                            break;
                        default:
                            Console.WriteLine("Невірний параметр пошуку");
                            break;
                    }
                    break;
                case "9":
                    context.NewBooks();
                    break;
                case "10":
                    Console.WriteLine("\tКнига\n\tАвтор\n\tЖанр");
                    string choice2 = Console.ReadLine();
                    switch(choice2)
                    {
                        case "Книга":
                            context.PopularBooks();
                            break;                        
                        case "Автор":
                            context.PopularAuthors();
                            break;                        
                        case "Жанр":
                            Console.WriteLine("Ви хочете переглянути найпопулярніший жанр за (день - місяць - рік) :: ");
                            string tmp = Console.ReadLine();
                            if (tmp == "день")
                                context.MostPopularGenresPerDay();
                            if (tmp == "місяць")
                                context.MostPopularGenresPerMonth();
                            if (tmp == "рік")
                                context.MostPopularGenresPerYear();
                            break;
                    }
                    break;
                case "11":
                    Console.WriteLine("\nЩо ви хочете подивитись :: ");
                    Console.WriteLine("1. Книгу");
                    Console.WriteLine("2. Автора");
                    Console.WriteLine("3. Трилогію");
                    Console.WriteLine("4. Користувачів");
                    Console.WriteLine("5. Архів");
                    Console.WriteLine("6. Відкладені книги");
                    Console.WriteLine("0. Вийти ");
                    Console.Write("\nВиберать дію :: ");

                    string choice3 = Console.ReadLine();
                    switch(choice3)
                    {
                        case "1":
                            context.ViewAllBooks();
                            break;
                        case "2":
                            context.ViewAllAuthors();
                            break;
                        case "3":
                            context.ViewAllTrilogies();
                            break;
                        case "4":
                            context.ViewAllUsers();
                            break;
                        case "5":
                            context.ViewAllSalesArchives();
                            break;                        
                        case "6":
                            context.ViewAllBookPostponed();
                            break;
                        case "0":
                            break;
                        default:
                            Console.WriteLine("\nНевірний вибір!");
                            break;
                    }
                    break;
                case "0":
                    Console.WriteLine("\nДякуємо за відвідування нашої книгарні");
                    return;
                default:
                    Console.WriteLine("\nНевірний вибір!");
                    break;
            }
            Console.Write("\nНатисніть Enter для продовження...");
            Console.ReadLine();
        }

    }
}