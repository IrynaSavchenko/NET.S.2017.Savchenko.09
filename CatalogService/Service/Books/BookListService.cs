using CatalogService.Storage;
using CatalogService.StorageItems.Books;

namespace CatalogService.Service.Books
{
    public class BookListService : StorageItemService<Book>
    {
        public BookListService(IRepositoryFactory<Book> repositoryFactory) : base(repositoryFactory)
        {
        }
    }
}
