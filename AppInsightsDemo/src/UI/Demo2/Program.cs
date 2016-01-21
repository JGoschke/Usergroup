using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var logger = Logging.Instance)
            {
                var randomizer = new Random();
                foreach ( var nummer in Enumerable.Range(1, 100))
                {
                    double wert = randomizer.NextDouble();
                    logger.MeldeMesswert1(wert);
                    Thread.Sleep(5);
                }
                Console.ReadLine();
            }
        }
    }
}
