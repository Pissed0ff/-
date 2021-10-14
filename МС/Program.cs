using System;

namespace МС
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Process(50, "Main");
            var p2 = new Process(51, "One");
            var p3 = new Process(52, "Two");

            var bus = new BusQue(2000);
            var bus2 = new Bus(2000);
            //withQueue(bus,p1,p2,p3);
            withoutQueue(bus2, p1, p2, p3);

        }

        static void withQueue(BusQue bus, Process p1, Process p2, Process p3)
        {
            for (int i = 0; i < 100; i++)
            {
                bus.getQueue(p1, p2, p3);
                bus.Send();

                p1.next();
                p2.next();
                p3.next();

            }
            int count = 0;
            double totalWorkLoad = 0;
            int totalDelay = 0;
            int outOfRangeDelay = 0;
            foreach (var el in bus.statistic)
            {
                foreach (var process in el.dictionary)
                {
                    if (process.Key.name == "Main")
                    {

                        if (process.Key.delay <= 20)
                        {
                            count++;
                            totalDelay += process.Key.delay;
                        }

                        if (process.Key.delay > 20)
                        {
                            outOfRangeDelay++;
                        }
                    }

                }
                totalWorkLoad += el.workload;
            }
            double everageDelay = (0.0 + totalDelay) / count;
            double everageWorkload = totalWorkLoad / count;
        }

        static void withoutQueue(Bus bus, Process p1, Process p2, Process p3)
        {
            for (int i = 0; i < 100; i++)
            {
                bus.Send(p1, p2, p3);
                p1.next();
                p2.next();
                p3.next();
            }
        }
    }
}
