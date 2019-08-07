using System;
using System.Collections.Generic;
using System.Linq;

namespace BrainfuckInterpreter
{
    public class Interpreter
    {
        enum Commands
        {
            IncrementPtr,
            DecrementPtr,
            IncrementByte,
            DecrementByte,
            OutputByte,
            InputByte,
            JumpForward,
            JumpBackward
        };
        private int[] memory;
        private int pointer;
        private string commands = "><+-.,[]";
        public Interpreter(int size = 30000)
        {
            Reset();
        }

        public void Reset(int size = 30000)
        {
            memory = new int[30000];
            pointer = 0;
        }

        public void Interpret(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
                int commandIndex = commands.IndexOf(current);

                Commands currentCommand = (Commands)commandIndex;

                switch (currentCommand)
                {
                    case Commands.IncrementPtr:
                        pointer++;
                        if (pointer >= memory.Length)
                        {
                            pointer = 0;
                        }
                        break;
                    case Commands.DecrementPtr:
                        pointer--;
                        if (pointer < 0)
                        {
                            pointer = memory.Length - 1;
                        }
                        break;
                    case Commands.IncrementByte:
                        memory[pointer]++;
                        break;
                    case Commands.DecrementByte:
                        memory[pointer]--;
                        break;
                    case Commands.OutputByte:
                        Console.Write((char)memory[pointer]);
                        break;
                    case Commands.InputByte:
                        string userInput = Console.ReadLine();
                        if (!string.IsNullOrEmpty(userInput))
                        {
                            char val = userInput[0];
                            memory[pointer] = (byte)val;
                        }
                        break;
                    case Commands.JumpForward:
                        if (memory[pointer] == 0)
                        {
                            int counter = 1;
                            while (counter > 0)
                            {
                                i++;
                                char c = input[i];
                                if (c == '[')
                                {
                                    counter++;
                                }
                                else if (c == ']')
                                {
                                    counter--;
                                }
                            }

                        }
                        break;
                    case Commands.JumpBackward:
                        if (memory[pointer] != 0)
                        {
                            int counter = 1;
                            while (counter > 0)
                            {
                                i--;
                                char c = input[i];
                                if (c == '[')
                                {
                                    counter--;
                                }
                                else if (c == ']')
                                {
                                    counter++;
                                }
                            }
                            i--;
                        }
                        break;
                    default:
                        throw new Exception("Invalid command in the input");
                }
            }
        }
    }
}