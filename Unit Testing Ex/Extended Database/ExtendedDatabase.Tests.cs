
using NUnit.Framework;
using System;


    public class ExtendedDatabaseTests
    {
        private Person person = new Person(123456789, "Ivan");
        private ExtendedDatabase extendedDatabase;
        [SetUp]
        public void Setup()
        {
            extendedDatabase = new ExtendedDatabase(person);
        }
        [Test]
        public void TestAddPerson()
        {
            extendedDatabase.Add(new Person(123456, "Vasil"));
            var resul = 2;
            Assert.AreEqual(extendedDatabase.Count, resul);
        }
        [Test]
        public void TestIfExistPersonWithSameId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.Add(new Person(123456789, "Vasil"));
            });
        }
        [Test]
        public void TestIfExistPersonWithSameName()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.Add(new Person(12345678, "Ivan"));
            });
        }
        [Test]
        public void TestIfAddRangeLenghtIsEqualTo16()
        {
            for (int i = 1; i < 16; i++)
            {
                this.extendedDatabase.Add(new Person(i, i.ToString()));
            }
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.extendedDatabase.Add(new Person(12345679, "kalata"));
            });
        }
        [Test]
        public void TestRemovePeople()
        {
            extendedDatabase.Remove();

            var result = 0;

            Assert.AreEqual(extendedDatabase.Count, result);
        }
        [Test]
        public void RemoveEmptyPeople()
        {
            extendedDatabase.Remove();
            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.Remove();
            });
        }
        [Test]
        public void TestFindPersonByUsername()
        {
            string Username = "Ivan";
            Assert.AreEqual(extendedDatabase.FindByUsername(Username), person);
        }
        [Test]
        public void TestIfFindbyUserNameIsNUll()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                extendedDatabase.FindByUsername("");
            });
        }
        [Test]
        public void TestIfFindbyUserNameByWrongName()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.FindByUsername("Stakata");
            });
        }
        [Test]
        public void TestFindById()
        {
            long id = 123456789;
            Assert.AreEqual(extendedDatabase.FindById(id), person);
        }
        [Test]
        public void TestFindByWrongId()
        {
            Assert.Throws<InvalidOperationException>(() =>
            extendedDatabase.FindById(12));
        }
        [Test]
        public void TestFindByNegativeId()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            extendedDatabase.FindById(-1));
        }
    }
