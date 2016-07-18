using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task04;

namespace Task04.UI
{
    class TestBookListService
    {
        static void Main(string[] args)
        {
            BookListService listOfBooks = new BookListService();
            Book book1 = new Book("", "", 0, 0);
            listOfBooks.AddBook(new Book("Ivan","Ivanov",400,2015));
            listOfBooks.AddBook(new Book("Nikolay", "Ivanov", 200, 2015));
            listOfBooks.AddBook(new Book("Vasia", "Ivanov", 100, 2015));
            listOfBooks.AddBook(new Book("Stas", "Ivanov", 700, 2015));
            listOfBooks.RemoveBook(new Book("Stas", "Ivanov", 900, 2015));
            listOfBooks.AddBook(new Book("Dima", "Ivanov", 201, 2015));
            BinaryBookListStorage storage = new BinaryBookListStorage("D:\\text.txt");
            storage.SaveBooks(listOfBooks);
            List<Book> newListOfBooks = storage.LoadBooks();
            foreach (Book book in newListOfBooks)
            {
                Console.WriteLine(book.ToString());
            }
            Console.WriteLine("Find a book by tag is Nikolay");
            Console.WriteLine(listOfBooks.FindBookByTag("Nikolay").ToString());
            IComparer <Book> comparer = book1;
            listOfBooks.SortBooksByTag(comparer);
            foreach (Book book in listOfBooks)
            {
                Console.WriteLine(book.ToString());
            }
            Console.ReadKey();
        }
    }
}
