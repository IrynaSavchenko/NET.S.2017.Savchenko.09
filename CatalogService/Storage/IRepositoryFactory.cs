using System.Collections.Generic;
using CatalogService.StorageItems;

namespace CatalogService.Storage
{
    public interface IRepositoryFactory<T> where T : StorageItem
    {
        AbstractRepository<T> Create();

        List<T> GetItems();

        void SaveItems(List<T> items);
    }
}
