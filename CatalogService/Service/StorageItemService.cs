using System;
using System.Collections.Generic;
using CatalogService.Storage;
using CatalogService.StorageItems;

namespace CatalogService.Service
{
    public abstract class StorageItemService<T> where T : StorageItem
    {
        protected IRepositoryFactory<T> RepositoryFactory { get; set; }

        private AbstractRepository<T> repository;
        protected AbstractRepository<T> Repository => repository ?? (repository = RepositoryFactory.Create());

        protected StorageItemService(IRepositoryFactory<T> repositoryFactory)
        {
            RepositoryFactory = repositoryFactory;
        }

        public bool AddItem(T item)
        {
            return Repository.AddItem(item);
        }

        public bool RemoveItem(T item)
        {
            return Repository.RemoveItem(item);
        }

        public T FindItemByTag(Predicate<T> tag)
        {
            return Repository.FindItemByTag(tag) as T;
        }

        public void SortItemsByTag(IComparer<T> comparer)
        {
            Repository.SortItemsByTag(comparer);
        }
    }
}
