using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalc
{
    class CalcEngine
    {

        //
        // Operation Constants.
        //
        public enum Operator : int
        {
            eUnknown = 0,
            eAdd = 1,
            eSubtract = 2,
            eMultiply = 3,
            eDivide = 4
        }


        //
        // Module-Level Constants
        //

        private static double negativeConverter = -1;
        private static string versionInfo = "Calculator v2.0.1.1";

        //
        // Module-level Variables.
        //

        private static double numericAnswer;
        private static string stringAnswer = "";
        private static Operator calcOperation;
        private static double firstNumber;
        private static double secondNumber;
        private static bool secondNumberAdded;
        private static bool decimalAdded;

        //
        // Class Constructor.
        //

        public CalcEngine()
        {
            decimalAdded = false;
            secondNumberAdded = false;
        }

        public static string Result { get; set; }

        public static double Resultt { get; set; }

        //
        // Returns the custom version string to the caller.
        //

        public static string GetVersion()
        {
            return (versionInfo);
        }
        //
        // Called when the Date key is pressed.
        //

        public static string GetDate()
        {
            DateTime curDate = new DateTime();
            curDate = DateTime.Now;

            stringAnswer = String.Concat(curDate.ToShortDateString(), " ", curDate.ToLongTimeString());

            return (stringAnswer);
        }

        //
        // Called when a number key is pressed on the keypad.
        //

        public static string CalcNumber(string KeyNumber)
        {
            stringAnswer += KeyNumber;
            return stringAnswer;
        }

        //
        // Called when an operator is selected (+, -, *, /)
        //

        public static void CalcOperation(Operator calcOper)
        {
            if (stringAnswer != "" && !secondNumberAdded)
            {
                NumberFormatInfo p = new NumberFormatInfo();
                p.NumberDecimalSeparator = ",";
                firstNumber = Convert.ToDouble(stringAnswer, p);
                // if (stringAnswer.Contains(",")) { }
                calcOperation = calcOper;
                stringAnswer = "";
                decimalAdded = false;
            }
        }

        //
        // Called when the +/- key is pressed.
        //

        public static string CalcSign()
        {
            double numHold;

            if (stringAnswer != "")
            {
                numHold = System.Convert.ToDouble(stringAnswer);
                stringAnswer = System.Convert.ToString(numHold * negativeConverter);
            }

            return (stringAnswer);
        }

        //
        // Called when the . key is pressed.
        //

        public static string CalcDecimal()
        {
            if (!decimalAdded && !secondNumberAdded)
            {
                if (stringAnswer != "")
                {
                    stringAnswer += ".";
                }
                else
                {
                    stringAnswer = "0.";
                }

                decimalAdded = true;

            }

            return stringAnswer;
        }
        //
        // Called when the factorial key is pressed
        //
        public static string CalcFactorial()
        {
            int numHold;
            if (stringAnswer != "" && !stringAnswer.Contains(".") && !stringAnswer.Contains(",") && !stringAnswer.Contains("-"))
            {
                NumberFormatInfo p = new NumberFormatInfo();
                p.NumberDecimalSeparator = ",";
                numHold = Convert.ToInt32(stringAnswer, p);
                int fact = 1;
                for (int i = numHold; i > 0; i--)
                {
                    fact *= i;
                }
                stringAnswer = System.Convert.ToString(fact);
            }
            else
            {
                stringAnswer = "Mistake";
            }

            return stringAnswer;
        }

        public static string CalcSqrt()
        {
            double numHold;
            if (stringAnswer != "")
            {
                numHold = Math.Sqrt(Convert.ToDouble(stringAnswer));
                stringAnswer = numHold.ToString();
            }
            return stringAnswer;
        }

        public static string CalcPow()
        {
            double numHold;
            if (stringAnswer != "")
            {
                numHold = Math.Pow(Convert.ToDouble(stringAnswer), 2);
                stringAnswer = numHold.ToString();
            }
            return stringAnswer;
        }
        //
        // Called when = is pressed.
        //

        public static string CalcEqual()
        {
            bool validEquation = false;

            if (stringAnswer != "")
            {
                NumberFormatInfo p = new NumberFormatInfo();
                p.NumberDecimalSeparator = ",";
                secondNumber = Convert.ToDouble(stringAnswer, p);
                secondNumberAdded = true;

                switch (calcOperation)
                {
                    case Operator.eUnknown:
                        validEquation = false;
                        break;

                    case Operator.eAdd:
                        firstNumber += secondNumber;
                        numericAnswer = firstNumber;
                        validEquation = true;
                        break;

                    case Operator.eSubtract:
                        numericAnswer = firstNumber - secondNumber;
                        //Resultt = numericAnswer;
                        validEquation = true;
                        break;

                    case Operator.eMultiply:
                        numericAnswer = firstNumber * secondNumber;
                        validEquation = true;
                        break;

                    case Operator.eDivide:
                        numericAnswer = firstNumber / secondNumber;
                        validEquation = true;
                        break;

                    default:
                        validEquation = false;
                        break;
                }

                if (validEquation)
                    stringAnswer = System.Convert.ToString(numericAnswer);
            }
            // double.TryParse(stringAnswer, out firstNumber);
            return stringAnswer;
        }

        //
        // Resets the various module-level variables for the next calculation.
        //

        public static void CalcReset()
        {
            numericAnswer = 0;
            firstNumber = 0;
            secondNumber = 0;
            stringAnswer = Result;
            calcOperation = Operator.eUnknown;
            decimalAdded = false;
            secondNumberAdded = false;
        }
    }
}
