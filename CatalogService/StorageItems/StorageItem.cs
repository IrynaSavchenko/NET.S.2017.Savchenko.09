using System;

namespace CatalogService.StorageItems
{
    public abstract class StorageItem : IComparable
    {
        protected abstract bool Equals(StorageItem other);

        public abstract override int GetHashCode();

        public abstract int CompareTo(StorageItem other);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj.GetType() == GetType() && Equals((StorageItem)obj);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj))
                throw new ArgumentNullException($"Argument {nameof(obj)} cannot be null");
            if(obj.GetType() != GetType())
                throw new ArgumentException($"Invalid argument type {nameof(obj)}");

            StorageItem item = (StorageItem) obj;
            if (Equals(item))
                return 0;
            return CompareTo(item);
        }

        public static bool operator ==(StorageItem lhs, object rhs)
        {
            return Equals(lhs, rhs);
        }

        public static bool operator !=(StorageItem lhs, object rhs)
        {
            return !Equals(lhs, rhs);
        }

        public static bool operator ==(object lhs, StorageItem rhs)
        {
            return Equals(lhs, rhs);
        }

        public static bool operator !=(object lhs, StorageItem rhs)
        {
            return !Equals(lhs, rhs);
        }

        public static int operator <(StorageItem lhs, object rhs)
        {
            return lhs.CompareTo(rhs);
        }

        public static int operator <(object lhs, StorageItem rhs)
        {
            return CompareObjectType(lhs, rhs);
        }

        public static int operator >(StorageItem lhs, object rhs)
        {
            return lhs.CompareTo(rhs);
        }

        public static int operator >(object lhs, StorageItem rhs)
        {
            return CompareObjectType(lhs, rhs);
        }

        private static int CompareObjectType(object lhs, StorageItem rhs)
        {
            if (!(lhs is StorageItem))
                throw new ArgumentException($"Invalid argument type {nameof(lhs)}");

            return ((StorageItem)lhs).CompareTo(rhs);
        }
    }
}
