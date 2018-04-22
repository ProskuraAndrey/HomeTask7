using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericList.Tests
{
    [TestClass]
    public class GenericListTests
    {
        [TestMethod]
        public void Add_ArrayAddItem_ArrayPlusNewItem()
        {
            GenericList<int> list = new GenericList<int>();
            Assert.AreNotEqual(null, list);
            Assert.AreEqual(0, list.Count);
            list.Add(10);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void Clear_DeleteItems_EmptyList()
        {
            GenericList<int> gl = new GenericList<int>();
            gl.Add(5);

            gl.Clear();
            Assert.AreEqual(0, gl.Count);
        }

        [TestMethod]
        public void IndexTest()
        {
            int[] arr = { 1, 2, 5, 4, 3, 7, 9 };
            GenericList<int> list = new GenericList<int>();
            foreach (int val in arr)
            {
                list.Add(val);
            }
            Assert.AreNotEqual(9, list.Count);            
            for (int i = 0; i < arr.Length; ++i)
            {
                Assert.AreEqual(arr[i], list[i]);
            }
        }

        [TestMethod]
        public void Contains_InputValue_BoolRezult()
        {
            int someValue = 2;
            GenericList<int> list = new GenericList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.AreEqual(true, list.Contains(someValue));
        }

        [TestMethod]
        public void CopyTo_AllElementsAfterTwo_NewListWithoutFirstTwoElements()
        {
            int[] array = new int[5];
            Random ran = new Random();
            for (int i = 0; i < 5; i++)
            {
                array[i] = ran.Next(20);
            }
            var secondList = new int[3];
            secondList.CopyTo(array, 2);
            Assert.AreEqual(3, secondList.Length);
        }

        [TestMethod]
        public void  IndexOf_ValueFive_ReturnedIndexFour()
        {
            GenericList<int> list = new GenericList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            Assert.AreEqual(4, list.IndexOf(5));
        }

    }
}
