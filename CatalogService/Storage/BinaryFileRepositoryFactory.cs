using System.Collections.Generic;
using System.IO;
using CatalogService.StorageItems;

namespace CatalogService.Storage
{
    public abstract class BinaryFileRepositoryFactory<T> : IRepositoryFactory<T> where T : StorageItem
    {
        protected string FileName { get; set; }

        protected BinaryFileRepositoryFactory(string fileName)
        {
            FileName = fileName;
        }

        public abstract AbstractRepository<T> Create();
        public abstract void WriteItemToFile(BinaryWriter writer, T item);
        public abstract T ReadItemFromFile(BinaryReader reader);

        public void SaveItems(List<T> items)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.Create)))
            {
                foreach (T item in items)
                {
                    WriteItemToFile(writer, item);
                }
            }
        }

        public List<T> GetItems()
        {
            List<T> items = new List<T>();
            if (!File.Exists(FileName)) return items;

            using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    items.Add(ReadItemFromFile(reader));
                }
            }
            return items;
        }
    }
}
