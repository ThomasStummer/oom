using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Task6
{
    public static class PushExampleWithSubject
    {
        public static void Run()
        {
            var source = new Subject<IWerkzeugmaschine>();

            source
                .Sample(TimeSpan.FromSeconds(1.1))
                .Subscribe(x => WriteLine($"...received {x.GetType()} {x.ID}"))
                ;

            var t = new Thread(() =>
            {
                var i = 0;
                while (true)
                {
                    Thread.Sleep(333);
                    source.OnNext(new Drehmaschine(i, 2));
                    WriteLine($"sent Maschine {i++}...");
                }
            });
            t.Start();
        }
    }
}
