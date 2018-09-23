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

            FiniteStateMachine fsm = new FiniteStateMachine("TextFile2.txt");

            //qweqwe12.qweq+-123eqwe4124adl435kasf+12.54e+43 --- 1e7+8.9 ----- .535wsdqr5456qwe5.5asd-5.5 ---adcv12asdasd1735qwesdfa47+8.99cd

            var result = fsm.CountNumbers("qweqwe12.qweq+-123eeqwe4124adl435kasf+12.54e+43", 0);

            Console.WriteLine(result);

            Console.Read();
        }
    }
}
