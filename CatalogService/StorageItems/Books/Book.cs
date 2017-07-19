using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.StorageItems.Books
{
    public class Book : StorageItem
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public decimal Cost { get; set; }

        protected override bool Equals(StorageItem other)
        {
            Book otherBook = other as Book;
            if (ReferenceEquals(otherBook, null))
                return false;

            return otherBook.Name != null && otherBook.Name.Equals(Name)
                   && otherBook.Author != null && otherBook.Author.Equals(Author)
                   && otherBook.Cost == Cost && otherBook.Year == Year;
        }

        public override int GetHashCode()
        {
            return (string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode()) +
                   (string.IsNullOrEmpty(Author) ? 0 : Author.GetHashCode()) +
                   Cost.GetHashCode() + Year.GetHashCode();
        }

        public override int CompareTo(StorageItem other)
        {
            Book otherBook = other as Book;
            if (ReferenceEquals(otherBook, null))
                throw new ArgumentException($"Invalid argument type {nameof(other)}");

            int comparisonResult = string.Compare(Author, otherBook.Author);
            if (comparisonResult != 0)
                return comparisonResult;

            comparisonResult = string.Compare(Name, otherBook.Name);
            if (comparisonResult != 0)
                return comparisonResult;

            comparisonResult = Year.CompareTo(otherBook.Year);
            if (comparisonResult != 0)
                return comparisonResult;

            return Cost.CompareTo(otherBook.Cost);
        }
    }
}
