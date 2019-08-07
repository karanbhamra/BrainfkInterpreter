using System;
using System.Collections.Generic;
using System.IO;

namespace BrainfuckInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                System.Console.WriteLine("Pass a file containing the commands.");
            }

            var input = File.ReadAllLines(args[0]);
            Interpreter interpreter = new Interpreter();

            string command = "";
            foreach (var line in input)
            {
                command += line;
            }

            interpreter.Interpret(command);
        }
    }
}