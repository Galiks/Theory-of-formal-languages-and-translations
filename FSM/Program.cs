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

            //Console.WriteLine(fsm.Transitions["+"][0]);

            //foreach (var item in fsm.CurrentState)
            //{
            //    //Этот цикл нужен для извлечения можества состояний, которые поделены знаком '|'. Например, для состояния 2, который может перейти по горизонтали в 1 или 3.
            //    //После извлечения состояния добавляются в список промежуточных состояний.

            //    foreach (var item2 in fsm.Transitions["+"][Int32.Parse(item) - 1].Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
            //    {
            //        Console.WriteLine(item2);
            //    }

            //}

            //Console.WriteLine(fsm.ToString());

            //var result = fsm.CountNumbers("qweqwe12.qweq+-123eqwe4124adl435kasf+12.54e+43", 0); //6

            var result = fsm.CountNumbers("17.35", 0);

            Console.WriteLine(result);

            Console.Read();
        }
    }
}
