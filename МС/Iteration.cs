using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace МС
{
    public class Iteration
    {
        public int nomber { get; set; }
        public double workload { get; set; }
        public int delay { get; set; }
        public double loss { get; set; }

        public Dictionary<Process, bool> dictionary;

        public Iteration(int n, double w, int d, double l, Dictionary<Process, bool> dic)
        {
            nomber = n;
            workload = w;
            delay = d;
            loss = l;
            dictionary = dic;
        }
        public Iteration()
        {

            dictionary = new Dictionary<Process, bool>();
        }
    }
}
