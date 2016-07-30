using System;
using System.Collections;
using System.Collections.Generic;

namespace Task04
{
    public class BookListService: IEnumerable<Book>
    {
        #region declaration of variables, constructors
        private readonly List<Book> listOfBooks;

        /// <summary>
        /// The constructor creates a list of books on the basis of existing.
        /// </summary>
        /// <param name="_listOfBooks">Existing list of books.</param>
        public BookListService(IEnumerable<Book> _listOfBooks)
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
                CustomLogger.logger.Fatal("Method Add(): ArgumentNullException;\n");
                throw new ArgumentNullException();
            }

            foreach (Book elem in listOfBooks)
            {
                if (book.Equals(elem))
                {
                    CustomLogger.logger.Fatal("Method Add(): InvalidOperationException;\n");
                    throw new InvalidOperationException("This object already exists!");
                }
            }
            CustomLogger.logger.Info("Method Add(): element added;\n");
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
                CustomLogger.logger.Fatal("Method Remove(): ArgumentNullException;\n");
                throw new ArgumentNullException();
            }
            if (!listOfBooks.Remove(book))
            {
                CustomLogger.logger.Fatal("Method Add(): InvalidOperationException;\n");
                throw new InvalidOperationException("This object already not exists!");
            }
            CustomLogger.logger.Info("Method Add(): element removed;\n");
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
                CustomLogger.logger.Fatal("Method FindBookByTag(): ArgumentNullException;\n");
                throw new ArgumentNullException();
            }
            foreach (Book book in listOfBooks)
            {
                if (book.Author == tag || book.Title == tag)
                {
                    CustomLogger.logger.Info("Method FindBookByTag(): Book found.;\n");
                    return new Book(book.Author, book.Title, book.Pages, book.YearOfPublish);
                }

            }
            CustomLogger.logger.Error("Method FindBookByTag(): Book not found.;\n");
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
                CustomLogger.logger.Fatal("Method FindBookByTag(): ArgumentOutOfRangeException;\n");
                throw new ArgumentOutOfRangeException();
            }
            foreach (Book book in listOfBooks)
            {
                if (book.Pages == tag || book.YearOfPublish == tag)
                {
                    CustomLogger.logger.Fatal("Method FindBookByTag(): Book found.\n");
                    return new Book(book.Author, book.Title, book.Pages, book.YearOfPublish);
                }

            }
            CustomLogger.logger.Error("Method FindBookByTag(): Book not found.\n");
            return null;
        }

        /// <summary>
        /// It sorts the list of books relative to the input parameter.
        /// </summary>
        /// <param name="comparison">One of the properties of the book.</param>
        public void SortBooksByTag(IComparer<Book> comparison)
        {
            if (ReferenceEquals(null, comparison))
            {
                CustomLogger.logger.Fatal("Method SortBooksByTag(): ArgumentNullException;\n");
                throw new ArgumentNullException();
            }
            listOfBooks.Sort(comparison);
            CustomLogger.logger.Info("Method SortBooksByTag(): List of books is sorted;\n");
        }
#endregion

        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < listOfBooks.Count; i++)
            {
                yield return listOfBooks[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
