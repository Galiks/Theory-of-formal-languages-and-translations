using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Linq;

namespace FSM
{
    class FiniteStateMachine
    {
        private const int _lineForTransition_OneAndTwoTasks = 4;
        private const int _lineForTransition_ThreeTask = 6;

        #region Fields
        private static string outputFile = @"E:\Документы\GitHub\Theory-of-formal-languages-and-translations\FSM\outputFile.txt";
        private static List<Tuple<FiniteStateMachine, string>> numbers;
        //множество состояний
        private List<string> _states;
        //множество начальных состояний
        private List<string> _initialStates;
        //множество конечных состояний
        private List<string> _finalyStates;
        //алфавит
        private List<string> _alphabet;
        //текущее состояние
        private List<string> _currentState;
        //бывшие состояния
        //private List<string> _oldStates;
        //данные из файла
        private List<string[]> _dataFile;
        //переходы для одного символа
        private List<string[]> _listForTransition;
        //после любви с масивами я решил изменить массив на список
        private List<List<string>> _newListForTransition;
        private Dictionary<string, List<string>> _newTransitions;
        //переходы
        private Dictionary<string, string[]> _transitions;
        //список для записей промежуточных состояний автомата
        private HashSet<string> _interimStates;
        //приоритет автоматов
        private string _priority;
        //стоп-символ
        private string _stopSymbol;
        //имя автомата
        private string machineName;
        #endregion

        #region Property

        public List<string> States { get => _states; set => _states = value; }
        public List<string> InitialStates { get => _initialStates; set => _initialStates = value; }
        public List<string> FinalyStates { get => _finalyStates; set => _finalyStates = value; }
        public List<string> Alphabet { get => _alphabet; set => _alphabet = value; }
        public List<string> CurrentState { get => _currentState; set => _currentState = value; }
        public List<string[]> DataFile { get => _dataFile; set => _dataFile = value; }
        public Dictionary<string, string[]> Transitions { get => _transitions; set => _transitions = value; }
        public List<string[]> ListForTransition { get => _listForTransition; set => _listForTransition = value; }
        public HashSet<string> InterimStates { get => _interimStates; set => _interimStates = value; }
        public string Priority { get => _priority; set => _priority = value; }
        public string StopSymbol { get => _stopSymbol; set => _stopSymbol = value; }
        public string MachineName { get => machineName; set => machineName = value; }
        public static string OutputFile { get => outputFile; set => outputFile = value; }
        public List<List<string>> NewListForTransition { get => _newListForTransition; set => _newListForTransition = value; }
        public Dictionary<string, List<string>> NewTransitions { get => _newTransitions; set => _newTransitions = value; }


        #endregion

        #region Constructure

        /// <summary>
        /// Конструктор для считывания автомата из файла для 1 и 2 задания
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
            InterimStates = new HashSet<string>();
            Alphabet = new List<string>();

            ReadInformationFromFile(filePath);

            //Первый элемент списка DataFile содержит множество состояний
            foreach (var item in DataFile[0])
            {
                States.Add(item);
            }

            //Второй элемент списка DataFile содержит алфавит
            foreach (var item in DataFile[1])
            {
                Alphabet.Add(item);
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
            for (int i = _lineForTransition_OneAndTwoTasks; i < DataFile.Count; i++)
            {
                ListForTransition.Add(DataFile[i]);
            }

            //С помощью цикла проходимся по алфавиту и записываем в словарь Transitions Key - символ алфавита и Value - переходы для символа из алфавита
            for (int i = 0; i < Alphabet.Count; i++)
            {
                Transitions.Add(Alphabet[i].ToString(), ListForTransition[i]);
            }

            //Проверка на то, что указанные начальные или конечные состояния входят в множество состояний
            if (!States.ContainsList(InitialStates) || !States.ContainsList(FinalyStates))
            {
                throw new Exception("Указанные начальные или конечные состояния не входят в множество состояний.");
            }

            //Присваивание списку, который содержит текущие состояния, начальных состояний
            CurrentState = InitialStates;

        }

