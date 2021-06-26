using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace testlab
{
    class Program
    {
        const string DllPath = "./testlab/Lab_5_C.dll";

        [DllImport(DllPath)]
        static extern int Version();

        [DllImport(DllPath)]
        static extern double FirstMethod_C(int n, int k);


        [DllImport(DllPath)]
        private static unsafe extern void SecondMethod_C(int n, double[] matrix_array, double[] right_array, double* answer_array);

        static void Main(string[] args)
        {
           
            Console.WriteLine();

            string fileName = "timeList.xml";
            TimeList timeList = new TimeList();

            int n = 100, k = 5;
            timeList.Add(new TimeItem(n, k, FirstMethod(n, k), FirstMethod_C(n, k)));

            n = 200; k = 1;
            Console.WriteLine("Запуск в с++ dll...");
            double cppTime = FirstMethod_C(n, k);
            Console.WriteLine("Время выполнения", n, k, cppTime);
            Console.WriteLine("Запуск в c#...");
            double csTime = FirstMethod(n, k);
            Console.WriteLine("Время выполнения 1", n, k, csTime);
            csTime = FirstMethod(n, k);
            Console.WriteLine("Время выполнения 2", n, k, csTime);
            csTime = FirstMethod(n, k);
            Console.WriteLine("Время выполнения 3", n, k, csTime);
            timeList.Add(new TimeItem(n, k, csTime, cppTime));

            Console.WriteLine(fileName);
            timeList.Save(fileName);
            Console.WriteLine();

            double[] matrix_array = new double[3] { 4, 3, 2 };
            double[] right_array = new double[3] { 10, 20, 30 };
            double[] answer_array = new double[3];
            Console.WriteLine("Передача данныx c++: M = ({0}; {1}; {2}), R = ({3}; {4}; {5})", matrix_array[0], matrix_array[1], matrix_array[2], right_array[0], right_array[1], right_array[2]);

                fixed (double* answer_array_pointer = answer_array)
                    SecondMethod_C(3, matrix_array, right_array, answer_array_pointer);

            Console.Write("Ответ ");
            for (int i = 0; i < answer_array.Length; i++)
                Console.Write("{0:F3}" + (i < answer_array.Length - 1 ? "; " : ""), answer_array[i]);
            Console.WriteLine(")");
            Console.WriteLine();

            Console.WriteLine(fileName);
            TimeList timeList_2 = TimeList.Load(fileName);
            Console.WriteLine(timeList_2.ToString());

         
        }

        static double FirstMethod(int n, int k) 
        {
            Stopwatch timer = new Stopwatch();
            timer.Restart();
            Matrix matrix = new Matrix(n);
            double[] right = new double[n];
            for (int i = 0; i < n; i++)
                right[i] = (i + 1) * 10;
            for (int i = 0; i < k; i++)
                matrix.Solve(right);
            timer.Stop();
            return timer.Elapsed.TotalSeconds;
        }
    }
}
