using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    class Program
    {
        static void Main(string[] args)
        {


            //Task2();
            //Task3();
            Task4();
            Console.Read();
        }

        static void Task2()
        {
            string path = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\Num.txt";

            FiniteStateMachine finiteStateMachine = new FiniteStateMachine(path, true);

            finiteStateMachine.CountNumbers("+5.5", 0);
            Console.WriteLine("Конец");
        }

        static void Task3()
        {
            //очистка файла outputFile
            using (var fs = new FileStream(@"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\outputFile.txt", FileMode.Truncate))
            {
            }

            var machines = new List<FiniteStateMachine>();

            #region Path to file
            string _kw = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\KeyWord.txt";
            string _num = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\Num.txt";
            string _num2 = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\Int.txt";
            string _log = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\Log.txt";
            string _op = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\Op.txt";
            string _as = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\AS2.txt";
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
            FiniteStateMachine ws = new FiniteStateMachine(_ws, true);
            FiniteStateMachine ID = new FiniteStateMachine(_id, true);
            #endregion

            machines.AddRange(new List<FiniteStateMachine>()
            {
                keyWord,
                op,
                numDouble,
                numInt,
                log,
                AS,
                lb,
                rb,
                c,
                ws,
                ID,
            });

            #region Main
            //string inputFile = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\inputFile.txt";

            //using (StreamReader reader = new StreamReader(inputFile))
            //{
            //    string line;
            //    int i = 0;
            //    while ((line = reader.ReadLine()) != null)
            //    {
            //        if (line.Contains("\t"))
            //        {
            //            line = @"\t" + line.Substring(1);
            //        }
            //        if (line.Contains("\r"))
            //        {
            //            line = @"\r" + line.Substring(1);
            //        }
            //        Console.WriteLine(line);
            //        if (i != 0)
            //        {
            //            FiniteStateMachine.ThirdTask(@"\n" + line, machines, 0);
            //            i++;
            //        }
            //        else
            //        {
            //            FiniteStateMachine.ThirdTask(line, machines, 0);
            //            i++;
            //        }
            //    }
            //}
            #endregion

            Console.WriteLine("The end");
        }

        static void Task4()
        {
            MyRegex myRegex = new MyRegex();

            myRegex.MainFunc();
        }
    }
}
