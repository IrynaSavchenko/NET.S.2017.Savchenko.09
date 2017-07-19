using CatalogService.StorageItems;

namespace CatalogService.Storage
{
    public interface IRepositoryFactory<T> where T : StorageItem
    {
        AbstractRepository<T> Create();
    }
}
