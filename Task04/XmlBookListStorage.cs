using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using NLog;

namespace Task04
{
    public class XmlBookListStorage : IBookListStorage
    {
        private readonly string file;
        private XmlSerializer xmlData;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public XmlBookListStorage(string fileName)
        {
            file = fileName;

        }
        /// <summary>
        /// Method download book list from a file.
        /// </summary>
        /// <returns>book list from a file.</returns>
        public List<Book> LoadBooks()
        {
            FileStream fileStream = null;
            List<Book> listOfBooks = new List<Book>();
            try
            {
                fileStream = new FileStream(file, FileMode.Create);
                xmlData = new XmlSerializer(typeof(List<Book>));

                while (fileStream.Position < fileStream.Length)
                {
                    listOfBooks = (List<Book>)xmlData.Deserialize(fileStream);
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
                if (!ReferenceEquals(null, fileStream)) fileStream.Dispose();
            }
        }
        /// <summary>
        /// Method save list of books in text file.
        /// </summary>
        /// <param name="books">List of books</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(file, FileMode.Create);
                xmlData = new XmlSerializer(typeof(List<Book>));
                xmlData.Serialize(fileStream, books);
            }
            catch (IOException e)
            {
                logger.Fatal("File didn't create.");
            }
            finally
            {
                if (!ReferenceEquals(null, fileStream)) fileStream.Dispose();
            }
        }
    }
}
