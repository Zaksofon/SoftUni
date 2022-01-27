using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computerManager;

        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
        }

        [Test]
        public void AddComputer_ThrowsExceptionWhenTryingYoAddExistingComputer()
        {
            computerManager.AddComputer(new Computer("Lenovo", "Thinkpad", 1000));
            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(new Computer("Lenovo", "Thinkpad", 1650)));
        }

        [Test]
        public void Count_ItemsCounterExceedsWhenAddingNewComputer()
        {
            computerManager.AddComputer(new Computer("Lenovo", "Thinkpad", 1650));
            Assert.That(computerManager.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Count_ExceedsNumberOfItemsInTheSequence()
        {
            Computer computer = new Computer("Lenovo", "Thinkpad", 1650);
            computerManager.AddComputer(computer);
            Assert.That(computerManager.Computers.Count, Is.GreaterThan(0));
        }

        [Test]
        public void RemoveComputer_RemovesComputerFromTheSecuence()
        {
            var computer = new Computer("Lenovo", "Thinkpad", 1650);
            computerManager.AddComputer(new Computer("Lenovo", "Thinkpad", 1650));
            computerManager.RemoveComputer("Lenovo", "Thinkpad");
            Assert.That(computerManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetComputer_ThrowsExceptionWhenComputerValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(null, null));
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer("Test", null));
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(null, "Test"));
        }

        [Test]
        public void GetComputer_ThrowsExceptionIfComputerIsNotExist()
        {
            var computer = new Computer("Lenovo", "Thinkpad", 1650);
            computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("Test", "Test"));
        }

        [Test]
        public void GetComputersByManufacturer_SelectComputersByManufacturers()
        {
            var computer = new Computer("Lenovo", "Thinkpad", 1650);
            computerManager.AddComputer(computer);

            var selection = computerManager.GetComputersByManufacturer("Lenovo");

            Assert.That(selection.Contains(computer));
        }
    }
}