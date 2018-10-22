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

            //qeqe..12..qeq+123eqe4124a435ek+12.54e+43 --- 1e7+8.9 ----- .535wsdqr5456qwe5.5asd-5.5 ---adcv12asdasd1735qwesdfa47+8.99cd --qwe12w53.5e+3

            //Console.WriteLine();

            //fsm.CountNumbers("3e5e3e55ghj55hg55", 0);

            //Console.WriteLine("Конец");

            //varfuninletendifthenelseval

            //keyWord.WordsInText("varfuninletendifthenelseval", 0);

            //numDouble.CountNumbers("123.123e5e55.5", 0);

            //numInt.CountNumbers("+123+d12", 0);

            //log.WordsInText("trueasdasdtfalsee", 0);

            //op.WordsInText("фывфы/фывф*/-/+andalsosdfsdforelsefsdfnot", 0);

            //надо сделать отдельный метод для этого!!!!!!!!!!!!
            //ws.CountNumbers(@"\r   \n   \t", 0);

            //ID.CountNumbers("asd123_", 0);
            Task3();
            Console.Read();
        }

        static void Task2()
        {
            string path = @"E:\Documents\GitHub\Theory-of-formal-languages-and-translations\FSM\TextFile2.txt";

            FiniteStateMachine finiteStateMachine = new FiniteStateMachine(path, true);

            finiteStateMachine.CountNumbers("+5+2365427.63547e+72637.72536e-.5e5e3e5a34.4ghhhgf.gfhgf", 0);
            Console.WriteLine("Конец");
        }

        static void Task3()
        {
            #region Path to file
            string _kw = @"E:\Documents\GitHub\Theory-of-formal-languages-and-translations\FSM\KeyWord.txt";
            string _num = @"E:\Documents\GitHub\Theory-of-formal-languages-and-translations\FSM\Num.txt";
            string _num2 = @"E:\Documents\GitHub\Theory-of-formal-languages-and-translations\FSM\Int.txt";
            string _log = @"E:\Documents\GitHub\Theory-of-formal-languages-and-translations\FSM\Log.txt";
            string _op = @"E:\Documents\GitHub\Theory-of-formal-languages-and-translations\FSM\Op.txt";
            string _as = @"E:\Documents\GitHub\Theory-of-formal-languages-and-translations\FSM\AS.txt";
            string _lb = @"E:\Documents\GitHub\Theory-of-formal-languages-and-translations\FSM\LB.txt";
            string _rb = @"E:\Documents\GitHub\Theory-of-formal-languages-and-translations\FSM\RB.txt";
            string _c = @"E:\Documents\GitHub\Theory-of-formal-languages-and-translations\FSM\C.txt";
            string _ws = @"E:\Documents\GitHub\Theory-of-formal-languages-and-translations\FSM\WS.txt";
            string _id = @"E:\Documents\GitHub\Theory-of-formal-languages-and-translations\FSM\ID.txt";
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



            keyWord.CountNumbers("varfuninletendifthenelseval", 0);
            numDouble.CountNumbers("123.123e5e55.5", 0);

            numInt.CountNumbers("+123+d12", 0);

            log.CountNumbers("trueasdasdtfalsee", 0);

            op.CountNumbers("фывфы/фывф*/-/+andalsosdfsdforelsefsdfnot", 0);

            //надо сделать отдельный метод для этого!!!!!!!!!!!!
            ws.CountNumbers(@"\r   \n   \t", 0);

            ID.CountNumbers("asd123_", 0);


        }
    }
}
