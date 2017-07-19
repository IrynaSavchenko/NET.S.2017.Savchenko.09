using System.IO;
using CatalogService.StorageItems.Books;

namespace CatalogService.Storage.Books
{
    public class BookBinaryFileRepositoryFactory : BinaryFileRepositoryFactory<Book>
    {
        public BookBinaryFileRepositoryFactory(string fileName) : base(fileName)
        {
        }

        public override AbstractRepository<Book> Create()
        {
            return new BookRepository();
        }

        protected override void WriteItemToFile(BinaryWriter writer, Book item)
        {
            writer.Write(item.Author);
            writer.Write(item.Name);
            writer.Write(item.Year);
            writer.Write(item.Cost);
        }

        protected override Book ReadItemFromFile(BinaryReader reader)
        {
            return new Book
            {
                Author = reader.ReadString(),
                Name = reader.ReadString(),
                Year = reader.ReadInt32(),
                Cost = reader.ReadDecimal()
            };
        }
    }
}
