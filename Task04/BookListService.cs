using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Task04
{
    public class BookListService
    {
        #region declaration of variables, constructors
        private readonly List<Book> listOfBooks;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The constructor creates a list of books on the basis of existing.
        /// </summary>
        /// <param name="_listOfBooks">Existing list of books.</param>
        public BookListService(List<Book> _listOfBooks)
        {
            listOfBooks = new List<Book>(_listOfBooks);
        }

        public BookListService()
        {
            listOfBooks = new List<Book>();
        }
        #endregion
        #region list of book methods 
        /// <summary>
        /// Add books into the list method.
        /// </summary>
        /// <param name="book">Existing book</param>
        public void AddBook(Book book)
        {
            if (ReferenceEquals(null, book))
            {
                logger.Fatal("Method Add(): ArgumentNullException;\n");
            }

            foreach (Book elem in listOfBooks)
            {
                if (book.Equals(elem))
                    throw new InvalidOperationException("This object already exists!");
            }

            listOfBooks.Add(book);
        }

        /// <summary>
        /// Removing the book in the list method.
        /// </summary>
        /// <param name="book">Existing book.</param>
        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(null, book))
            {
                logger.Fatal("Method Remove(): ArgumentNullException;\n");
            }
            if(listOfBooks.Remove(book))
                throw new InvalidOperationException("This object already not exists!");
        }

        /// <summary>
        /// Find books listed on the tag.
        /// </summary>
        /// <param name="tag">The parameter takes the title and author of the book.</param>
        /// <returns></returns>
        public Book FindBookByTag(string tag)
        {
            if (ReferenceEquals(null, tag))
            {
                logger.Fatal("Method FindBookByTag(): ArgumentNullException;\n");
            }
            foreach (Book book in listOfBooks)
            {
                if (book.Author == tag || book.Title == tag)
                {
                    return new Book(book.Author, book.Title, book.Pages, book.YearOfPublish);
                }

            }
            logger.Fatal("Method FindBookByTag(): Book not found.;\n");
            return null;
        }

        /// <summary>
        /// Find books listed on the tag.
        /// </summary>
        /// <param name="tag">The parameter takes the number 
        /// of pages or the date of publication of the book.</param>
        /// <returns></returns>
        public Book FindBookByTag(int tag)
        {
            if (tag <= 0)
            {
                logger.Fatal("Method FindBookByTag(): ArgumentException;\n");
            }
            foreach (Book book in listOfBooks)
            {
                if (book.Pages == tag || book.YearOfPublish == tag)
                {
                    return new Book(book.Author, book.Title, book.Pages, book.YearOfPublish);
                }

            }
            logger.Fatal("Method FindBookByTag(): Book not found.\n");
            return null;
        }

        /// <summary>
        /// It sorts the list of books relative to the input parameter.
        /// </summary>
        /// <param name="comparison">One of the properties of the book.</param>
        public void SortBooksByTag(Comparison<Book> comparison)
        {
            if (ReferenceEquals(null, comparison))
            {
                logger.Fatal("Method SortBooksByTag(): ArgumentNullException;\n");
            }
            listOfBooks.Sort(comparison);
        }
#endregion

    }
}
