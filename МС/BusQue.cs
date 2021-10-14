using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace МС
{
    public class BusQue
    {
        int totalSend = 0;
        int total = 0;
        double persentOfLoss = 0.0;
        Queue<Process> queue;
        int queueDelay = 5;
        int TransportAbillity { get; set; }
        int TransportDelay { get; set; } = 2;
        int IterationNomber = 0;
        public List<Iteration> statistic = new List<Iteration>();
   
        public void getQueue(Process p1, Process p2, Process p3)
        {
            queue.Enqueue((Process)p1.Clone());
            queue.Enqueue((Process)p2.Clone());
            queue.Enqueue((Process)p3.Clone());
        }      
        public void Send()
        {
            Iteration iteration = new Iteration();
            int sendlSize = 0;
            int freeMemory = TransportAbillity;
            while ((queue.Count() > 0 && (queue.Peek().PoketSize <= freeMemory) ))
            {
                var element = queue.Dequeue();
                sendlSize += element.PoketSize;
                freeMemory -= element.PoketSize;

                iteration.dictionary.Add(element,true);
                iteration.nomber = IterationNomber;
                iteration.workload = ((0.0 + sendlSize) / TransportAbillity * 100);
            }

            foreach(var el in queue)
            {
                el.delay += queueDelay;
            }

            statistic.Add(iteration);
            IterationNomber++;
            
            //Подсчет общей статистики

            totalSend += sendlSize;
            persentOfLoss = (100 - (0.0 + totalSend) / total * 100);
            
        }
        public BusQue(int TA)
        {
            TransportAbillity = TA;
            queue = new Queue<Process>();
        }
    }
}
