using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    class MyRegex
    {

        private static int indexOfState = 0;
        //ID: ^\w+\d*        
        //KW: var|fun|in|let|end|if|then|else|val        
        //INT: \d+        
        //LOG: true|false        
        //OP: [+|\-|\/|*]|andalso|orelse|not       
        //WS: \s*(\/n)*(\/t)*(\/r)*

        #region Автоматы
        private FiniteStateMachine keyWord;
        private FiniteStateMachine numDouble;
        private FiniteStateMachine numInt;
        private FiniteStateMachine log;
        private FiniteStateMachine op;
        private FiniteStateMachine AS;
        private FiniteStateMachine lb;
        private FiniteStateMachine rb;
        private FiniteStateMachine c;
        private FiniteStateMachine ws;
        private FiniteStateMachine ID;
        #endregion

        #region Параметры для нового автомата
        private List<string> states;
        private List<string> initialStates;
        private List<string> finalyStates;
        private List<string> alphabet;
        private Dictionary<string, string[]> transitions;
        private string priority;
        private string stopSymbol;
        private string machineName;
        #endregion

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public MyRegex()
        {
            #region Инициализация параметров для нового автомата
            //states = new List<string>();
            //initialStates = new List<string>();
            //finalyStates = new List<string>();
            //alphabet = new List<string>();
            //currentState = new List<string>();
            //transitions = new Dictionary<string, List<string>>();
            //listForTransition = new List<List<string>>();
            #endregion

            #region Path to file
            //string _kw = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\KeyWord.txt";
            //string _num = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\Num.txt";
            //string _num2 = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\Int.txt";
            //string _log = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\Log.txt";
            //string _op = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\Op.txt";
            //string _as = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\AS2.txt";
            //string _lb = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\LB2.txt";
            //string _rb = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\RB.txt";
            //string _c = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\C.txt";
            //string _ws = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\WS.txt";
            //string _id = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\ID.txt";
            #endregion

            #region Automates
            //keyWord = new FiniteStateMachine(_kw, true);
            //numDouble = new FiniteStateMachine(_num, true);
            //numInt = new FiniteStateMachine(_num2, true);
            //log = new FiniteStateMachine(_log, true);
            //op = new FiniteStateMachine(_op, true);
            //AS = new FiniteStateMachine(_as, true);
            //lb = new FiniteStateMachine(_lb, true);
            //rb = new FiniteStateMachine(_rb, true);
            //c = new FiniteStateMachine(_c, true);
            //ws = new FiniteStateMachine(_ws, false);
            //ID = new FiniteStateMachine(_id, true);
            #endregion
        }

        public static int IndexOfState { get => indexOfState; set => indexOfState = value; }

        public void MainFunc()
        {
            List<string> operations = new List<string>() {"*", "%", "|", "(", ")"};
            string preSpecialSymbol = "/";
            List<string> specialSymbol = new List<string>() {"d", "w", "s" };

            List<string> listOfOperations = new List<string>();

            List<Object> machines = new List<Object>();

            //список для listOfTrnsition
            List<string> tempList = new List<string>();

            //string regex = "var|if*/d";

            string regex = "v";

            for (int i = 0; i < regex.Length; i++)
            {
                if (!operations.Contains(regex[i].ToString()) 
                    && !specialSymbol.Contains(regex[i].ToString()) 
                    && regex[i].ToString() != preSpecialSymbol)
                {
                    if (machines.Count > 0)
                    {
                        machines.Add(CreateAutomate(regex[i].ToString(), i + 1));                       
                    }
                    else
                    {
                        machines.Add(CreateAutomate(regex[i].ToString(), i + 1));
                    }
                }
                //if (regex[i].ToString() == @"/")
                //{
                //    if (specialSymbol.Contains(regex[i+1].ToString()))
                //    {
                //        var specSynmol = preSpecialSymbol + regex[i+1].ToString();
                //    }
                //}
                //else
                //{
                //    machines.Add(regex[i].ToString());
                //}
            }

            foreach (var item in machines)
            {
                Console.WriteLine(item);
            }
        } 
	    
        private FiniteStateMachine CreateAutomate(string letter, int index)
        {
            indexOfState++;
            int initialStatesTemp = IndexOfState;
            IndexOfState++;
            int finallyStateTemp = IndexOfState;
            alphabet = new List<string>() { letter };
            states = new List<string>() { initialStatesTemp.ToString(), finallyStateTemp.ToString() };
            initialStates = new List<string>() { initialStatesTemp.ToString() };
            finalyStates = new List<string>() { finallyStateTemp.ToString() };
            transitions = new Dictionary<string, string[]>();
            string[] tempTrans = new string[finalyStates.Count + 1];
            for (int i = 0; i < finalyStates.Count; i++)
            {
                tempTrans[i] = finalyStates[i];
            }
            tempTrans[tempTrans.Length - 1] = "| ";
            for (int i = 0; i < alphabet.Count; i++)
            {
                transitions.Add(alphabet[i], tempTrans);
            }

            priority = index.ToString();
            stopSymbol = " ";
            machineName = letter.ToUpper();
            FiniteStateMachine newAutomate = new FiniteStateMachine(states, initialStates, finalyStates, alphabet, transitions, priority, stopSymbol, machineName);

            //Console.WriteLine(newAutomate.ToString());
            //Console.WriteLine();

            Console.WriteLine("TEST");
            string test = new string(Char.Parse(letter), 5);
            Console.WriteLine(newAutomate.MaxString(test, 0));
            Console.WriteLine("TEST");
            return newAutomate;
        }
    }
}