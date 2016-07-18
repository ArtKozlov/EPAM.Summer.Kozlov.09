using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Task04
{
    public class BinaryBookListStorage: IBookListStorage
    {
        private readonly string file;
        private BinaryWriter dataOut;
        private BinaryReader dataIn;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public BinaryBookListStorage(string fileName)
        {
            file = fileName;

        }
        /// <summary>
        /// Method download book list from a file.
        /// </summary>
        /// <returns>book list from a file.</returns>
        public List<Book> LoadBooks()
        {
            try
            {
                List<Book> listOfBooks = new List<Book>();
                dataIn = new BinaryReader(new FileStream(file, FileMode.Open));

                while (dataIn.PeekChar() > -1)
                {
                    string author = dataIn.ReadString();
                    string title = dataIn.ReadString();
                    int pages = dataIn.ReadInt32();
                    int yearOfPublish = dataIn.ReadInt32();

                    listOfBooks.Add(new Book(author, title, pages, yearOfPublish));
                }
                return listOfBooks;
            }
            catch (IOException e)
            {
                logger.Fatal("File didn't load.");
                return null;
            }
            finally
            {
                dataIn.Close();
            }
        }
        /// <summary>
        /// Method save list of books in text file.
        /// </summary>
        /// <param name="books">List of books</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            try
            {
                dataOut = new BinaryWriter(new FileStream(file, FileMode.Create));

                foreach (Book book in books)
                {
                    dataOut.Write(book.Author);
                    dataOut.Write(book.Title);
                    dataOut.Write(book.Pages);
                    dataOut.Write(book.YearOfPublish);
                }
            }
            catch (IOException e)
            {
                logger.Fatal("File didn't create.");
            }
            finally
            {
                dataOut.Close();
            }
        }
    }
}
