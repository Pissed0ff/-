using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace МС
{
    public class Process: ICloneable
    {
        public string name { get; set; }
        public int PoketSize { get; set; }
        static Random rand;
        public int delay { get; set; } = 5;
        public void next()
        {
            PoketSize = rand.Next(100, 1000);
        }

        public object Clone()
        {
            return new Process() { delay = this.delay, PoketSize = this.PoketSize, name =this.name };
        }

        public Process(int x,string n)
        {
            name = n;
            rand = new Random(x);
            PoketSize = rand.Next(100, 1000);
        }

        public Process()
        { }




    }
}
