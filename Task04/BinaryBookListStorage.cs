using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    public class BinaryBookListStorage: IBookListStorage
    {
        public BinaryBookListStorage(string fileName)
        {
        }

        public List<Book> LoadBooks()
        {
            return new List<Book>();
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            
        }
    }
}
