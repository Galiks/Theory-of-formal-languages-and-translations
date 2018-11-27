using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    class MyRegex
    {
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
        private List<string> currentState;
        private Dictionary<string, List<string>> transitions;
        private List<List<string>> listForTransition;
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

        public void MainFunc()
        {
            List<string> operations = new List<string>() {"*", "%", "|", "(", ")"};
            List<string> specialSymbol = new List<string>() { "/d", "/w", "/s" };

            List<string> listOfOperations = new List<string>();

            List<FiniteStateMachine> machines = new List<FiniteStateMachine>();

            //список для listOfTrnsition
            List<string> tempList = new List<string>();

            string regex = "var|if";

            for (int i = 0; i < regex.Length; i++)
            {
                if (!operations.Contains(regex[i].ToString()) && !specialSymbol.Contains(regex[i].ToString()))
                {
                    CreateAutomate(regex[i].ToString(), i);
                }
            }

            #region wadsfgh
    //        for (int i = 0; i < regex.Length; i++)
    //        {

    //            #region MyRegion
    //            //initial state
    //            if (i == 0 || operations.Contains(regex[i - 1].ToString()))
    //            {
    //                tempList.Add(regex[i].ToString());
    //            }

    //            if (!operations.Contains(regex[i].ToString()))
    //            {
    //                //alphabet
    //                if (!alphabet.Contains(regex[i].ToString()))
    //                {
    //                    alphabet.Add(regex[i].ToString());
    //                }

    //                //states
    //                if (!states.Contains(regex[i].ToString()))
    //                {
    //                    states.Add(regex[i].ToString());
    //                }
    //            }
    //        }


    //        //finally state
    //        if (i == regex.Length - 1)
    //        {
    //            finalyStates.Add(regex[i].ToString());
    //        }
    //        else if (operations.Contains(regex[i].ToString()))
    //        {
    //            finalyStates.Add(regex[i - 1].ToString());
    //        }
    //    }
    //    #endregion

    //    //listForTransition.Add(tempList);

    //    //transitions.Add(initialStates.First(), tempList);


    //    //foreach (var item in states)
    //    //{
    //    //    Console.Write(item);
    //    //}

    //    //Console.WriteLine();

    //    //foreach (var item in alphabet)
    //    //{
    //    //    Console.Write(item);
    //    //}

    //    //Console.WriteLine();

    //    //foreach (var item in initialStates)
    //    //{
    //    //    Console.Write(item);
    //    //}

    //    //Console.WriteLine();

    //    //foreach (var item in finalyStates)
    //    //{
    //    //    Console.Write(item);
    //    //}

    //    Console.WriteLine();
    //        Console.WriteLine("KEY");

    //        foreach (var item in transitions)
    //        {
    //            Console.Write(item.Key + ": ");
    //            foreach (var item2 in item.Value)
    //            {
    //                Console.Write(item2);
    //            }
    //Console.WriteLine();
    //        }

    //        #region qweqweqw
    //        //states.AddRange(AS.States.Union(lb.States));

    //        //Console.WriteLine("states: ");
    //        //foreach (var item in states)
    //        //{
    //        //    Console.WriteLine(item);
    //        //}

    //        //alphabet.AddRange(AS.Alphabet.Union(lb.Alphabet));

    //        //Console.WriteLine("alphabet: ");
    //        //foreach (var item in alphabet)
    //        //{
    //        //    Console.WriteLine(item);
    //        //}

    //        //Console.WriteLine("initial states: ");
    //        //initialStates.AddRange(AS.InitialStates);

    //        //foreach (var item in initialStates)
    //        //{
    //        //    Console.WriteLine(item);
    //        //}

    //        //finalyStates.AddRange(lb.FinalyStates);

    //        //Console.WriteLine("Finally states: ");

    //        //foreach (var item in finalyStates)
    //        //{
    //        //    Console.WriteLine(item);
    //        //}

    //        //var machines = new List<FiniteStateMachine>();
    //        //machines.AddRange(new List<FiniteStateMachine>()
    //        //{
    //        //    lb,
    //        //    ws,
    //        //});

    //        //AddTransitions(machines);


            #endregion
        } 
	    
        private void CreateAutomate(string letter, int index)
        {
            alphabet = new List<string>() { letter };
            states = new List<string>() { index.ToString(), (index+1).ToString() };
            initialStates = new List<string>() { index.ToString() };
            finalyStates = new List<string>() { (index + 1).ToString() };
            transitions = new Dictionary<string, List<string>>();
            for (int i = 0; i < alphabet.Count; i++)
            {
                transitions.Add(alphabet[i], finalyStates);
            }

            priority = index.ToString();
            stopSymbol = " ";
            machineName = "First";
            FiniteStateMachine newAutomate = new FiniteStateMachine(states, initialStates, finalyStates, alphabet, transitions, priority, stopSymbol, machineName);

            foreach (var item in newAutomate.NewTransitions)
            {
                Console.WriteLine(item.Key+": ");
                foreach (var item2 in item.Value)
                {
                    Console.WriteLine(item2);
                }
            }

            Console.WriteLine();
        }
    }
}