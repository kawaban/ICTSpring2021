using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    delegate void DisplayMessage(string text);

    class Brain
    {
        DisplayMessage displayMessage;
        public Brain(DisplayMessage displayMessageDelegate)
        {
            displayMessage = displayMessageDelegate;
        }

        string[] nonZeroDigits = { "1", "2", "3", "4", "5", "6", "7", "8", "9"};
        string[] digits = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
        string[] zero = { "0" };
        string[] operation = { "+", "-", "*", "/", "mod" };
        string[] equal = { "=" };
        string[] clear = { "AC" };
        string[] root = { "√" };

        enum State
        {
            Zero,
            AccumulateDigits,
            ComputePending,
            Compute,
        }

        State currentState = State.Zero;
        string previousNumber = "";
        string currentNumber = "";
        string currentOperation = "";
       
        int numDigits = 0;
        public void ProcessSignal(string message)
        {
            switch (currentState)
            {
                case State.Zero:
                    ProcessZeroState(message, false);
                    break;
                case State.AccumulateDigits:
                    ProcessAccumulateDigits(message, false);
                    break;
                case State.ComputePending:
                    ProcessComputePending(message, false);
                    break;
                case State.Compute:
                    ProcessCompute(message, false);
                    break;
                default:
                    break;
                    
            }
        }

       
        void ProcessZeroState(string message, bool income)
        {
            if (income)
            {
                currentState = State.Zero;
                if(clear.Contains(message))
                {
                    currentNumber = "";
                    previousNumber = "";
                    displayMessage("0");
                }
                else
                {
                    displayMessage(message);
                }
                
            }
            else
            {
                if (nonZeroDigits.Contains(message))
                {
                    ProcessAccumulateDigits(message, true);
                }
            }
        }

        void ProcessAccumulateDigits(string message, bool income)
        {
            if (income)
            {
                currentState = State.AccumulateDigits;
                if (zero.Contains(currentNumber))
                {
                    currentNumber = message;
                }
                else
                {
                    currentNumber = currentNumber + message;
                }

                displayMessage(currentNumber);
              


            }
            else
            {
                if (digits.Contains(message))
                {
                    ProcessAccumulateDigits(message, true);
                }
                else if (operation.Contains(message))
                {
                 
                    displayMessage(message);
                    ProcessComputePending(message, true);     
                }
                else if (equal.Contains(message)) {
                 
                    ProcessCompute(message, true);

                }
                else if (clear.Contains(message))
                {
                    
                    ProcessZeroState(message, true);
                }
                else if (root.Contains(message))
                {
                    double m = double.Parse(currentNumber);
                    currentNumber = (Math.Sqrt(m).ToString());
                    displayMessage(currentNumber);
                }

            }
        }


        void ProcessComputePending(string message, bool income)
        {
            if (income)
            {
                currentState = State.ComputePending;
                
                previousNumber = currentNumber;
                

                currentNumber = "";
                currentOperation = message;

               

               

            }
            else
            {
                if (digits.Contains(message))
                {
                    ProcessAccumulateDigits(message, true);
                }
                else if (clear.Contains(message))
                {
                  
                    ProcessZeroState(message, true);
                }
               
            }
        }

        void ProcessCompute(string message, bool income)
        {
            if (income)
            {
                currentState = State.Compute;
                double a = double.Parse(previousNumber);
                double b = double.Parse(currentNumber);

                if (currentOperation == "+")
                {
                    currentNumber = (a + b).ToString();
                }
                else if (currentOperation == "-")
                {
                    currentNumber = (a - b).ToString();
                }
                else if (currentOperation == "*")
                {
                    currentNumber = (a * b).ToString();
                }
                else if (currentOperation == "/")
                {
                    currentNumber = (a / b).ToString();
                }
                else if (currentOperation == "mod")
                {
                    currentNumber = (a % b).ToString();
                }

                displayMessage(currentNumber);
                previousNumber = currentNumber;

                

                currentNumber = "";



            }
            else
            {
                if (nonZeroDigits.Contains(message))
                {
                    ProcessAccumulateDigits(message, true);
                }
                else if (zero.Contains(message))
                {
                    ProcessZeroState(message, true);
                }
                else if (clear.Contains(message))
                {
                    ProcessZeroState(message, true);
                }
            }
        }

       

    }
}
