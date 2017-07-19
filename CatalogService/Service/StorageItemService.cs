using CatalogService.Storage;
using CatalogService.StorageItems;

namespace CatalogService.Service
{
    public abstract class StorageItemService<T> where T : StorageItem
    {
        protected IRepositoryFactory<T> RepositoryFactory { get; set; }


        private AbstractRepository<T> repository;
        protected AbstractRepository<T> Repository => repository ?? (repository = RepositoryFactory.Create());

        public bool AddItem(T item)
        {
            return Repository.AddItem(item);
        }

        public bool RemoveItem(T item)
        {
            return Repository.RemoveItem(item);
        }
    }
}
