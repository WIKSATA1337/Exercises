namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        private string warriorName = "TestName";
        private int warriorDamage = 10;
        private int warriorHp = 100;
        private int WARRIOR_MIN_ATTACK_HP = 30;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior(warriorName, warriorDamage, warriorHp);
        }

        [Test]
        public void EnsurePropertyDataSet_OnInitialize()
        {
            Assert.AreEqual(warriorName, warrior.Name);
            Assert.AreEqual(warriorDamage, warrior.Damage);
            Assert.AreEqual(warriorHp, warrior.HP);
        }

        [Test]
        public void Name_ShouldThrowException_OnNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(null, warriorDamage, warriorHp);
            });
        }

        [Test]
        public void Name_ShouldThrowException_OnEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior("", warriorDamage, warriorHp);
            });
        }

        [Test]
        public void Name_ShouldThrowException_OnWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(" ", warriorDamage, warriorHp);
            });
        }

        [Test]
        public void Damage_ShouldThrowException_OnZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(warriorName, 0, warriorHp);
            });
        }

        [Test]
        public void Damage_ShouldThrowException_OnNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(warriorName, -1, warriorHp);
            });
        }

        [Test]
        public void Hp_ShouldThrowException_OnNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(warriorName, warriorDamage, -1);
            });
        }

        [Test]
        public void Attack_ShouldThrowException_OnWarriorLowHp()
        {
            Warrior warriorToAttack = new Warrior("OtherWarrior", 5, 50);

            warrior = new Warrior(warriorName, warriorDamage, WARRIOR_MIN_ATTACK_HP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(warriorToAttack);
            });
        }

        [Test]
        public void Attack_ShouldThrowException_OnOtherWarriorLowHp()
        {
            Warrior warriorToAttack = new Warrior("OtherWarriorLowHp", 5, 30);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(warriorToAttack);
            });
        }

        [Test]
        public void Attack_ShouldThrowException_OnAttackingStrongerWarrior()
        {
            Warrior warriorToAttack = new Warrior("StrongWarrior", 101, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(warriorToAttack);
            });
        }

        [Test]
        public void Attack_ShouldWorkCorrectly()
        {
            Warrior warriorToAttack = new Warrior("OtherWarrior", 5, 80);
            int expectedWarriorHp = 95;
            int expectedOtherWarriorHp = 70;

            warrior.Attack(warriorToAttack);

            Assert.AreEqual(expectedWarriorHp, warrior.HP);
            Assert.AreEqual(expectedOtherWarriorHp, warriorToAttack.HP);
        }

        [Test]
        public void Attack_ShouldSetEnemyHpToZero_WhenAttackingWithMoreDamageThanEnemyHealth()
        {
            int betterWarriorDamage = 55;
            warrior = new Warrior(warriorName, betterWarriorDamage, warriorHp);
            Warrior warriorToAttack = new Warrior("OtherWarrior", 1, 50);
            int expectedWarriorHp = 99;
            int expectedOtherWarriorHp = 0;

            warrior.Attack(warriorToAttack);

            Assert.AreEqual(expectedWarriorHp, warrior.HP);
            Assert.AreEqual(expectedOtherWarriorHp, warriorToAttack.HP);
        }
    }
}