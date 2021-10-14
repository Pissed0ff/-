using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace МС
{
    public class Bus
    {
        double totalWorkLoad = 0;
        int totalSend = 0;
        int total = 0;
        int loss1 = 0;
        int loss2 = 0;
        int loss3 = 0;
        double persentOfLoss = 0.0;
        Queue<Process> queue;

        int TransportAbillity { get; set; }
        int TransportDelay { get; set; } = 5;

        int IterationNomber = 1;

        List<Iteration> statistic = new List<Iteration>();

        public void Send(Process P1, Process P2, Process P3)
        {
            int totalSize = P1.PoketSize + P2.PoketSize + P3.PoketSize;

            Dictionary<Process, bool> dictionary;
            var sendlSize = getMax(P1, P2, P3, out dictionary);
            var send = new Iteration(IterationNomber,
                ((0.0 + totalSize) / TransportAbillity * 100),
                P1.delay,
                100 - ((0.0 + sendlSize) / totalSize * 100),
                dictionary
                );

            statistic.Add(send);

            if (sendlSize != totalSize)
                Console.WriteLine(IterationNomber);

            IterationNomber++;
            //Подсчет общей статистики

            totalWorkLoad += (0.0 + sendlSize) / TransportAbillity * 100;
            total += totalSize;
            totalSend += sendlSize;
            persentOfLoss = (100 - (0.0 + totalSend) / total * 100);

            foreach(var el in dictionary)
            {
                if (el.Value == false)
                {
                    if (el.Key.name == "Main") loss1++;
                    if (el.Key.name == "One") loss2++;
                    if (el.Key.name == "Two") loss3++;
                }
            }

        }

        int getMax(Process P1, Process P2, Process P3, out Dictionary<Process, bool> dictionary)
        {
            dictionary = new Dictionary<Process, bool>();
            dictionary.Add(P1, false);
            dictionary.Add(P2, false);
            dictionary.Add(P3, false);
            int maxValue = 0;
            int value = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    value += P2.PoketSize * j;
                    for (int k = 0; k < 2; k++)
                    {
                        value = P1.PoketSize * i + P2.PoketSize * j + P3.PoketSize * k;
                        if (value > maxValue && value <= TransportAbillity)
                        {
                            maxValue = value;
                            if (i == 1) { dictionary[P1] = true; }
                            if (i == 0) { dictionary[P1] = false; }
                            if (j == 0) { dictionary[P2] = false; }
                            if (j == 1) { dictionary[P2] = true; }
                            if (k == 1) { dictionary[P3] = true; }
                            if (k == 0) { dictionary[P3] = false; }
                        }
                    }
                }
            }

            return maxValue;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Bus(int TA)
        {
            TransportAbillity = TA;
        }
    }
}
