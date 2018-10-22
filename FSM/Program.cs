﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"E:\Documents\GitHub\Theory-of-formal-languages-and-translations\FSM\TextFile2.txt";

            FiniteStateMachine fsm = new FiniteStateMachine(path);

            //qeqe..12..qeq+123eqe4124a435ek+12.54e+43 --- 1e7+8.9 ----- .535wsdqr5456qwe5.5asd-5.5 ---adcv12asdasd1735qwesdfa47+8.99cd --qwe12w53.5e+3

            fsm.CountNumbers("+5+2365427.63547e+72637.72536e-.5e5e3e5a34.4ghhhgf.gfhgf", 0);
            Console.WriteLine("Конец");
            //Console.WriteLine();

            //fsm.CountNumbers("3e5e3e55ghj55hg55", 0);
            //Console.WriteLine("Конец");
            //Console.WriteLine(fsm.ToString());

            Console.Read();
        }
    }
}
