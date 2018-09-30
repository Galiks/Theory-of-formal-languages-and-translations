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

            FiniteStateMachine fsm = new FiniteStateMachine(@"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\TextFile2.txt");

            //qweqwe12.qweq+-123eqwe4124adl435kasf+12.54e+43 --- 1e7+8.9 ----- .535wsdqr5456qwe5.5asd-5.5 ---adcv12asdasd1735qwesdfa47+8.99cd --qwe12w53.5e+3

            var result = fsm.CountNumbers("adcv12asdasd1735qwesdfa47+8.99cd", 0);

            Console.WriteLine(result);

            //Console.WriteLine(fsm.ToString());

            Console.Read();
        }
    }
}
