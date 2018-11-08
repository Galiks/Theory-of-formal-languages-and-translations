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
            Task3();
            Console.Read();
        }

        static void Task2()
        {
            string path = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\TextFile2.txt";

            FiniteStateMachine finiteStateMachine = new FiniteStateMachine(path, true);

            finiteStateMachine.CountNumbers("+5+2365427.63547e+72637.72536e-.5e5e3e5a34.4ghhhgf.gfhgf", 0);
            Console.WriteLine("Конец");
        }

        static void Task3()
        {
            var machines = new List<FiniteStateMachine>();

            #region Path to file
            string _kw = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\KeyWord.txt";
            string _num = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\Num.txt";
            string _num2 = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\Int.txt";
            string _log = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\Log.txt";
            string _op = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\Op.txt";
            string _as = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\AS.txt";
            string _lb = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\LB.txt";
            string _rb = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\RB.txt";
            string _c = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\C.txt";
            string _ws = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\WS.txt";
            string _id = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\ID.txt";
            #endregion

            #region Automates
            FiniteStateMachine keyWord = new FiniteStateMachine(_kw, true);
            FiniteStateMachine numDouble = new FiniteStateMachine(_num, true);
            FiniteStateMachine numInt = new FiniteStateMachine(_num2, true);
            FiniteStateMachine log = new FiniteStateMachine(_log, true);
            FiniteStateMachine op = new FiniteStateMachine(_op, true);
            FiniteStateMachine AS = new FiniteStateMachine(_as, true);
            FiniteStateMachine lb = new FiniteStateMachine(_lb, true);
            FiniteStateMachine rb = new FiniteStateMachine(_rb, true);
            FiniteStateMachine c = new FiniteStateMachine(_c, true);
            FiniteStateMachine ws = new FiniteStateMachine(_ws, false);
            FiniteStateMachine ID = new FiniteStateMachine(_id, true);
            #endregion

            //Console.WriteLine(ID.ToString());

            machines.AddRange(new List<FiniteStateMachine>()
            {
                keyWord,
                op,
                numInt,
                numDouble,
                ID,
                log,
                AS,
                lb,
                rb,
                c,
                ws,
            });

            //ThirdTask.TestThree("if (param = patrueram) var qwerty = 5 + .5", machines);

            //ThirdTask.TestThree("var qwerty = 5 + .5", machines);

            FiniteStateMachine.ThirdTask("if (a = t) then var qwerty=5.56 + 6.5", machines, 0);

            Console.WriteLine("The end");
        }
    }
}