        /// <summary>
        /// Конструктор для считывания автомата из файла для 3 задания
        /// </summary>
        /// <param name="filePath">Путь к файлу с автоматом</param>
        /// <param name="flag">Переменная для установки стоп-символа</param>
        public FiniteStateMachine(string filePath, bool flag)
        {

            if (flag)
            {
                StopSymbol = " ";
            }
            else
            {
                StopSymbol = "*";
            }

            States = new List<string>();
            DataFile = new List<string[]>();
            InitialStates = new List<string>();
            FinalyStates = new List<string>();
            ListForTransition = new List<string[]>();
            Transitions = new Dictionary<string, string[]>();
            CurrentState = new List<string>();
            InterimStates = new HashSet<string>();
            Alphabet = new List<string>();
            numbers = new List<Tuple<FiniteStateMachine, string>>();

            ReadInformationFromFile(filePath);

            //Первый элемент списка DataFile содержит множество состояний
            foreach (var item in DataFile[0])
            {
                States.Add(item);
            }

            //Второй элемент списка DataFile содержит алфавит
            foreach (var item in DataFile[1])
            {
                Alphabet.Add(item);
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

            //Приоритет
            Priority = DataFile[4].First();

            //Имя автомата
            MachineName = DataFile[5].First();

            //После 6 строки идут переходы автомата
            //Каждый переход добавляется в список ListForTransition
            for (int i = _lineForTransition_ThreeTask; i < DataFile.Count; i++)
            {
                ListForTransition.Add(DataFile[i]);
            }

            //С помощью цикла проходимся по алфавиту и записываем в словарь Transitions Key - символ алфавита и Value - переходы для символа из алфавита
            for (int i = 0; i < Alphabet.Count; i++)
            {
                Transitions.Add(Alphabet[i].ToString(), ListForTransition[i]);
            }

            //Проверка на то, что указанные начальные или конечные состояния входят в множество состояний
            if (!States.ContainsList(InitialStates) || !States.ContainsList(FinalyStates))
            {
                throw new Exception("Указанные начальные или конечные состояния не входят в множество состояний.");
            }

            //Присваивание списку, который содержит текущие состояния, начальных состояний
            CurrentState = InitialStates;
        }

        /// <summary>
        /// Конструктор для создания автомата не из файла
        /// </summary>
        /// <param name="states">Список состояний</param>
        /// <param name="initialStates">Список начальных состояний</param>
        /// <param name="finalyStates">Список конечных состояний</param>
        /// <param name="alphabet">Алфавит автомата</param>
        /// <param name="transitions">Словать переходов, где key - символ, value - переход в состояние</param>
        /// <param name="listForTransition">Список состояний для перехода</param>
        /// <param name="priority">Приоритет автомата</param>
        /// <param name="stopSymbol">Стоп символ</param>
        /// <param name="machineName">Имя автомата</param>
        public FiniteStateMachine(List<string> states, 
            List<string> initialStates, 
            List<string> finalyStates, 
            List<string> alphabet, 
            Dictionary<string, List<string>> transitions,
            string priority, 
            string stopSymbol, 
            string machineName)
        {
            States = states ?? throw new ArgumentNullException(nameof(states));
            InitialStates = initialStates ?? throw new ArgumentNullException(nameof(initialStates));
            FinalyStates = finalyStates ?? throw new ArgumentNullException(nameof(finalyStates));
            Alphabet = alphabet ?? throw new ArgumentNullException(nameof(alphabet));
            NewTransitions = transitions ?? throw new ArgumentNullException(nameof(transitions));
            Priority = priority ?? throw new ArgumentNullException(nameof(priority));
            StopSymbol = stopSymbol ?? throw new ArgumentNullException(nameof(stopSymbol));
            MachineName = machineName ?? throw new ArgumentNullException(nameof(machineName));
        }



        /// <summary>
        /// Метод для чтения информации из файла
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        private void ReadInformationFromFile(string filePath)
        {
            //Информация из файла заносится в DataFile, который состоит из массивов
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    DataFile.Add(line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                }
            }
        }
        #endregion

        /// <summary>
        /// Метод для подсчёта максимальной подстроки
        /// </summary>
        /// <param name="input">Входная строка</param>
        /// <param name="k">Позиция, с которой начнётся перебор входной строки</param>
        /// <returns>Возвращает Tuple, который содержит result - True или False в зависимости от того, найдена подстрока во входной строке или нет, а также m - длину этой строки</returns>
        public Tuple<FiniteStateMachine, string, int> MaxString(string input, int k)
        {
            bool result = false;
            int m = 0;
            string output = "";
            string tempString = "";

            if (ContainsList(InitialStates, FinalyStates))
            {
                result = true;
                return new Tuple<FiniteStateMachine, string, int>(this, output, m);
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
                    if (ContainsList(CurrentState, FinalyStates))
                    {
                        result = true;
                        output = tempString;
                        m = i - k + 1;
                    }
                }
                else
                {
                    if (result)
                    {
                        //Console.WriteLine($"{this.MachineName} : {output}");
                        return new Tuple<FiniteStateMachine,string, int>(this, output, m);
                    }
                    break;
                }

            }

            return new Tuple<FiniteStateMachine,string, int>(this, output, m);
        }

