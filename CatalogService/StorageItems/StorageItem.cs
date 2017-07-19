using System;

namespace CatalogService.StorageItems
{
    /// <summary>
    /// Abstract class representation of the item to be stored in a repository
    /// </summary>
    public abstract class StorageItem : IComparable
    {
        protected abstract bool Equals(StorageItem other);

        protected abstract int CompareTo(StorageItem other);

        #region Object Overriden Methods

        /// <summary>
        /// Object overriden method returning the item's hashcode
        /// </summary>
        /// <returns></returns>
        public abstract override int GetHashCode();

        /// <summary>
        /// Object overriden method determining if the current object equals the determined one
        /// </summary>
        /// <param name="obj">Object to compare the current object with</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj.GetType() == GetType() && Equals((StorageItem)obj);
        }

        #endregion

        #region Interface Methods

        /// <summary>
        /// Realization of the IComparable method
        /// </summary>
        /// <param name="obj">Object to compare the current object with</param>
        /// <returns></returns>
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

        #endregion

        #region Operators

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

        #endregion

        #region Private Methods

        private static int CompareObjectType(object lhs, StorageItem rhs)
        {
            if (!(lhs is StorageItem))
                throw new ArgumentException($"Invalid argument type {nameof(lhs)}");

            return ((StorageItem)lhs).CompareTo(rhs);
        }

        #endregion
    }
}
