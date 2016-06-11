using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace Task6
{
    public static class PullExample
    {
        public static void Run()
        {
            WriteLine("enumerables: foreach (array)");
            IEnumerable<IWerkzeugmaschine> xs = new IWerkzeugmaschine[] {
                new Drehmaschine(1, 4),
                new Drehmaschine(2, 4),
                new Fraesmaschine(3, 4),
                new Fraesmaschine(4, 4)
            };

            foreach (var x in xs) WriteLine($"{x.GetType().ToString()} {x.ID}"); WriteLine();

            WriteLine("\nenumerables: foreach (list)");
            xs = new List<IWerkzeugmaschine> {
                new Drehmaschine(5, 4),
                new Drehmaschine(6, 4),
                new Fraesmaschine(7, 4),
                new Fraesmaschine(8, 4)
            };

            foreach (var x in xs) WriteLine($"{x.GetType().ToString()} {x.ID} Magazingroesse = {x.MagazinGroesse}"); 

            WriteLine("\nenumerables: behind the scenes");
            var e = xs.GetEnumerator();
            while (e.MoveNext()) Write(e.Current + " "); WriteLine();

            WriteLine("\nenumerables: queries (filter) - Where(x => x is Drehmaschine)");
            var ys = xs.Where(x => x is Drehmaschine);
            foreach (var y in ys) WriteLine($"{y.GetType().ToString()} {y.ID} Magazingroesse = {y.MagazinGroesse}"); 

            WriteLine("\nenumerables: queries (map) - Select(x => new Drehmaschine(x.ID * 2, x.MagazinGroesse + 1)");
            ys = xs.Select(x => new Drehmaschine(x.ID * 2, x.MagazinGroesse + 1));            
            foreach (var y in ys) WriteLine($"{y.GetType().ToString()} {y.ID} Magazingroesse = {y.MagazinGroesse}");
        }
    }
}
