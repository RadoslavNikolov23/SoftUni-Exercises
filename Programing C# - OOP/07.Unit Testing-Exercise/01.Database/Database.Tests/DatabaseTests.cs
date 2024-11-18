namespace Database.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        private int[] arrayRandomUnder16;
        private int[] arrayRandomOver16;
        private int[] arrayIs16;

        [SetUp]
        public void GenerateRandomNumbers()
        {
            this.arrayRandomUnder16 = new int[Random.Shared.Next(1, 15)];
            this.arrayRandomOver16 = new int[Random.Shared.Next(16, 32)];
            this.arrayIs16 = new int[16];
        }

        [Test]
        public void InitializationOfADataBase()
        {
            Database db = new Database(this.arrayRandomUnder16);

            Assert.That(db.Count.Equals(arrayRandomUnder16.Length));
        }

        [Test]
        public void IfTheCountOfTheDataBaseIs16OrMore()
        {
            Assert.Throws<InvalidOperationException>(
                 () => new Database(this.arrayRandomOver16)
                );


        }

        [Test]
        public void IfTheConstructorsThrowsAnInputException()
        {
            object fakeArray = new object[] { 1.2, "Tom" };
            Assert.Throws<InvalidCastException>(
                () => new Database((int)fakeArray));
        }

        [Test]
        public void IfAddMethodAddAnElementIfThereAreLestThan16Elements()
        {
            Database db= new Database(this.arrayRandomUnder16);
            int elementToAdd = 15;
            db.Add(elementToAdd);
            Assert.That(db.Count, Is.EqualTo(arrayRandomUnder16.Length+1));
        }

        [Test]
        public void IfAddMethodWillThrowExceptionWhenAddOver16Elements()
        {
            Database db = new Database(this.arrayIs16);
            int elementToAdd = 15;

            Assert.Throws<InvalidOperationException>(
                () => db.Add(elementToAdd));
        }

        [Test]
        public void IfTheRemoveMethodRemovesTheLastElement()
        {
            Database db = new Database(this.arrayRandomUnder16);
            db.Remove();
            Assert.That(db.Count, Is.EqualTo(arrayRandomUnder16.Length - 1));
        }

        [Test]
        public void IfRemoveMethodThrowsAnExceptionWhenRemovingFromEmptyDB()
        {
            Database db = new Database(this.arrayRandomUnder16);

            for (int i = 0; i < arrayRandomUnder16.Length; i++) db.Remove();
            Assert.Throws<InvalidOperationException>(
                () => db.Remove());
        }

        [Test]
        public void IfTheFletchMethodWillReturnTheELements()
        {
            Database db= new Database(this.arrayRandomUnder16);
            int[] exceptIntArray = db.Fetch();

            Assert.That(exceptIntArray.Length.Equals(db.Count));
        }


     

    }
}
