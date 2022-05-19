using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ProjectAssembler
{
    class MyThreads
    {
        unsafe private int*[] finalData;

        /*
         * Konstruktor jednoarugomentowy
         */
        unsafe public MyThreads(int numberOfThreads)
        {
            finalData = new int*[numberOfThreads];
        }

        /*
         * Lista na wątki
         */
        List<Thread> threads = new List<Thread>();

        /*
         * Dodawanie wątku do listy
         * a - wskaźnik na pixele
         * b - wartość na tablice z winietami
         * c - ilość pixeli
         * i - index finalData w jakie miejsce zwrócić wyniki
         * cPlusPlus - true, wysokopoziomowa biblioteka - false, niskopoziomowa
         */
        unsafe public void addThread(int* a, int* b, int length, int i, bool cPlusPlus, int* finalDataa)
        {
            Thread thread;

            if (cPlusPlus)
            {
                System.Diagnostics.Debug.WriteLine("Wypisuje i: " + i);
                thread = new Thread(() => { finalData[i] = HighLevelVignetting.vignetting(a, b, length); });
            } else
            {
                System.Diagnostics.Debug.WriteLine("Wypisuje i: " + i);
                thread = new Thread(() => { finalData[i] = AssemblerVignetting.AsmVignetting(a, b, length, finalDataa); });
            }

            threads.Add(thread);

        }

        /*
         * Startowanie wątków
         */
        public void StartThreads()
        {
            foreach (Thread thread in threads)
            {
                thread.Start();
                thread.Join();
            }
            while (threads.Any(thread => thread.IsAlive != false))
            {
                Thread.Sleep(50);
            }
        }

        /*
        * Zwracanie wyników
        */
        unsafe public int*[] getFinalData()
        {
            return finalData;
        }

    }
}
