using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static Task02.BinarySearch;

namespace Task02.NUnitTests
{
    public class BinarySearchTests
    {

        [Test, TestCaseSource(typeof(ProviderArray), nameof(ProviderArray.CasesForBinarySearchIntTest))]
        public void BinarySearchIntTest(int[] array, int key, int expected)
        {
            int result = BinarySearchMethod(array, key);
            Assert.AreEqual(expected, result);
        }
        [Test, TestCaseSource(typeof(ProviderArray), nameof(ProviderArray.CasesForBinarySearchDoubleTest))]
        public void BinarySearchDoubleTest(double[] array, double key, int expected)
        {
            int result = BinarySearchMethod(array, key);
            Assert.AreEqual(expected, result);
        }
        [Test, TestCaseSource(typeof(ProviderArray), nameof(ProviderArray.CasesForBinarySearchStringTest))]
        public void BinarySearchStringTest(string[] array, string key, int expected)
        {
            int result = BinarySearchMethod(array, key);
            Assert.AreEqual(expected, result);
        }

    }

    public class ProviderArray
    {
        #region testcases
        public static IEnumerable CasesForBinarySearchIntTest
        {
            get
            {
                yield return new TestCaseData(new int[] {2, 4, 6, 8, 10},6, 2);
                yield return new TestCaseData(new int[] { 11, 33, 432, 700, 987 },11, 0);
                yield return new TestCaseData(new int[] { 111, 333, 444, 777, 979 },777, 3);
                yield return new TestCaseData(new int[] { 20, 40, 50, 77, 97, 99,1000, 2000 },2000, 7);
            }

        }

        public static IEnumerable CasesForBinarySearchDoubleTest
        {

            get
            {
                yield return new TestCaseData(new double[] { 2.3, 4.1, 6.8, 8.0, 10.1 }, 6.8, 2);
                yield return new TestCaseData(new double[] { 11.1, 33.6, 432.7, 700.4, 987.7 }, 11.1, 0);
                yield return new TestCaseData(new double[] { 111.3, 333, 444.2, 777.9, 979.3 }, 777.9, 3);
                yield return new TestCaseData(new double[] { 20, 40, 50, 77, 97, 99, 1000, 2000 }, 2000.0, 7);
            }

        }

        public static IEnumerable CasesForBinarySearchStringTest
        {

            get
            {
                yield return new TestCaseData(new string[] { "a", "b", "c", "d", "e" },"c", 2);
                yield return new TestCaseData(new string[] { "a", "c", "e", "g", "k","l","h","r","q","x" },"r", 7);
                yield return new TestCaseData(new string[] { "abc", "bbc", "cde", "cdo", "fbn" },"fbn",4);
                yield return new TestCaseData(new string[] { "AAAAA", "MMM", "N", "TTTTTTTTTTTTT", "Z" },"N", 2);
            }

        }
        #endregion
    }
}
