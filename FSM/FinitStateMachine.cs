using System.Collections.Generic;
using System;
using System.IO;

namespace FSM
{
    class FiniteStateMachine
    {
        private const int _lineForTransition = 4;

        //множество состояний
        private List<string> _states;
        //множество начальных состояний
        private List<string> _initialStates;
        //множество конечных состояний
        private List<string> _finalyStates;
        //алфавит
        private string _alphabet;
        //текущее состояние
        private List<string> _currentState;
        //бывшие состояния
        //private List<string> _oldStates;
        //данные из файла
        private List<string[]> _dataFile;
        //переходы для одного символа
        private List<string[]> _listForTransition;
        //переходы
        private Dictionary<string, string[]> _transitions;
        //список для записей промежуточных состояний автомата
        private List<string> _interimStates;


        #region Property

        public List<string> States { get => _states; set => _states = value; }
        public List<string> InitialStates { get => _initialStates; set => _initialStates = value; }
        public List<string> FinalyStates { get => _finalyStates; set => _finalyStates = value; }
        public string Alphabet { get => _alphabet; set => _alphabet = value; }
        public List<string> CurrentState { get => _currentState; set => _currentState = value; }
        //public List<string> OldStates { get => _oldStates; set => _oldStates = value; }
        public List<string[]> DataFile { get => _dataFile; set => _dataFile = value; }
        public Dictionary<string, string[]> Transitions { get => _transitions; set => _transitions = value; }
        public List<string[]> ListForTransition { get => _listForTransition; set => _listForTransition = value; }
        public List<string> InterimStates { get => _interimStates; set => _interimStates = value; }

        #endregion

        public FiniteStateMachine(string filePath)
        {
            States = new List<string>();
            DataFile = new List<string[]>();
            InitialStates = new List<string>();
            FinalyStates = new List<string>();
            ListForTransition = new List<string[]>();
            Transitions = new Dictionary<string, string[]>();
            CurrentState = new List<string>();
            InterimStates = new List<string>();


            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    DataFile.Add(line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                }
            }

            foreach (var item in DataFile[0])
            {
                States.Add(item);
            }

            foreach (var item in DataFile[1])
            {
                Alphabet += item;
            }

            foreach (var item in DataFile[2])
            {
                InitialStates.Add(item);
            }

            foreach (var item in DataFile[3])
            {
                FinalyStates.Add(item);
            }

            for (int i = _lineForTransition; i < DataFile.Count; i++)
            {
                ListForTransition.Add(DataFile[i]);
            }

            for (int i = 0; i < Alphabet.Length; i++)
            {
                Transitions.Add(Alphabet[i].ToString(), ListForTransition[i]);
            }

            if (!States.ContainsAll(InitialStates) || !States.ContainsAll(FinalyStates))
            {
                throw new Exception("Указанные начальные или конечные состояния не входят в множество состояний.");
            }

            CurrentState = InitialStates;

        }

        public override string ToString()
        {
            string states = "";

            foreach (var item in States)
            {
                states += item;
            }

            string initialStates = "";

            foreach (var item in InitialStates)
            {
                initialStates += item;
            }

            string finallyStates = "";

            foreach (var item in FinalyStates)
            {
                finallyStates += item;
            }

            return $"States: {states}{Environment.NewLine}Alphabet: {Alphabet}{Environment.NewLine}Initial States: {initialStates}{Environment.NewLine}Finally States: {finallyStates}";
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">Входная строка</param>
        /// <param name="k">Позиция, с которой начнётся перебор входной строки</param>
        /// <returns></returns>
        public Tuple<bool, int> MaxString(string input, int k)
        {
            bool result = false;
            int m = 0;
            string output = "";
            string tempString = "";

            if (InitialStates.ContainsAll(FinalyStates))
            {
                result = true;
                return new Tuple<bool, int>(result, m);
            }

            for (int i = k; i < input.Length; i++)
            {
                if (Alphabet.Contains(input[i].ToString()))
                {
                    StateTransitionFunction(CurrentState, input[i].ToString());

                    tempString += input[i];

                    if (CurrentState.ContainsAll(FinalyStates))
                    {
                        result = true;
                        output = tempString;
                        m = i - k + 1;
                    }
                }
                else
                {
                    throw new Exception("В алфавите нет таких символов");
                }

            }

            Console.WriteLine($"{output} : {output.Length}");

            return new Tuple<bool, int>(result, m);
        }

        private void StateTransitionFunction(List<string> currentStates, string symbol)
        {
            InterimStates = new List<string>();

            foreach (var item in currentStates)
            {
                foreach (var item2 in Transitions[symbol][Int32.Parse(item) - 1].Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    InterimStates.Add(item2);
                }
            }

            CurrentState = InterimStates;

        }



    }
}
