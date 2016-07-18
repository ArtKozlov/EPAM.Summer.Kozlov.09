﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    public interface IBookListStorage
    {
        List<Book> LoadBooks();
        void SaveBooks(IEnumerable<Book> books);

    }
}
