using System;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Ctor_AddsWarriorsToArena()
        {
           Assert.That(arena.Warriors, Is.Not.Null);
        }

        [Test]
        public void Count_ConfirmThatInitialValueIsZero()
        {
            Assert.That(arena.Count, Is.EqualTo(0));
        }

        [Test]
        public void Count_IncreaseOrDecreaseArenaCounter()
        {
            arena.Enroll(new Warrior("Pesho", 10, 50));
            Assert.That(arena.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Enroll_ThrowsException_WhenTryingToEnrollExistedWarrior()
        {
            arena.Enroll(new Warrior("Pesho", 10, 50));
            Assert.Throws<InvalidOperationException>(() =>  arena.Enroll(new Warrior("Pesho", 15, 55)));
        }

        [Test]
        public void Enroll_AddsWarriorIfNameIsValidToTheArena()
        {
            Warrior warrior = new Warrior("Pesho", 10, 50);

            arena.Enroll(warrior);

            Assert.That(arena.Warriors, Contains.Item(warrior));
        }

        [Test]
        public void Fight_ThrowsException_WhenAttackerNameIsNotEnrolledToTheArena()
        {
            Warrior attacker = new Warrior("Pesho", 10, 50);
            Warrior defender = new Warrior("Gosho", 10, 50);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Pesho", "Misho"));
        }

        [Test]
        public void Fight_ThrowsException_WhenDefenderNameIsNotEnrolledToTheArena()
        {
            Warrior attacker = new Warrior("Pesho", 10, 50);
            Warrior defender = new Warrior("Gosho", 10, 50);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => arena.Fight( "Misho", "Pesho"));
        }

        [Test]
        public void Fight_FightersAreLoosingHp()
        {
            int initialHp = 50;
            Warrior attacker = new Warrior("Pesho", 10, initialHp);
            Warrior defender = new Warrior("Gosho", 10, initialHp);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight("Pesho", "Gosho");

            Assert.That(defender.HP, Is.LessThan(initialHp));
            Assert.That(attacker.HP, Is.LessThan(initialHp));
        }
    }
}
