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
            Task3();
            Console.Read();
        }

        static void Task2()
        {
            string path = @"C:\Users\contest\Downloads\Theory-of-formal-languages-and-translations-First\Theory-of-formal-languages-and-translations-First\FSM\Num.txt";

            FiniteStateMachine finiteStateMachine = new FiniteStateMachine(path, true);

            finiteStateMachine.CountNumbers("+5.5", 0);
            Console.WriteLine("Конец");
        }

        static void Task3()
        {
            //очистка файла outputFile
            using (var fs = new FileStream(@"C:\Users\contest\Downloads\Theory-of-formal-languages-and-translations-First\Theory-of-formal-languages-and-translations-First\FSM\outputFile.txt", FileMode.Truncate))
            {
            }

            var machines = new List<FiniteStateMachine>();

            #region Path to file
            string _kw = @"C:\Users\contest\Downloads\Theory-of-formal-languages-and-translations-First\Theory-of-formal-languages-and-translations-First\FSM\KeyWord.txt";
            string _num = @"C:\Users\contest\Downloads\Theory-of-formal-languages-and-translations-First\Theory-of-formal-languages-and-translations-First\FSM\Num.txt";
            string _num2 = @"C:\Users\contest\Downloads\Theory-of-formal-languages-and-translations-First\Theory-of-formal-languages-and-translations-First\FSM\Int.txt";
            string _log = @"C:\Users\contest\Downloads\Theory-of-formal-languages-and-translations-First\Theory-of-formal-languages-and-translations-First\FSM\Log.txt";
            string _op = @"C:\Users\contest\Downloads\Theory-of-formal-languages-and-translations-First\Theory-of-formal-languages-and-translations-First\FSM\Op.txt";
            string _as = @"C:\Users\contest\Downloads\Theory-of-formal-languages-and-translations-First\Theory-of-formal-languages-and-translations-First\FSM\AS.txt";
            string _lb = @"C:\Users\contest\Downloads\Theory-of-formal-languages-and-translations-First\Theory-of-formal-languages-and-translations-First\FSM\LB.txt";
            string _rb = @"C:\Users\contest\Downloads\Theory-of-formal-languages-and-translations-First\Theory-of-formal-languages-and-translations-First\FSM\RB.txt";
            string _c = @"C:\Users\contest\Downloads\Theory-of-formal-languages-and-translations-First\Theory-of-formal-languages-and-translations-First\FSM\C.txt";
            string _ws = @"C:\Users\contest\Downloads\Theory-of-formal-languages-and-translations-First\Theory-of-formal-languages-and-translations-First\FSM\WS.txt";
            string _id = @"C:\Users\contest\Downloads\Theory-of-formal-languages-and-translations-First\Theory-of-formal-languages-and-translations-First\FSM\ID.txt";
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



            string inputFile = @"C:\Users\contest\Downloads\Theory-of-formal-languages-and-translations-First\Theory-of-formal-languages-and-translations-First\FSM\inputFile.txt";

            using (StreamReader reader = new StreamReader(inputFile))
            {
                string line;
                int i = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    if (i != 0)
                    {
                        FiniteStateMachine.ThirdTask("\\n" + line, machines, 0);
                        i++;
                    }
                    else
                    {
                        FiniteStateMachine.ThirdTask(line, machines, 0);
                        i++;
                    }
                }
            }

            Console.WriteLine("The end");
        }
    }
}
