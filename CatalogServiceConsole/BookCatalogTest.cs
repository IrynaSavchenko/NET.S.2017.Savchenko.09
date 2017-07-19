using CatalogService.Service.Books;
using CatalogService.Storage.Books;

namespace CatalogServiceConsole
{
    public class BookCatalogTest
    {
        private const string fileName = "Books";

        static void Main(string[] args)
        {
            BookBinaryFileRepositoryFactory booksRepository = new BookBinaryFileRepositoryFactory(fileName);

            BookListService booksService = new BookListService(booksRepository);
            
        }
    }
}
