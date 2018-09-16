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

            //FiniteStateMachine fsm = new FiniteStateMachine(new List<int> { 8,9 }, new List<int> { 1 });

            //Tuple<bool, int> result = fsm.MaxString("aaaa", 0);

            //Console.WriteLine($"{result}");

            FiniteStateMachine fsm = new FiniteStateMachine("TextFile1.txt");

            Console.WriteLine(fsm.ToString());

            var result = fsm.MaxString("ba", 0);

            Console.WriteLine(result);

            Console.Read();
        }
    }
}
