using System;

namespace CatalogService.StorageItems.Books
{
    public class Book : StorageItem
    {
        public string Name { get; set; }
        public string Author { get; set; }

        private int year;
        public int Year
        {
            get => year;
            set
            {
                if(value < 0 || value > DateTime.Now.Year)
                    throw new ArgumentException($"Argument {nameof(year)} is incorrect");
            }
        }

        private decimal cost;

        public decimal Cost
        {
            get => Cost;
            set
            {
                if (value <= 0)
                    throw new ArgumentException($"Argument {nameof(cost)} must be positive");
            }
        }

        public Book() { }

        public Book(string author, string name, int year, decimal cost)
        {
            Author = author;
            Name = name;
            Year = year;
            Cost = cost;
        }

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

        protected override int CompareTo(StorageItem other)
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
