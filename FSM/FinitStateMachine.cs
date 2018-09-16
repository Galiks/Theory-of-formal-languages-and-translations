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

        /// <summary>
        /// Конструктор для считывания автомата из файла
        /// </summary>
        /// <param name="filePath">Путь к файлу с автоматом</param>
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

            //Информация из файла заносится в DataFile, который состоит из массивов
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    DataFile.Add(line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                }
            }

            //Первый элемент списка DataFile содержит множество состояний
            foreach (var item in DataFile[0])
            {
                States.Add(item);
            }

            //Второй элемент списка DataFile содержит алфавит
            foreach (var item in DataFile[1])
            {
                Alphabet += item;
            }

            //Третий элемент списка DataFile содержит начальные состояния
            foreach (var item in DataFile[2])
            {
                InitialStates.Add(item);
            }

            //Четвертый элемент списка DataFile содержит конечные состояния
            foreach (var item in DataFile[3])
            {
                FinalyStates.Add(item);
            }

            //После 4 строки (_lineForTransition) идут переходы автомата
            //Каждый переход добавляется в список ListForTransition
            for (int i = _lineForTransition; i < DataFile.Count; i++)
            {
                ListForTransition.Add(DataFile[i]);
            }

            //С помощью цикла проходимся по алфавиту и записываем в словарь Transitions Key - символ алфавита и Value - переходы для символа из алфавита
            for (int i = 0; i < Alphabet.Length; i++)
            {
                Transitions.Add(Alphabet[i].ToString(), ListForTransition[i]);
            }

            //Проверка на то, что указанные начальные или конечные состояния входят в множество состояний
            if (!States.ContainsAll(InitialStates) || !States.ContainsAll(FinalyStates))
            {
                throw new Exception("Указанные начальные или конечные состояния не входят в множество состояний.");
            }

            //Присваивание списку, который содержит текущие состояния, начальных состояний
            CurrentState = InitialStates;

        }

        //Простое переопределение метода ToString() для вывода информации об автомате
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
        /// Метод для подсчёта максимальной подстроки
        /// </summary>
        /// <param name="input">Входная строка</param>
        /// <param name="k">Позиция, с которой начнётся перебор входной строки</param>
        /// <returns>Возвращает Tuple, который содержит result - True или False в зависимости от того, найдена подстрока во входной строке или нет, а также m - длину этой строки</returns>
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

            //Проход по входной строке
            for (int i = k; i < input.Length; i++)
            {
                //Проверка символов на вхождение в алфавит
                if (Alphabet.Contains(input[i].ToString()))
                {
                    //Вызов функции перехода. Передаём текущие состояния автомата и символ
                    StateTransitionFunction(CurrentState, input[i].ToString());

                    //в промежуточную строку добавляем символ из входной строки
                    tempString += input[i];

                    //Если текущие состояния "достигли" конечные, то result присваиваем True, в строку output записываем найденную построку, а m присваиваем длину найденной подстроки. 
                    //И продолжаем цикл, пока не пройдём всю входную строку. 
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

        /// <summary>
        /// Функция перехода
        /// </summary>
        /// <param name="currentStates">Текущие состояния автомата</param>
        /// <param name="symbol">Симбол автомата</param>
        private void StateTransitionFunction(List<string> currentStates, string symbol)
        {
            //Список промежуточных значений. Используется для хранения значений, который в дальнейшем будут записываться в CurrentState
            InterimStates = new List<string>();

            //С помощью цикла проходим по текущим состояниям автомата
            foreach (var item in currentStates)
            {
                //Этот цикл нужен для извлечения можества состояний, которые поделены знаком '|'. Например, для состояния 2, который может перейти по горизонтали в 1 или 3.
                //После извлечения состояния добавляются в список промежуточных состояний.
                foreach (var item2 in Transitions[symbol][Int32.Parse(item) - 1].Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    InterimStates.Add(item2);
                }
            }

            //Присваиваем списку текущих состояний список промежуточных состояний.
            CurrentState = InterimStates;

        }



    }
}
