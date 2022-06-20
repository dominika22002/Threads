using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Threads
{
    public class Program
    {


        public static void Main(string[] args)
        {
            Matrix macierz = new Matrix();
            //Console.Write(macierz.ToString());

            Stopwatch sw = new Stopwatch();
            Stopwatch sw1 = new Stopwatch();
            Thread[] threads = new Thread[3];
            sw.Start();
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(macierz.max_search);
                threads[i].Start();
            }
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }
            Console.WriteLine ("watki zakonczyly prace");
            //macierz.print_max();

            Console.WriteLine("max ze wszystkich liczb wynosi: " + macierz.max_max_search().ToString());
            sw.Stop();
            Console.WriteLine("czas pracy z wątkami wynosi: " + sw.Elapsed.ToString());

            sw1.Start();
            macierz.max_search_without_threats();
            Console.WriteLine("max ze wszystkich liczb bez wątków wynosi : " + macierz.max_max_search_without_threats());
            sw1.Stop();
            Console.WriteLine("czas pracy bez wątków wynosi : " + sw1.Elapsed.ToString());

            Console.ReadLine();
        }

    }
}
