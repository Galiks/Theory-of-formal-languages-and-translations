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

        public static List<Tuple<FiniteStateMachine,string>> numbers;

        public string tempString;

        #region Fields
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

        private List<string> States { get => _states; set => _states = value; }
        public List<string> InitialStates { get => _initialStates; set => _initialStates = value; }
        public List<string> FinalyStates { get => _finalyStates; set => _finalyStates = value; }
        public List<string> Alphabet { get => _alphabet; set => _alphabet = value; }
        public List<string> CurrentState { get => _currentState; set => _currentState = value; }
        private List<string[]> DataFile { get => _dataFile; set => _dataFile = value; }
        private Dictionary<string, string[]> Transitions { get => _transitions; set => _transitions = value; }
        private List<string[]> ListForTransition { get => _listForTransition; set => _listForTransition = value; }
        private HashSet<string> InterimStates { get => _interimStates; set => _interimStates = value; }
        private string Priority { get => _priority; set => _priority = value; }
        public string StopSymbol { get => _stopSymbol; set => _stopSymbol = value; }
        public string MachineName { get => machineName; set => machineName = value; }


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

        ///// <summary>
        ///// Простое переопределение метода ToString() для вывода информации об автомате
        ///// </summary>
        ///// <returns></returns>
        //public override string ToString()
        //{

        //    string alphabet = "";

        //    foreach (var item in Alphabet)
        //    {
        //        alphabet += item + ", ";
        //    }

        //    string states = "";

        //    foreach (var item in States)
        //    {
        //        states += item + ", ";
        //    }

        //    string initialStates = "";

        //    foreach (var item in InitialStates)
        //    {
        //        initialStates += item + ", ";
        //    }

        //    string finallyStates = "";

        //    foreach (var item in FinalyStates)
        //    {
        //        finallyStates += item + ", ";
        //    }

        //    foreach (var item in Transitions)
        //    {
        //        Console.Write($"{item.Key}: ");

        //        foreach (var item2 in item.Value)
        //        {
        //            Console.Write($"{item2} ");
        //        }

        //        Console.WriteLine();
        //    }

        //    return $"States: {states}{Environment.NewLine}Alphabet: {alphabet}{Environment.NewLine}Initial States: {initialStates}{Environment.NewLine}Finally States: {finallyStates}{Environment.NewLine}Name: {MachineName}{Environment.NewLine}Priority: {Priority}";
        //} 
        #endregion

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

            if (ContainsList(InitialStates, FinalyStates))
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
                        Console.WriteLine($"{this.MachineName} : {output}");
                        return new Tuple<bool, int>(result, m);
                    }
                    break;
                }

            }

            if (result)
            {
                Console.WriteLine($"{this.MachineName} : {output}");
            }

            return new Tuple<bool, int>(result, 0);
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
                foreach (var item2 in Transitions[symbol][valueIndex].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
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

        public static void ThirdTask(string input, List<FiniteStateMachine> fsm, int k)
        {
            

            for (int i = k; i < input.Length; i++)
            {
                for (int j = 0; j < fsm.Count; j++)
                {
                    var machine = fsm[j];

                    if (machine.Alphabet.Contains(input[i].ToString()))
                    {
                        machine.tempString += input[i];
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(machine.tempString) || !String.IsNullOrWhiteSpace(machine.tempString))
                        {
                            machine.MaxStringForNumber(machine.tempString, 0);
                        }
                        machine.CurrentState = machine.InitialStates;
                        machine.tempString = "";
                    }
                }
            }

            for (int i = 0; i < fsm.Count; i++)
            {
                fsm[i].MaxStringForNumber(fsm[i].tempString, 0);
            }

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                var currentItem = numbers[i];
                var nextItem = numbers[i + 1];

                if (currentItem.Item2 == nextItem.Item2)
                {
                    if (Int32.Parse(currentItem.Item1.Priority) < Int32.Parse(nextItem.Item1.Priority))
                    {
                        numbers.Remove(nextItem);
                    }
                    else
                    {
                        numbers.Remove(currentItem);
                    }
                }
            }

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                var currentItem = numbers[i];
                var nextItem = numbers[i + 1];

                var currentItemIndex = i;
                var nextItemIndex = i + 1;


                if (currentItem.Item2.Contains(nextItem.Item2) || nextItem.Item2.Contains(currentItem.Item2))
                {
                    if (currentItem.Item2.Length > nextItem.Item2.Length)
                    {
                        numbers.RemoveAt(nextItemIndex);
                        i = 0;
                    }
                    else if (currentItem.Item2.Length < nextItem.Item2.Length)
                    {
                        numbers.RemoveAt(currentItemIndex);
                        i = 0;
                    }
                    else
                    {
                        if (Int32.Parse(currentItem.Item1.Priority) < Int32.Parse(nextItem.Item1.Priority))
                        {
                            numbers.RemoveAt(nextItemIndex);
                        }
                        else
                        {
                            numbers.RemoveAt(currentItemIndex);
                        }

                        i = 0;
                    }
                }
            }



            foreach (var item in numbers)
            {
                Console.WriteLine($"<{ item.Item1.MachineName} : {item.Item2}>");
            }

            //CurrentState = InitialStates;
        }

        public static void ThirdTask2(string input, List<FiniteStateMachine> fsm, int k)
        {

            
                for (int i = 0; i < fsm.Count; i++)
                {
                    var machine = fsm[i];

                    k += machine.MaxString(input, k).Item2;
                } 
        }
    }
}