        /// <summary>
        /// Метод для подсчёта максимальной подстроки
        /// </summary>
        /// <param name="input">Входная строка</param>
        /// <param name="k">Позиция, с которой начнётся перебор входной строки</param>
        /// <returns>Возвращает Tuple, который содержит result - True или False в зависимости от того, найдена подстрока во входной строке или нет, а также m - длину этой строки</returns>
        private void MaxStringForNumber(string input, int k)
        {
            string output = "";
            string tempString = "";

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

                    //Если текущие состояния "достигли" конечных, то result присваиваем True, в строку output записываем найденную построку, а m присваиваем длину найденной подстроки. 
                    //И продолжаем цикл, пока не пройдём всю входную строку. 
                    if (ContainsList(CurrentState, FinalyStates))
                    {
                        if (output.Length < tempString.Length)
                        {
                            output = tempString;
                        }
                    }
                    if (CurrentState.Contains(StopSymbol))
                    {
                        if (output.Length > 0)
                        {
                            numbers.Add(new Tuple<FiniteStateMachine,string>(this, output));
                        }

                        if (tempString.Length > 1)
                        {
                            i--;
                        }
                        tempString = "";
                        output = "";

                        CurrentState = InitialStates;
                    }
                }
            }

            if (output.Length > 0)
            {
                numbers.Add(new Tuple<FiniteStateMachine, string>(this, output));
            }
        }

        /// <summary>
        /// Метод для подсчёта вещественных чисел в строке
        /// </summary>
        /// <param name="input">Входная строка</param>
        /// <param name="k">Позиция, с которой начнётся перебор входной строки</param>
        /// <returns>Возвращает Tuple, который содержит result - True или False в зависимости от того, найдено хотя бы одно вещественное число или нет,
        /// а также m - количество вещественных чисел</returns>
        public void CountNumbers(string input, int k)
        {
            string number = "";

            for (int i = k; i < input.Length; i++)
            {
                if (Alphabet.Contains(input[i].ToString()))
                {
                    number += input[i];
                }
                else
                {
                    if (!String.IsNullOrEmpty(number) || !String.IsNullOrWhiteSpace(number))
                    {
                        MaxStringForNumber(number, 0); 
                    }
                    CurrentState = InitialStates;
                    number = "";
                }
            }

            MaxStringForNumber(number, 0);

            numbers.Information();

            CurrentState = InitialStates;
        }        

        /// <summary>
        /// Функция перехода
        /// </summary>
        /// <param name="currentStates">Текущие состояния автомата</param>
        /// <param name="symbol">Симбол автомата</param>
        public void StateTransitionFunction(List<string> currentStates, string symbol)
        {
            //Список промежуточных значений. Используется для хранения значений, который в дальнейшем будут записываться в CurrentState
            InterimStates = new HashSet<string>();

            //С помощью цикла проходим по текущим состояниям автомата
            foreach (var item in currentStates)
            {
                //Индекс текущего состояния
                var valueIndex = States.IndexOf(item);
                //Этот цикл нужен для извлечения можества состояний, которые поделены знаком '|'. Например, для состояния 2, который может перейти по горизонтали в 1 или 3.
                //После извлечения состояния добавляются в список промежуточных состояний.
                foreach (var item2 in Transitions[symbol][valueIndex].Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    InterimStates.Add(item2);
                }
            }
            //Присваиваем списку текущих состояний список промежуточных состояний.
            CurrentState = InterimStates.ToList();
        }

        public bool ContainsList(IEnumerable<string> first, IEnumerable<string> second)
        {
            if (first.Intersect(second).Count() > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Метод для 3 задания. Выводит токены и слова.
        /// </summary>
        /// <param name="input">Входная строка</param>
        /// <param name="fsm">Список автоматов</param>
        /// <param name="k">Позиция, с которой начнётся перебор входной строки</param>
        public static void ThirdTask(string input, List<FiniteStateMachine> fsm, int k)
        {
            Tuple<FiniteStateMachine,string, int> old_K = new Tuple<FiniteStateMachine,string, int>(null,null, k);

            while (k < input.Length)
            {
                for (int i = 0; i < fsm.Count; i++)
                {
                    var machine = fsm[i];

                    var new_K = machine.MaxString(input, k);

                    if (new_K.Item3 > old_K.Item3)
                    {
                        old_K = new_K;
                    }

                    if (new_K.Item3 == old_K.Item3)
                    {
                        if (old_K.Item1 != null)
                        {
                            if (new_K.Item1.Priority.CompareTo(old_K.Item1.Priority) == -1)
                            {
                                old_K = new_K;
                            } 
                        }
                    }

                    machine.CurrentState = machine.InitialStates;
                }


                using (StreamWriter writer = File.AppendText(OutputFile))
                {
                    writer.WriteLine($"{old_K.Item1.MachineName} : {old_K.Item2}"); 
                }

                k += old_K.Item3;

                old_K = new Tuple<FiniteStateMachine,string, int>(null,null,0);

            }
        }
    }
}
