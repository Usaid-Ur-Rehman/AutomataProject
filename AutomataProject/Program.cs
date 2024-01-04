using System;

namespace AUTOMATA_PROJECT
{
    class CFGParser
    {
        private string input;
        private int index;

        public CFGParser(string input)
        {
            this.input = input;
            this.index = 0;
        }

        public bool ParseRE1()
        {
            index = 0;
            return ParseBorC() && ParseABStar() && ParseFiveAs() && ParseBAStar() && ParseBorC();
        }

        public bool ParseRE2()
        {
            index = 0;
            return ParseZeroOrOneStar() && Parse1001Or011Star() && ParseZeroOrOneStar() && ParseConsecutiveThreeOnes() && Parse00Or11() && ParseZeroOrOneStar();
        }

        public bool ParseCustomRegex()
        {
            //aur koi RE ke liye
            return true;
        }

        private bool ParseBorC()
        {
            if (index < input.Length && (input[index] == 'b' || input[index] == 'c'))
            {
                index++;
                return true;
            }
            return false;
        }

        private bool ParseABStar()
        {
            while (index + 1 < input.Length && input[index] == 'a' && input[index + 1] == 'b')
            {
                index += 2;
            }
            return true;
        }

        private bool ParseFiveAs()
        {
            if (index + 4 < input.Length &&
                input[index] == 'a' && input[index + 1] == 'a' && input[index + 2] == 'a' && input[index + 3] == 'a' && input[index + 4] == 'a')
            {
                index += 5;
                return true;
            }
            return false;
        }

        private bool ParseBAStar()
        {
            while (index + 1 < input.Length && input[index] == 'b' && input[index + 1] == 'a')
            {
                index += 2;
            }
            return true;
        }

        private bool ParseZeroOrOneStar()
        {
            while (index < input.Length && (input[index] == '0' || input[index] == '1'))
            {
                index++;
            }
            return true;
        }

        private bool Parse1001Or011Star()
        {
            while (index + 3 < input.Length &&
                (input[index] == '0' && input[index + 1] == '0' && input[index + 2] == '1' && input[index + 3] == '1') ||
                (input[index] == '0' && input[index + 1] == '1' && input[index + 2] == '1' && input[index + 3] == '0'))
            {
                index += 4;
            }
            return true;
        }

        private bool ParseConsecutiveThreeOnes()
        {
            if (index + 2 < input.Length && input[index] == '1' && input[index + 1] == '1' && input[index + 2] == '1')
            {
                index += 3;
                return true;
            }
            return false;
        }

        private bool Parse00Or11()
        {
            if (index + 1 < input.Length && (input[index] == '0' && input[index + 1] == '0' || input[index] == '1' && input[index + 1] == '1'))
            {
                index += 2;
                return true;
            }
            return false;
        }
    }

    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*");
                Console.WriteLine();
                Console.WriteLine("Enter Your Choice (1 for RE1, 2 for RE2, 3 for CustomRegex, 0 to exit): ");
                Console.WriteLine();
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1 || choice == 2 || choice == 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*");
                    Console.WriteLine();
                    Console.WriteLine($"Regular Expression: {(choice == 1 ? "(b+c)(ab)*(aaaaa)(ba)*(b+c)" : (choice == 2 ? "(0+1)*(1001+011)*(0+1)*(111)(00+11)(0+1)*" : "CustomRegex"))}");
                    string input = Console.ReadLine();

                    CFGParser parser = new CFGParser(input);
                    bool matchesPattern;

                    switch (choice)
                    {
                        case 1:
                            matchesPattern = parser.ParseRE1();
                            break;
                        case 2:
                            matchesPattern = parser.ParseRE2();
                            break;
                        case 3:
                            matchesPattern = parser.ParseCustomRegex();
                            break;
                        default:
                            matchesPattern = false;
                            break;
                    }

                    Console.WriteLine($"Output: {matchesPattern}");
                    Console.WriteLine();
                }
                else if (choice == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*");
                    Console.WriteLine("Exiting the program...");
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*_*");
                    Console.WriteLine();
                    Console.WriteLine("Please Enter A Valid Choice! ");
                }
            }
        }
    }
}

