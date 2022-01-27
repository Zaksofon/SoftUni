using System;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase extendedDatabase;

        [SetUp]
        public void Setup()
        {
            extendedDatabase = new ExtendedDatabase();
        }

        [Test]
        public void Add_ThrowExceptionWhenDatabaseCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                extendedDatabase.Add(new Person(i, $"Person {i}"));
            }

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(17, "Pesho")));
        }

        [Test]
        public void Add_ThrowsExceptionWhenSameUsernameIsAdded()
        {
            extendedDatabase.Add(new Person(1, "Pesho"));
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(2, "Pesho")));
        }

        [Test]
        public void Add_ThrowsExceptionWhenSameUserIdIsAdded()
        {
            extendedDatabase.Add(new Person(1, "Pesho"));
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(new Person(1, "Gosho")));
        }

        [Test]
        public void Add_CounterIsIncresingWhenAddingNewDataToExtendedDatabase()
        {
            extendedDatabase.Add(new Person(1, "Pesho"));
            extendedDatabase.Add(new Person(2, "Gosho"));

            int expectedCount = 2;

            Assert.That(extendedDatabase.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Remove_ThrowsExceptionWhenRemovingElementOutOfEmptyExtendedDatabase()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Remove());
        }

        [Test]
        public void Remove_DecreasesExtendedDatabaseCount()
        {
            extendedDatabase.Add(new Person(1, "Pesho"));
            extendedDatabase.Add(new Person(2, "Gosho"));
            extendedDatabase.Remove();

            int expectedCount = 1;

            Assert.That(extendedDatabase.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsername_ThrowsExceptionWhenUsernameIsNullOrEmptyString(string username)
        {
            Assert.Throws<ArgumentNullException>(() => extendedDatabase.FindByUsername(username));
        }

        [Test]
        [TestCase("Pesho")]
        public void FindByUsername_ThrowsExceptionWhenUsernameIsNonExistent(string username)
        {
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindByUsername("Gosho"));
        }

        [Test]
        public void FindByUsername_ReturnsUserWithExpectedUsernameIfUsernameIsValid()
        {
            Person person = new Person(1, "Pesho");
            extendedDatabase.Add(person);
            Assert.That(extendedDatabase.FindByUsername("Pesho"), Is.EqualTo(person));
        }

        [Test]
        [TestCase(-1)]
        public void FindById_ThrowsExceptionWhenRemovingNonExistentIdOrIdIsNegativeNumber(long Id)
        {
            extendedDatabase.Add(new Person(1, "Pesho"));

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindById(2));
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDatabase.FindById(Id));
        }

        [Test]
        public void FindById_ReturnsUserWithExpectedIdIfIdIsValid()
        {
            Person person = new Person(1, "Pesho");
            extendedDatabase.Add(person);
            Assert.That(extendedDatabase.FindById(1), Is.EqualTo(person));
        }

        [Test]
        public void Ctor_ThrowsExceptionWhenCapacityIsExceeded()
        {
            Person[] args = new Person[17];

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = new Person(i, $"Username {i}");
            }

            Assert.Throws<ArgumentException>(() => extendedDatabase = new ExtendedDatabase(args));
        }
    }
}