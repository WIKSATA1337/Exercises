namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp] 
        public void SetUp() 
        { 
            arena = new Arena();
        }

        [Test]
        public void Count_ShouldBeZeroOnInitialize()
        {
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void Enroll_ShouldWorkCorrectly()
        {
            Warrior warrior = new Warrior("Hektor", 15, 105);
            int expectedCount = 1;

            arena.Enroll(warrior);

            Assert.AreEqual(expectedCount, arena.Count);
            Assert.AreEqual(warrior, arena.Warriors.First());
        }

        [Test]
        public void EnrollMultipleWarriors_ShouldWorkCorrectly()
        {
            Warrior warrior = new Warrior("Hektor", 15, 105);
            Warrior warriorTwo = new Warrior("Minotaur", 41, 147);
            int expectedCount = 2;

            arena.Enroll(warrior);
            arena.Enroll(warriorTwo);

            Assert.AreEqual(expectedCount, arena.Count);
            Assert.IsTrue(arena.Warriors.Contains(warrior));
            Assert.IsTrue(arena.Warriors.Contains(warriorTwo));
        }

        [Test]
        public void Enroll_ShouldThrowException_OnExistingWarriorName()
        {
            Warrior warrior = new Warrior("Hektor", 15, 105);
            Warrior existingWarriorNameWarrior = new Warrior("Hektor", 7, 86);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(existingWarriorNameWarrior);
            });
        }

        [Test]
        public void Fight_ShouldThrowException_OnNonExistingWarrior()
        {
            Warrior existingWarrior = new Warrior("Hektor", 15, 105);
            Warrior nonExistingWarrior = new Warrior("Wayne", 2, 49);
            string existingWarriorName = existingWarrior.Name;
            string nonExistingWarriorName = nonExistingWarrior.Name;

            arena.Enroll(existingWarrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(existingWarriorName, nonExistingWarriorName);
            });
        }

        [Test]
        public void Fight_ShouldWorkCorrectly()
        {
            Warrior existingWarriorOne = new Warrior("Hektor", 15, 105);
            Warrior existingWarriorTwo = new Warrior("Wayne", 9, 74);

            string existingWarriorOneName = existingWarriorOne.Name;
            string existingWarriorTwoName = existingWarriorTwo.Name;

            int warriorOneExpectedHealth = 96;
            int warriorTwoExpectedHealth = 59;

            arena.Enroll(existingWarriorOne);
            arena.Enroll(existingWarriorTwo);

            arena.Fight(existingWarriorOneName, existingWarriorTwoName);

            Assert.AreEqual(warriorOneExpectedHealth, existingWarriorOne.HP);
            Assert.AreEqual(warriorTwoExpectedHealth, existingWarriorTwo.HP);
        }
    }
}
