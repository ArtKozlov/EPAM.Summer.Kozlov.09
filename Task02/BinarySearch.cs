using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{

    public static class BinarySearch
    {
        /// <summary>
        /// The method is a key position in a sorted array.
        /// </summary>
        /// <typeparam name="T">Argument type.</typeparam>
        /// <param name="array">An array which will be the search key.</param>
        /// <param name="key">The key.</param>
        /// <returns>A key position in a sorted array.</returns>
        public static int BinarySearchMethod<T>(T[] array, T key)
        {
            if (ReferenceEquals(array,null)||ReferenceEquals(key,null))
                throw new ArgumentNullException();
            if(array.Length == 0)
                throw new ArgumentException();
           return BinarySearchCalculate(array, key, 0, array.Length - 1);
        } 

        private static int BinarySearchCalculate<T>(T[] array, T key, int left, int right)
        {
            int middle = left + (right - left) / 2;
            if (left == right && Comparer<T>.Default.Compare(array[middle], key) != 0)
                throw new ArgumentOutOfRangeException();
                if (Comparer<T>.Default.Compare(array[middle],key) == 0)
                return middle;
            if (Comparer<T>.Default.Compare(array[middle], key) > 0)
                return BinarySearchCalculate<T>(array, key, left, middle);
            return BinarySearchCalculate<T>(array, key, middle + 1, right);
        }
    }
}
