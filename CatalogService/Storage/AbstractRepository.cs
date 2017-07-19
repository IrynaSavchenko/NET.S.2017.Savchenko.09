using System;
using System.Collections.Generic;
using CatalogService.StorageItems;

namespace CatalogService.Storage
{
    public abstract class AbstractRepository<T> where T : StorageItem
    {
        public List<T> ItemList;

        public virtual bool AddItem(T item)
        {
            if (ItemList.Contains(item)) return false;

            ItemList.Add(item);
            return true;
        }

        public virtual bool RemoveItem(T item)
        {
            return ItemList.Remove(item);
        }

        public virtual StorageItem FindItemByTag(Predicate<T> tag)
        {
            return ItemList.Find(tag);
        }

        public virtual void SortItemsByTag(IComparer<T> comparer)
        {
            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException($"Argument {nameof(comparer)} cannot be null");
            ItemList.Sort(comparer);
        }
    }
}
