namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database db;

        [SetUp]
        public void Setup()
        {
            db = new Database(new Person(1, "Ivan"),
                new Person(2, "Petar"),
                new Person(3, "Maria"),
                new Person(4, "Georgi"),
                new Person(5, "Slash"),
                new Person(6, "Nikolay"),
                new Person(7, "Teodor"),
                new Person(8, "Spas"),
                new Person(9, "Ivaylo"),
                new Person(10, "Martin"),
                new Person(11, "Dimitar"),
                new Person(12, "Boian"),
                new Person(13, "Polq"),
                new Person(14, "Ivanina"),
                new Person(15, "Emil"),
                new Person(16, "Elise"));
        }

        [Test]
        public void Initializing_ShouldWorkProperly()
        {
            int expectedCount = 16;

            db = new Database(new Person(1, "Ivan"),
                new Person(2, "Petar"),
                new Person(3, "Maria"),
                new Person(4, "Georgi"),
                new Person(5, "Slash"),
                new Person(6, "Nikolay"),
                new Person(7, "Teodor"),
                new Person(8, "Spas"),
                new Person(9, "Ivaylo"),
                new Person(10, "Martin"),
                new Person(11, "Dimitar"),
                new Person(12, "Boian"),
                new Person(13, "Polq"),
                new Person(14, "Ivanina"),
                new Person(15, "Emil"),
                new Person(16, "Elise"));

            Assert.AreEqual(expectedCount, db.Count);
        }

        [Test]
        public void Initializing_ShouldThrowException_OnMoreThan16Elements()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                db = new Database(new Person(1, "Ivan"),
                new Person(2, "Petar"),
                new Person(3, "Maria"),
                new Person(4, "Georgi"),
                new Person(5, "Slash"),
                new Person(6, "Nikolay"),
                new Person(7, "Teodor"),
                new Person(8, "Spas"),
                new Person(9, "Ivaylo"),
                new Person(10, "Martin"),
                new Person(11, "Dimitar"),
                new Person(12, "Boian"),
                new Person(13, "Polq"),
                new Person(14, "Ivanina"),
                new Person(15, "Emil"),
                new Person(16, "Elise"),
                new Person(17, "Mario"));
            });
        }

        [Test]
        public void Add_ShouldThrowException_WhenAddingMoreThan16Elements()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(17, "Mario"));
            });
        }

        [Test]
        public void Add_ShouldThrowException_WhenAddingUserWithExistingUsername()
        {
            db.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(16, "Nikolay"));
            });
        }

        [Test]
        public void Add_ShouldThrowException_WhenAddingUserWithExistingId()
        {
            db.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(new Person(6, "Mario"));
            });
        }

        [Test]
        public void Add_ShouldWorkCorrectly()
        {
            int expectedCount = 16;

            db.Remove();

            db.Add(new Person(16, "Poppahns"));

            Assert.AreEqual(expectedCount, db.Count);
        }

        [Test]
        public void Remove_ShouldThrowException_OnEmptyCollection()
        {
            db = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            });
        }

        [Test]
        public void Remove_ShouldWorkCorrectly_AndRemoveFromTheBackLikeStack()
        {
            db.Remove();
            int expectedCount = 15;

            Assert.AreEqual(expectedCount, db.Count);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindById(16);
            });
        }

        [Test]
        public void FindByUsername_ShouldThrowException_OnNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                db.FindByUsername(null);
            });
        }

        [Test]
        public void FindByUsername_ShouldThrowException_OnEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                db.FindByUsername("");
            });
        }

        [Test]
        public void FindByUsername_ShouldThrowException_OnNonExistingUsername()
        {
            string nonExistingUsername = "0n89N86b6976b09769d";

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindByUsername(nonExistingUsername);
            });
        }

        [Test]
        public void FindByUsername_ShouldWorkCorrectly()
        {
            string existingUsername = "Nikolay";
            long existingId = 6;

            Person foundPerson = db.FindByUsername(existingUsername);

            Assert.AreEqual(existingId, foundPerson.Id);
            Assert.AreEqual(existingUsername, foundPerson.UserName);
        }

        [Test]
        public void FindById_ShouldThrowException_OnNegativeId()
        {
            long negativeId = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                db.FindById(negativeId);
            });
        }

        [Test]
        public void FindById_ShouldThrowException_OnNonExistingId()
        {
            long nonExistingId = 51038;

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.FindById(nonExistingId);
            });
        }

        [Test]
        public void FindById_ShouldWorkCorrectly()
        {
            long existingId = 6;
            string existingIdUsername = "Nikolay";

            Person foundPerson = db.FindById(existingId);

            Assert.AreEqual(existingId, foundPerson.Id);
            Assert.AreEqual(existingIdUsername, foundPerson.UserName);
        }
    }
}