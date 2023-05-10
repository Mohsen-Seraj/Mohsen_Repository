using System;
using System.Linq;

namespace ex1
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] cities = { "ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS" };


            #region Sorting with LINQ

            //Sorting with LINQ
            Console.WriteLine("Sorting with LINQ");
            Console.WriteLine("Here is the arranged list :");

            var SortLINQ = cities.OrderBy(c => c.Length).ThenBy(c => c);

            foreach (var c in SortLINQ)
            {
                Console.WriteLine(c);
            }
            #endregion


            Console.WriteLine("-------------------------------------");


            #region Sorting Without LINQ
            //Sorting Without LINQ
            Console.WriteLine("Sorting Without LINQ");
            Console.WriteLine("Here is the arranged list :");

            Array.Sort(cities, (x, y) =>
            {
                int Compare = x.Length.CompareTo(y.Length);

                return  Compare != 0? Compare: x.CompareTo(y);

                //if (Compare != 0)
                //{
                //    return Compare;
                //}
                //else
                //{
                //    return x.CompareTo(y);
                //}

            });

            foreach (string c in cities)
            {
                Console.WriteLine(c);
            }

            #endregion 


            Console.ReadKey();
        }
    }
    }

