using System;
using System.Collections.Generic;
using System.Linq;
using CatalogService.StorageItems.Books;

namespace CatalogService.Storage.Books
{
    public class BookRepository : AbstractRepository<Book>
    {
        public BookRepository()
        {
            ItemList = new List<Book>();
        }
    }
}
