using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
   
    public class Matrix
    {
        int SIZE = 100;
        private readonly object _lock;
        public List<Kolumny> wiersze;
        public List<int> max_num;
        public List<int> max_num_without_threats;


        public Matrix()
        {
            wiersze = new List<Kolumny>(SIZE);
            max_num = new List<int>();
            max_num_without_threats = new List<int>();
            _lock = new object();
            fill();
        }

        public void fill()
        {

            Random random = new Random();
            Console.WriteLine("tworze macierz");
            for (int i = 0; i < SIZE; i++)
            {
                //Random random = new Random(i);
                Kolumny a = new Kolumny(random);
                wiersze.Add(a);
            }
            Console.WriteLine("stworzylem macierz");

        }

        public void max_search()
        {
            for(int i = 0; i < wiersze.Count; i++)
            {
                bool choice = false;
                lock (_lock)
                {
                    if (!wiersze[i].ifChecked)
                    {
                        choice = true;
                        wiersze[i].ifChecked = true;
                    }
                }
                if (wiersze[i].ifChecked && choice)
                {
                    max_num.Add(wiersze[i].maxx());
                }
            }
                
        }
        public void max_search_without_threats()
        {
            for (int i = 0; i < wiersze.Count; i++)
            {
                max_num_without_threats.Add(wiersze[i].maxx());
            }
        }

        public int max_max_search()
        {
            return max_num.Max();
        }

        public int max_max_search_without_threats()
        {
            return max_num_without_threats.Max();
        }


        public void print_max()

        {
            Console.Write("\n");
            for (int i = 0; i < max_num.Count; i++)
            {
                Console.Write(max_num[i].ToString() + "\t");
            }
            Console.Write("\n");
        }

        public override string ToString()
        {
            string str = "";
            foreach (Kolumny i in wiersze)
            {
                str += i.ToString() + "\n";
            }
            return str;
        }



    }


    public class Kolumny
    {
        int SIZE = 100;
        List<int> kolumny;
        public bool ifChecked;



        public Kolumny(Random random)
        {
            kolumny = new List<int>(SIZE);
            ifChecked = false;
            fill(random);
        }

        public void fill(Random random)
        {
            for (int i = 0; i <SIZE; i++)
            {
                kolumny.Add(random.Next()%32000);
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach(int i in kolumny)
            {
                str += i.ToString() + "\t";
            }
            return str;
        }

        public int maxx()
        {
            return kolumny.Max();
        }

    }
}
