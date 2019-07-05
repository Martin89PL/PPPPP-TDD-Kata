using NUnit.Framework;
using katas;

namespace Tests
{
    public class GameOfLifeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CellWithFewerNeighboursThan2Dies() {
            string currentGeneration =
                @"........
........
......*.
........";
            string expectedGeneration =
                @"........
........
........
........";

            GameOfLife gof = new GameOfLife();

            Assert.AreEqual(expectedGeneration, gof.NextGen(currentGeneration));
        }

        [Test]
        public void CellWithMoreThan3NeighboursDies_TheOneInTheMiddle() {
            string currentGeneration =
                @"........
...*.*..
....*...
...*.*..";
            string expectedGeneration =
                @"........
....*...
...*.*..
....*...";

            GameOfLife gof = new GameOfLife();

            Assert.AreEqual(expectedGeneration, gof.NextGen(currentGeneration));
        }

        [Test]
        public void LiveCellWith2Or3NeighboursLives_TheOnesThatHaveMoreThanOneDiagonalNeighbour() {
            string currentGeneration =
                @"........
*.*..*..
.*..*...
..*..*..";
            string expectedGeneration =
                @"........
.*......
.*****..
........";

            GameOfLife gof = new GameOfLife();

            Assert.AreEqual(expectedGeneration, gof.NextGen(currentGeneration));
        }

        [Test]
        public void DeadCellWith3NeighboursComesToLife() {
            string currentGeneration =
                @"........
..*.....
..**....
........";
            string expectedGeneration =
                @"........
..**....
..**....
........";

            GameOfLife gof = new GameOfLife();

            Assert.AreEqual(expectedGeneration, gof.NextGen(currentGeneration));
        }

        [Test]
        public void TestCaseFromTheKata() {
                string currentGeneration = @"........
....*...
...**...
........";

                string expectedGeneration = @"........
...**...
...**...
........";

            GameOfLife gof = new GameOfLife();

            Assert.AreEqual(expectedGeneration, gof.NextGen(currentGeneration));
        }
    }
}
