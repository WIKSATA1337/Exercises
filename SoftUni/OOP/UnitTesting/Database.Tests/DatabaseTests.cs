namespace Database.Tests
{
    using Microsoft.VisualStudio.TestPlatform.ObjectModel;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]
        public void Setup()
        {
            db = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
        }

        [Test]
        public void OnInitializeShouldHaveLength16()
        {
            int expectedSize = 16;

            Assert.AreEqual(expectedSize, db.Count);
        }

        [Test]
        public void AddShouldThrowErrorOn17thElement()
        {
            Assert.Throws<InvalidOperationException>( () =>
            {
                db.Add(17);
            });
        }

        [Test]
        public void AddShouldWorkCorrectlyOnEmptyDatabase()
        {
            db = new Database();

            int addNumber = 5;
            int expectedCount = 1;

            db.Add(addNumber);

            Assert.AreEqual(expectedCount, db.Count);
            Assert.AreEqual(db.Fetch()[0], addNumber);
        }

        [Test]
        public void AddMultipleElementsShouldWork()
        {
            db = new Database();

            int addFirstNumber = 5;
            int addSecondNumber = 55;
            int expectedCount = 2;

            db.Add(addFirstNumber);
            db.Add(addSecondNumber);

            var fetchedDatabase = db.Fetch();

            Assert.AreEqual(expectedCount, db.Count);
            Assert.AreEqual(fetchedDatabase[0], addFirstNumber);
            Assert.AreEqual(fetchedDatabase[1], addSecondNumber);
        }

        [Test]
        public void RemoveShouldThrowExceptionOnEmptyDatabase()
        {
            db = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            });
        }

        [Test]
        public void RemoveShouldRemoveFromEndLikeStack()
        {
            var result = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            db.Remove();

            Assert.AreEqual(result, db.Fetch());
        }

        [Test]
        public void FetchShouldReturnCorrectlyElements()
        {
            var result = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            db = new Database(1, 2, 3, 4, 5, 6, 7, 8);

            Assert.AreEqual(result, db.Fetch());
        }
    }
}
