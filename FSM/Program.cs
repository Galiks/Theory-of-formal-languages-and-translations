using System;
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

            //qweqwe12.qweq+123eqwe4124adl435kasf+12.54e+43 --- 1e7+8.9 ----- .535wsdqr5456qwe5.5asd-5.5 ---adcv12asdasd1735qwesdfa47+8.99cd --qwe12w53.5e+3

            fsm.CountNumbers("qeqe..12..qeq+123eqe4124a435k+12.54e+43", 0);


            Console.WriteLine("Конец");
            //Console.WriteLine(fsm.ToString());

            Console.Read();
        }
    }
}
