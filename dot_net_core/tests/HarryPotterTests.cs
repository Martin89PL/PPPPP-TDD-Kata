using NUnit.Framework;
using katas;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SameBook8EuroEach()
        {
            HarryPotter hp = new HarryPotter();
            var books = new Books[] {Books.Stone, Books.Stone, Books.Stone};
            Assert.AreEqual(24, hp.GetPrice(books));
        }

        [Test]
        public void TwoDifferentBooks5PercentDiscount()
        {
            HarryPotter hp = new HarryPotter();
            var books = new Books[] {Books.Stone, Books.Chamber};
            Assert.AreEqual(15.2, hp.GetPrice(books));
        }

        [Test]
        public void ThreeDifferentBooks10PercentDiscount()
        {
            HarryPotter hp = new HarryPotter();
            var books = new Books[] {Books.Stone, Books.Chamber, Books.Prisoner};
            Assert.AreEqual(21.6, hp.GetPrice(books));
        }

        [Test]
        public void FourDifferentBooks20PercentDiscount()
        {
            HarryPotter hp = new HarryPotter();
            var books = new Books[] {Books.Stone, Books.Chamber, Books.Prisoner, Books.Goblet};
            Assert.AreEqual(25.6, hp.GetPrice(books));
        }

        [Test]
        public void FiveDifferentBooks25PercentDiscount()
        {
            HarryPotter hp = new HarryPotter();
            var books = new Books[] {Books.Stone, Books.Chamber, Books.Prisoner, Books.Goblet, Books.Phoenix};
            Assert.AreEqual(30, hp.GetPrice(books));
        }

        [Test]
        public void LastStep()
        {
            HarryPotter hp = new HarryPotter();
            var books = new Books[] {Books.Stone, Books.Stone, Books.Chamber, Books.Chamber, Books.Prisoner, Books.Prisoner, Books.Goblet, Books.Phoenix};
            Assert.AreEqual(51.6, hp.GetPrice(books));
        }
    }
}
