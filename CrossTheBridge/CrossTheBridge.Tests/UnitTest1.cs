using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CrossTheBridge.Tests
{
    [TestClass]
    public class CrossTheBridgeHelperTests
    {
        [TestMethod]
        public void IsValidPeople_Valid()
        {
            CrossTheBridgeHelper helper = new CrossTheBridgeHelper();
            List<int> people = new List<int>() { 10, 5, 2, 1 };

            Assert.IsTrue(helper.IsValid(people));
        }

        [TestMethod]
        public void IsValidPeople_NotValid()
        {
            CrossTheBridgeHelper helper = new CrossTheBridgeHelper();
            List<int> people = new List<int>() { 10, 0, 2, 1 };

            Assert.IsFalse(helper.IsValid(people));
        }

        [TestMethod]
        public void IsDone_Done()
        {
            CrossTheBridgeHelper helper = new CrossTheBridgeHelper();
            var APart = new int[] { 0, 0, 0, 0 };

            Assert.IsTrue(helper.IsDone(APart));
        }

        [TestMethod]
        public void IsDone_Not()
        {
            CrossTheBridgeHelper helper = new CrossTheBridgeHelper();
            var APart = new int[] { 0, 0, 0, 1 };

            Assert.IsFalse(helper.IsDone(APart));
        }

        [TestMethod]
        public void GetSmallestNumberIndex_1()
        {
            CrossTheBridgeHelper helper = new CrossTheBridgeHelper();
            List<int> people = new List<int>() { 10, 5, 2, 1 };

            Assert.AreEqual(helper.GetSmallestNumberIndex(people.ToArray()), 3);
        }

        [TestMethod]
        public void GetSmallestNumberIndex_2()
        {
            CrossTheBridgeHelper helper = new CrossTheBridgeHelper();
            List<int> people = new List<int>() { 10, 5, 2, 0 };

            Assert.AreEqual(helper.GetSmallestNumberIndex(people.ToArray()), 2);
        }

        [TestMethod]
        public void SortPeople()
        {
            CrossTheBridgeHelper helper = new CrossTheBridgeHelper();
            List<int> people = new List<int>() { 1, 2, 5, 10 };

            var sortedPeople = helper.Sort(people);

            CollectionAssert.AreEqual(sortedPeople, new List<int> { 10, 5, 2, 1 });
        }


        [TestMethod]
        public void SendSmallestPair_1()
        {
            CrossTheBridgeHelper helper = new CrossTheBridgeHelper();
            var APart = new List<int>() { 10, 5, 2, 1 }.ToArray();
            var BPart = new int[] { 0, 0, 0, 0 };

            int result = helper.SendSmallestPair(ref APart, ref BPart);
            CollectionAssert.AreEqual(APart, new int[] { 10, 5, 0, 0 });
            CollectionAssert.AreEqual(BPart, new int[] { 0, 0, 2, 1 });
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void SendSmallestPair_2()
        {
            CrossTheBridgeHelper helper = new CrossTheBridgeHelper();
            var APart = new List<int>() { 10, 5, 0, 1 }.ToArray();
            var BPart = new int[] { 0, 0, 0, 0 };

            int result = helper.SendSmallestPair(ref APart, ref BPart);
            CollectionAssert.AreEqual(APart, new int[] { 10, 5, 0, 1 });
            CollectionAssert.AreEqual(BPart, new int[] { 0, 0, 0, 0 });
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void SendLargestPair()
        {
            CrossTheBridgeHelper helper = new CrossTheBridgeHelper();
            var APart = new List<int>() { 10, 5, 2, 1 }.ToArray();
            var BPart = new int[] { 0, 0, 0, 0 };

            int result = helper.SendLargestPair(ref APart, ref BPart);
            CollectionAssert.AreEqual(APart, new int[] { 0, 0, 2, 1 });
            CollectionAssert.AreEqual(BPart, new int[] { 10, 5, 0, 0 });
            Assert.AreEqual(result, 10);
        }

        [TestMethod]
        public void SendPair_Smallest()
        {
            CrossTheBridgeHelper helper = new CrossTheBridgeHelper();
            var APart = new List<int>() { 10, 5, 2, 1 }.ToArray();
            var BPart = new int[] { 0, 0, 0, 0 };

            int result = helper.SendPair(ref APart, ref BPart);
            CollectionAssert.AreEqual(APart, new int[] { 10, 5, 0, 0 });
            CollectionAssert.AreEqual(BPart, new int[] { 0, 0, 2, 1 });
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void SendPair_Largest()
        {
            CrossTheBridgeHelper helper = new CrossTheBridgeHelper();
            var APart = new List<int>() { 10, 5, 0, 1 }.ToArray();
            var BPart = new int[] { 0, 0, 0, 0 };

            int result = helper.SendPair(ref APart, ref BPart);
            CollectionAssert.AreEqual(APart, new int[] { 0, 0, 0, 1 });
            CollectionAssert.AreEqual(BPart, new int[] { 10, 5, 0, 0 });
            Assert.AreEqual(result, 10);
        }

        [TestMethod]
        public void SendBack()
        {
            CrossTheBridgeHelper helper = new CrossTheBridgeHelper();
            var APart = new List<int>() { 10, 5, 0, 0 }.ToArray();
            var BPart = new int[] { 0, 0, 2, 1 };

            int result = helper.SendBack(ref APart, ref BPart);
            CollectionAssert.AreEqual(APart, new int[] { 10, 5, 0, 1 });
            CollectionAssert.AreEqual(BPart, new int[] { 0, 0, 2, 0 });
            Assert.AreEqual(result, 1);
        }

    }

    [TestClass]
    public class CrossTheBridgeTests
    {
        [TestMethod]
        public void Parameters_Wrong()
        {
            List<int> people = new List<int>() { 0, 2, 5, 10 };
            ICrossTheBridge crossing = new CrossTheBridge(people);

            Assert.AreEqual(crossing.GetResult(), "Nem megfelelő paraméter! Egy személynek legalább 1 percbe telik átkelni a hídon!");
        }

        [TestMethod]
        public void Solve()
        {
            List<int> people = new List<int>() { 10, 5, 2, 1 };
            ICrossTheBridge crossing = new CrossTheBridge(people);
            crossing.Solve();
            Assert.AreEqual(crossing.GetResult(), "17");
        }
    }

}
