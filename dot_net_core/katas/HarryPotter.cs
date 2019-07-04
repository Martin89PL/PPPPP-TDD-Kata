using System;
using System.Collections.Generic;
using System.Linq;

namespace katas
{
    public enum Books { Stone, Chamber, Prisoner, Goblet, Phoenix, Prince, Hallows };
    public class HarryPotter
    {
        public double GetPrice(Books[] cart)
        {
            var byBookType = this.CountByBookType(cart);

            if (byBookType.Keys.Count == 1)
            {
                return cart.Length * 8;
            }

            var bookSets = this.GetUniqueBookSets(byBookType);

            return bookSets.Select(this.GetSetPrice).Sum();
        }

        private double GetSetPrice(int uniqueBooksCount)
        {
            if (uniqueBooksCount == 1)
            {
                return 8;
            }

            if (uniqueBooksCount == 2)
            {
                return uniqueBooksCount * 8 * 0.95;
            }

            if (uniqueBooksCount == 3)
            {
                return uniqueBooksCount * 8 * 0.9;
            }

            if (uniqueBooksCount == 4)
            {
                return uniqueBooksCount * 8 * 0.8;
            }

            if (uniqueBooksCount == 5)
            {
                return uniqueBooksCount * 8 * 0.75;
            }

            throw new NotImplementedException();
        }
        private int[] GetUniqueBookSets(Dictionary<Books, int> byBookType)
        {
            List<int> sets = new List<int>();
            while (byBookType.Values.Sum() != 0)
            {
                int setLength = 0;
                var keys = new List<Books>(byBookType.Keys);
                foreach (var item in keys)
                {
                    int bookCount = byBookType[item];
                    if (bookCount != 0)
                    {
                        setLength += 1;
                        byBookType[item] = bookCount - 1;
                    }
                }
                sets.Add(setLength);
            }

            return sets.ToArray();
        }

        private Dictionary<Books, int> CountByBookType(Books[] cart)
        {
            return cart.Aggregate(new Dictionary<Books, int>(), (accu, next) =>
            {
                if (accu.ContainsKey(next))
                {
                    var incremented = accu[next] + 1;
                    accu.Remove(next);
                    accu.Add(next, incremented);
                    return accu;
                }

                accu.Add(next, 1);
                return accu;
            });
        }
    }
}
