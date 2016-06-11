using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Task6
{
    public static class TasksExample
    {
        public static void Run()
        {
            var random = new Random();
                      
            var xs = new IWerkzeugmaschine[] {
                new Drehmaschine(1, 4),
                new Drehmaschine(2, 4),
                new Fraesmaschine(3, 4),
                new Fraesmaschine(4, 4)
            };

            StaticDemoClass.ExecuteActionOnAllWerkzeugmaschinen(xs, StaticDemoClass.WerkzeugmaschineAufruesten);

            var tasks = new List<Task<string>>();
            foreach (var x in xs)
            {
                var task = Task.Run(() =>
                {
                    WriteLine($"{x.GetType().ToString()} {x.ID} - Aufruestung Beginn");
                    return x.WerkzeugLangsamAufruesten(1, $"Werkzeug_{x.ID}");
                });

                tasks.Add(task);
            }
            
            var tasks2 = new List<Task<string>>();
            foreach (var task in tasks.ToArray())
            {
                tasks2.Add(
                    task.ContinueWith(t => { WriteLine($"{t.Result}"); return t.Result; })
                );
            }

            var cts = new CancellationTokenSource();

            var kuehlungTask = Kuehlen(xs, cts.Token);

            ReadLine();

            if (kuehlungTask.IsCompleted)
            {
                WriteLine("Alle Maschinen gekuehlt.");
                return;
            }

            cts.Cancel();
            WriteLine("Kuehlung unterbrochen!");
            ReadLine();
        }

        public static Task<bool> MaschineKuehlen(CancellationToken ct)
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(500);
                    ct.ThrowIfCancellationRequested();
                }
                return true;
            }, ct);
        }

        public static async Task Kuehlen(IWerkzeugmaschine[] xs, CancellationToken ct)
        {
            foreach(var x in xs)
            { 
                ct.ThrowIfCancellationRequested();
                if (await MaschineKuehlen(ct)) WriteLine($"Maschine {x.ID} wird gekuehlt...");
            }
        }
    }
}
