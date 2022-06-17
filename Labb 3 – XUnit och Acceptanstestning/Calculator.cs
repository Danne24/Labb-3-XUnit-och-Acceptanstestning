using System;
using System.Collections.Generic;
using System.Text;

namespace Labb_3___XUnit_och_Acceptanstestning
{
    public class Calculator
    {
        public Calculator()
        {

        }

        public Calculator(double num1, double num2)
        {
            this.Num1 = num1;
            this.Num2 = num2;
        }

        public List<CalculatorHistory> ListOfCalculatorHistory = new List<CalculatorHistory>();

        private double Sum { get; set; }
        private double Num1 { get; set; }
        private double Num2 { get; set; }

        public int ChosenIndex { get; set; }

        public double UserInPutProp { get; set; }

        public void MainMenu()
        {
            bool loop = true;
            while (loop == true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Calculator! Please input your desired outcome.");
                Console.WriteLine("1 --- Addition.");
                Console.WriteLine("2 --- Subtraction.");
                Console.WriteLine("3 --- Division.");
                Console.WriteLine("4 --- Multiplication.");
                Console.WriteLine("5 --- Power.");
                Console.WriteLine("6 --- See your calculator history.");
                Console.WriteLine("7 --- close the application.");

                UserInPutMethod();

                switch (UserInPutProp)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Please make a choice.");
                        this.Num1 = UseOldResultOrInputNewNumber();

                        Console.Clear();
                        Console.WriteLine("Please make a choice.");
                        this.Num2 = UseOldResultOrInputNewNumber();

                        Addition();
                        Console.Clear();
                        DisplayResult("+");

                        Console.WriteLine();
                        Console.WriteLine("Press enter to return to the main menu.");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Please make a choice.");
                        this.Num1 = UseOldResultOrInputNewNumber();

                        Console.Clear();
                        Console.WriteLine("Please make a choice.");
                        this.Num2 = UseOldResultOrInputNewNumber();

                        Subtraction();
                        Console.Clear();
                        DisplayResult("-");

                        Console.WriteLine();
                        Console.WriteLine("Press enter to return to the main menu.");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Please make a choice.");
                        this.Num1 = UseOldResultOrInputNewNumber();

                        Console.Clear();
                        Console.WriteLine("Please make a choice.");
                        this.Num2 = UseOldResultOrInputNewNumber();

                        Division();
                        Console.Clear();
                        DisplayResult("/");

                        Console.WriteLine();
                        Console.WriteLine("Press enter to return to the main menu.");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Please make a choice.");
                        this.Num1 = UseOldResultOrInputNewNumber();

                        Console.Clear();
                        Console.WriteLine("Please make a choice.");
                        this.Num2 = UseOldResultOrInputNewNumber();

                        Multiplication();
                        Console.Clear();
                        DisplayResult("*");

                        Console.WriteLine();
                        Console.WriteLine("Press enter to return to the main menu.");
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Please make a choice.");
                        this.Num1 = UseOldResultOrInputNewNumber();

                        Console.Clear();
                        Console.WriteLine("Please make a choice.");
                        this.Num2 = UseOldResultOrInputNewNumber();

                        Power();
                        Console.Clear();
                        DisplayResult("^");

                        Console.WriteLine();
                        Console.WriteLine("Press enter to return to the main menu.");
                        Console.ReadKey();
                        break;

                    case 6:
                        Console.Clear();
                        foreach (CalculatorHistory item in ListOfCalculatorHistory)
                        {
                            item.PrintCalculatorHistory();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press enter to return to the main menu.");
                        Console.ReadKey();
                        break;

                    case 7:
                        loop = false;
                        break;

                    default:
                        break;
                }
            }
        }

        public double Addition()
        {
            this.Sum = this.Num1 + this.Num2;
            return this.Sum;
        }

        public double Subtraction()
        {
            this.Sum = this.Num1 - this.Num2;
            return this.Sum;
        }

        public double Division()
        {
            this.Sum = this.Num1 / this.Num2;
            return this.Sum;
        }

        public double Multiplication()
        {
            this.Sum = this.Num1 * this.Num2;
            return this.Sum;
        }

        public double Power()
        {
            this.Sum = Math.Pow(this.Num1, this.Num2);
            return this.Sum;
        }

        public double UserInPutMethod()
        {
            bool loop = true;
            while (loop == true)
            {
                try
                {
                    // The line below needs to be commented out for the XUnit tests to work properly!
                    this.UserInPutProp = Convert.ToDouble(Console.ReadLine());
                    loop = false;
                }
                catch
                {
                    Console.WriteLine("Error: You are only allowed to enter numbers! Try again.");
                }
            }

            return UserInPutProp;
        }

        public void DisplayResult(string symbol)
        {
            Console.WriteLine($"{this.Num1} {symbol} {this.Num2} = {this.Sum}.");

            ListOfCalculatorHistory.Add(new CalculatorHistory
            {
                CHNum1 = this.Num1,
                CHSymbol = symbol,
                CHNum2 = this.Num2,
                CHSum = this.Sum,
                CHDate = DateTime.Now
            });
        }

        public double UseOldResultOrInputNewNumber()
        {
            while (true)
            {
                Console.WriteLine("1 --- Input a new number.");
                Console.WriteLine("2 --- Use an existing number from the calculator's memory.");
                UserInPutMethod();
                if (this.UserInPutProp == 1)
                {
                    Console.WriteLine("Please input a number.");
                    return UserInPutMethod();
                }

                else if (this.UserInPutProp == 2 && ListOfCalculatorHistory.Count > 0)
                {
                    while (true)
                    {
                        this.ChosenIndex = 0;
                        Console.WriteLine("Choose a result from the calculator's memory by inputting the corresponding number.");
                        foreach (CalculatorHistory item in ListOfCalculatorHistory)
                        {
                            Console.Write($"{this.ChosenIndex} --- ");
                            // The line below needs to be commented out for the XUnit tests to work properly!
                            this.ChosenIndex++;
                            item.PrintCalculatorHistory();
                        }

                        // The line below needs to be commented out for the XUnit tests to work properly!
                        this.ChosenIndex = Convert.ToInt32(UserInPutMethod());

                        try
                        {
                            return ListOfCalculatorHistory[this.ChosenIndex].CHSum;
                        }
                        catch
                        {
                            Console.WriteLine("Error: That input is not allowed! Try again.");
                        }
                    }
                }

                else if (this.UserInPutProp == 2 && ListOfCalculatorHistory.Count < 1)
                {
                    Console.WriteLine("There are no saved results in the calculator's memory that you can utilize! Please manually input a new number instead.");
                }

                else
                {
                    Console.WriteLine("Invalid input, try again.");
                }
            }
        }
    }
}
