
using System;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;
        
        [SetUp]
        public void Setup()
        {
            this.database = new Database();
        }

        [Test]
        public void Add_ThrowException_WhenCapacityExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void Add_IncreasingDatabaseCount_WhenOperationIsValid()
        {
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }
            
            Assert.That(database.Count, Is.EqualTo(n));
        }

        [Test]
        public void Add_AddsElementToTheDatabase()
        {
            int element = 123;
            database.Add(element);
            int[] array = database.Fetch();
            Assert.That(array.Contains(element));
        }

        [Test]
        public void Remove_ThrowException_WhenDatabaseIsZero()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_WhenRemoveIsValidOperation()
        {
            int n = 10;

            for (int i = 0; i < n; i++)
            {
                database.Add(i);
            }

            database.Remove();
            Assert.That(database.Count, Is.EqualTo(n - 1));
        }

        [Test]
        public void Remove_DecreasesElementsFromTheDatabase()
        {
            database.Add(1);
            database.Add(2);
            database.Add(666);

            database.Remove();
            int[] array = database.Fetch();

            Assert.IsFalse(array.Contains(666));
        }

        [Test]
        public void Fetch_CloneDatabase()
        {
            database.Add(1);
            database.Add(5);

            int[] firstClone = database.Fetch();

            database.Add(666);
            int[] secondClone = database.Fetch();
            
            Assert.That(firstClone, Is.Not.EqualTo(secondClone));
        }

        [Test]
        public void Count_ReturnsZeroWhenDatabaseIsEmpty()
        {
            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_ThrowsExceptionWhenDatabaseCapacityIsExceeded()
        {
            int[] array = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16};

            for (int i = 0; i < array.Length; i++)
            {
                database.Add(i);
            }
          
            Assert.Throws<InvalidOperationException>(() => database.Add(666));
        }

        [Test]
        public void Ctor_AddsElementsToDatabase()
        {
            int[] array = new[] {1, 2, 3};

            database = new Database(array);
            Assert.That(database.Count, Is.EqualTo(array.Length));
            Assert.That(database.Fetch(), Is.EquivalentTo(array));
        }
    }
}