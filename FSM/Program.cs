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

            string path = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\TextFile2.txt";

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

            //FiniteStateMachine keyWord = new FiniteStateMachine(_kw, true);
            //FiniteStateMachine numDouble = new FiniteStateMachine(_num, true);
            //FiniteStateMachine numInt = new FiniteStateMachine(_num2, true);
            //FiniteStateMachine log = new FiniteStateMachine(_log, true);
            //FiniteStateMachine op = new FiniteStateMachine(_op, true);
            //FiniteStateMachine AS = new FiniteStateMachine(_as, true);
            //FiniteStateMachine lb = new FiniteStateMachine(_lb, true);
            //FiniteStateMachine rb = new FiniteStateMachine(_rb, true);
            //FiniteStateMachine c = new FiniteStateMachine(_c, true);
            //FiniteStateMachine ws = new FiniteStateMachine(_ws, false);
            FiniteStateMachine ID = new FiniteStateMachine(_id, true);

            //qeqe..12..qeq+123eqe4124a435ek+12.54e+43 --- 1e7+8.9 ----- .535wsdqr5456qwe5.5asd-5.5 ---adcv12asdasd1735qwesdfa47+8.99cd --qwe12w53.5e+3

            //fsm.CountNumbers(".535wsdqr5456qwe5.5asd------+++++++5.54++-.5", 0);
            //Console.WriteLine("Конец");
            ////Console.WriteLine();

            //fsm.CountNumbers("3e5e3e5", 0);
            //Console.WriteLine("Конец");
            //Console.WriteLine(fsm.ToString());

            //varfuninletendifthenelseval

            //keyWord.WordsInText("varfuninletendifthenelseval", 0);

            //numDouble.CountNumbers("123.123e5e55.5", 0);

            //numInt.CountNumbers("+123+d12", 0);

            //log.WordsInText("trueasdasdtfalsee", 0);

            //op.WordsInText("фывфы/фывф*/-/+andalsosdfsdforelsefsdfnot", 0);

            //надо сделать отдельный метод для этого!!!!!!!!!!!!
            //ws.CountNumbers(@"\r   \n   \t", 0);

            ID.CountNumbers("asd123_", 0);

            Console.Read();
        }
    }
}
