using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace katas
{
    public class GameOfLife
    {
        public string NextGen(string currentGenerationRepresentation)
        {
            var currentGeneration = new Generation(currentGenerationRepresentation);
            var newGeneration = new Generation(currentGenerationRepresentation);

            for (int i = 0; i < currentGeneration.RowCount; i++)
            {
                for (int j = 0; j < currentGeneration.ColCount; j++)
                {
                    var cell = new Coordinates(i, j);
                    var neighbourSituation = this.GetNeighbourSituation(currentGeneration, cell);

                    if (currentGeneration[cell] == '*' && (neighbourSituation.Alive > 3 || neighbourSituation.Alive < 2))
                    {
                        newGeneration[cell] = '.';
                    }

                    if (currentGeneration[cell] == '.' && neighbourSituation.Alive == 3) {
                        newGeneration[cell] = '*';
                    }
                }
            }

            return newGeneration.ToString();
        }

        private NeighbourSituation GetNeighbourSituation(Generation generation, Coordinates coordinates)
        {
            char[] neighbours = {
                generation.Get(new Coordinates(coordinates.X - 1, coordinates.Y - 1)),
                generation.Get(new Coordinates(coordinates.X - 1, coordinates.Y)),
                generation.Get(new Coordinates(coordinates.X - 1, coordinates.Y + 1)),
                generation.Get(new Coordinates(coordinates.X, coordinates.Y - 1)),
                generation.Get(new Coordinates(coordinates.X, coordinates.Y + 1)),
                generation.Get(new Coordinates(coordinates.X + 1, coordinates.Y - 1)),
                generation.Get(new Coordinates(coordinates.X + 1, coordinates.Y)),
                generation.Get(new Coordinates(coordinates.X + 1, coordinates.Y + 1)),
            };
            var situation = new NeighbourSituation();

            situation.Alive = neighbours.Count(neighbour => neighbour == '*');
            situation.Dead = neighbours.Count(neighbour => neighbour == '.');

            return situation;
        }
    }

    // internal struct NeighbourSituation
    // {

    // }

    internal class NeighbourSituation
    {
        public int Alive { get; set; } = 0;
        public int Dead { get; set; } = 0;
    }

    internal class Coordinates : Tuple<int, int>
    {
        public Coordinates(int item1, int item2) : base(item1, item2)
        {
        }

        public int X { get { return this.Item1; } }
        public int Y { get { return this.Item2; } }
    }

    internal class Generation : Dictionary<Coordinates, char>
    {
        public Generation(string currentGeneration) : base()
        {
            string[] rows = currentGeneration.Split('\n');

            RowCount = rows.Length;
            ColCount = rows[0].Length;

            int rowIndex = 0;
            int colIndex = 0;
            foreach (var row in rows)
            {
                colIndex = 0;
                foreach (char col in row)
                {
                    this.Add(new Coordinates(rowIndex, colIndex), col);
                    colIndex++;
                }
                rowIndex++;
            }
        }

        public int RowCount { get; private set; }
        public int ColCount { get; private set; }

        public new string ToString()
        {
            var rows = new List<string>();
            for (int i = 0; i < RowCount; i++)
            {
                var builder = new StringBuilder();
                for (int j = 0; j < ColCount; j++)
                {
                    builder.Append(this[new Coordinates(i, j)]);
                }
                rows.Add(builder.ToString());
            }

            return String.Join("\n", rows);
        }

        internal char Get(Coordinates coordinates)
        {
            char value = '-';
            this.TryGetValue(coordinates, out value);

            return value;
        }
    }
}
