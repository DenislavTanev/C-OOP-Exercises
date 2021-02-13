using DocumentFormat.OpenXml.Drawing.Charts;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private Database datebase;
        private readonly int[] initialData = new int[] { 1, 2 };
        [SetUp]
        public void Setup()
        {
            this.datebase = new Database(initialData);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] {})]
        public void TestIfConstructorWorks(int[] data)
        {
            //int[] data = new int[] { 1, 2, 3 };
            this.datebase = new Database(data);
            int expectedCount = data.Length;
            int initialCount = this.datebase.Count;
            Assert.AreEqual(expectedCount,initialCount);
        }
        [Test]
        public void ConstructorShouldThrowExpectionWhenBiggerConstructor()
        {
            int[] data = new int[17] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17 };
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.datebase = new Database(data);
            });
        }
        [Test]
        public void AddShouldIncreaseCountWhenAddedSuccessfully()
        {
            this.datebase.Add(3);
            int expectedCount = 3;
            int actualCount = this.datebase.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void AddShouldThrowExeptionWhenDatabaseFull()
        {
            for (int i = 3; i <= 16; i++)
            {
                this.datebase.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.datebase.Add(17); 
            });
        }
        [Test]
        public void RemoveShouldDecreaseCountWhenSuccess()
        {
            int expected = 1;
            this.datebase.Remove();
            int actual = this.datebase.Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RemoveShouldThrowExpectionWhenDatabaseEmpty()
        {
            this.datebase.Remove();
            this.datebase.Remove();
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.datebase.Remove();
            });
        }
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] {})]
        [TestCase(new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16  })]
        public void FetchShouldReturnCopyOfData(int[] ExpectedData)
        {
            this.datebase = new Database(ExpectedData);
            int[] actualData = this.datebase.Fetch();
            CollectionAssert.AreEqual(ExpectedData, actualData);
        }
    }
}