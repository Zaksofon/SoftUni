using System;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        [TestCase("", 10, 50)]
        [TestCase(" ", 10, 50)]
        [TestCase(null, 10, 50)]
        [TestCase("Warrior", 0, 50)]
        [TestCase("Warrior", -10, 50)]
        [TestCase("Warrior", 10, -50)]
        public void Ctor_ThrowsException_WhenArgumentsAreInvalid(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("Gosho", 10, 30)]
        [TestCase("Gosho", 10, 25)]
        public void Attack_ThrowsException_WhenWarriorHpAreInvalid(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);
            Warrior enemy = new Warrior("Pesho", 10, 50);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
        }

        [Test]
        [TestCase("Gosho", 10, 30)]
        [TestCase("Gosho", 10, 25)]
        public void Attack_ThrowsException_WhenEnemyHpAreInvalid(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);
            Warrior enemy = new Warrior("Pesho", 10, 50);
            Assert.Throws<InvalidOperationException>(() => enemy.Attack(warrior));
        }


        [Test]
        [TestCase("Gosho", 10, 40)]
        public void Attack_ThrowsException_WhenEnemyIsTooStrong(string name, int damage, int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);
            Warrior enemy = new Warrior("Pesho", 50, 50);
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy));
        }

        [Test]
        public void Attack_ReducingWarriorHpWhenEnemyAttacksAndHpAreValid()
        {
            Warrior enemy = new Warrior("Gosho", 20, 40);
            Warrior warrior = new Warrior("Pesho", 20, 50);
            int warriorInitialHp = warrior.HP;
            enemy.Attack(warrior);
            Assert.That(warrior.HP, Is.LessThan(warriorInitialHp));
        }

        [Test]
        public void Attack_SetsEnemyHpToZero_WhenWarriorsDamageIsGreaterThanEnemyHp()
        {
            Warrior enemy = new Warrior("Gosho", 20, 40);
            Warrior warrior = new Warrior("Pesho", 50, 50);
            int warriorInitialHp = warrior.HP;
            warrior.Attack(enemy);
            Assert.That(enemy.HP, Is.EqualTo(0));
        }

        [Test]
        public void Attack_ReducingEnemyHpWhenWarriorAttacksAndHpAreValid()
        {
            Warrior enemy = new Warrior("Gosho", 20, 40);
            Warrior warrior = new Warrior("Pesho", 20, 50);
            int enemyInitialHp = enemy.HP;
            enemy.Attack(warrior);
            Assert.That(enemy.HP, Is.LessThan(enemyInitialHp));
        }
    }
}