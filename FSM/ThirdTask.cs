using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    class ThirdTask
    {

        private static bool end = true;

        public static void TestThree(string input, List<FiniteStateMachine> fsm)
        {
            string input2 = input;
            while (end)
            {
                for (int i = 0; i < fsm.Count; i++)
                {
                    input2 = Test(fsm[i], input2);

                    if (input2 == null)
                    {
                        break;
                    }
                } 
            }

            FiniteStateMachine.numbers.Information();
        }

        private static string Test(FiniteStateMachine machine, string input)
        {
            string tempString = "";
            string output = "";

            for (int j = 0; j < input.Length; j++)
            {
                if (machine.Alphabet.Contains(input[j].ToString()))
                {
                    machine.StateTransitionFunction(machine.CurrentState, input[j].ToString());

                    tempString += input[j];

                    //Console.WriteLine();

                    if (machine.ContainsList(machine.CurrentState, machine.FinalyStates))
                    {
                        output = tempString;
                    }

                    if (machine.CurrentState.Contains(machine.StopSymbol))
                    {
                        if (output.Length > 0)
                        {
                            FiniteStateMachine.numbers.Add(new Tuple<string, string>(machine.MachineName, output));
                        }

                        if (tempString.Length > 1)
                        {
                            j--;
                        }

                        machine.CurrentState = machine.InitialStates;

                        //return input.Substring(j);
                    }
                }
                if (j == input.Length - 1)
                {

                    end = false;
                    if (output.Length > 0)
                    {
                        FiniteStateMachine.numbers.Add(new Tuple<string, string>(machine.MachineName, output));
                    }

                    return null;

                }
                if (!machine.Alphabet.Contains(input[j].ToString()))
                {
                    if (output.Length > 0)
                    {
                        FiniteStateMachine.numbers.Add(new Tuple<string, string>(machine.MachineName, output));

                        return input.Substring(j);
                    }

                    return input;
                }
            }
            return input;
        }


        public static void ThreeTask(string input, List<FiniteStateMachine> fsm, int startIndex = 0)
        {
            int k = startIndex;
            bool end = true;

            while (end)
            {
                for (int i = 0; i < fsm.Count; i++)
                {
                    FiniteStateMachine machine = fsm[i];

                    string tempString = "";
                    string output = "";

                    for (int j = k; j < input.Length; j++)
                    {
                        if (machine.Alphabet.Contains(input[j].ToString()))
                        {
                            machine.StateTransitionFunction(machine.CurrentState, input[j].ToString());

                            tempString += input[j];

                            Console.WriteLine();

                            if (machine.ContainsList(machine.CurrentState, machine.FinalyStates))
                            {
                                output = tempString;
                            }

                            if (machine.CurrentState.Contains(machine.StopSymbol))
                            {
                                if (output.Length > 0)
                                {
                                    FiniteStateMachine.numbers.Add(new Tuple<string, string>(machine.MachineName, output));
                                }

                                if (tempString.Length > 1)
                                {
                                    j--;
                                }

                                machine.CurrentState = machine.InitialStates;

                                break;
                            }
                        }
                        if (j == input.Length - 1)
                        {
                            if (output.Length > 0)
                            {
                                FiniteStateMachine.numbers.Add(new Tuple<string, string>(machine.MachineName, output));
                            }

                            end = false;
                            k = j;
                            break;
                        }
                        if (!machine.Alphabet.Contains(input[j].ToString()))
                        {
                            if (output.Length > 0)
                            {
                                FiniteStateMachine.numbers.Add(new Tuple<string, string>(machine.MachineName, output));
                                i = 0;
                            }
                            k = j;

                            break;
                        }
                    }
                }
            }


            FiniteStateMachine.numbers.Information();
        }
    }
}
