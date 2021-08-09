using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Numerics;

namespace Robsoft.Extentions.DotNet
{
    public static class Int64Extention
    { 
        public static string NumberToWords(this BigInteger value)
        {
            return NumberToStringConverter.DefineWholeNumberToWords(value);
        }
    }

    /// <summary>
    /// Class <c>NumberToStringConverter</c> converts a 
    /// <c>BigInteger</c> to word text.
    /// </summary>
    sealed class NumberToStringConverter
    {
        /// <summary>
        /// checking for up to 20 <c>int</c> digit numbers
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string DefineWholeNumberToWords(BigInteger number)
        {
            var outputStr = string.Empty;
            long length = number.ToString().Length;
            if (length <= 0)
                return "Invalid number";

            try
            {
                var beginZero = false;
                var isDone = false;

                if (number > 0)
                {
                    var numberStr = number.ToString();

                    beginZero = numberStr.StartsWith("0");
                    var noOfDigits = numberStr.Length;
                    var pos = 0;
                    string place = "";
                    switch (noOfDigits)
                    {
                        case 1:
                            outputStr = DefineOnes(numberStr);
                            isDone = true;
                            break;
                        case 2:
                            outputStr = DefineTens(numberStr);
                            isDone = true;
                            break;
                        case 3:
                            pos = (noOfDigits % 3) + 1;
                            place = " hundred";
                            break;
                        case 4:
                        case 5:
                        case 6:
                            pos = (noOfDigits % 4) + 1;
                            place = " thousand";
                            break;
                        case 7:
                        case 8:
                        case 9:
                            pos = (noOfDigits % 7) + 1;
                            place = " million";
                            break;
                        case 10:
                        case 11:
                        case 12:
                            pos = (noOfDigits % 10) + 1;
                            place = " billion";
                            break;
                        case 13:
                        case 14:
                        case 15:
                            pos = (noOfDigits % 13) + 1;
                            place = " trillion";
                            break;
                        case 16:
                        case 17:
                        case 18:
                            pos = (noOfDigits % 16) + 1;
                            outputStr = " quadtrillion";
                            break;
                        case 19:
                        case 20:
                        case 30:
                            pos = (noOfDigits % 19) + 1;
                            place = " quintrillion";
                            break;
                        default:
                            isDone = true;
                            outputStr = "Number too large, this length hasn't been implemented yet";
                            break;
                    }

                    if (!isDone)
                    {
                        if (number.ToString().Substring(0, pos) != "0" && number.ToString().Substring(pos) != "0")
                        {
                            try
                            {
                                var newNum1 = Convert.ToInt64(number.ToString().Substring(0, pos));
                                var newNum2 = Convert.ToInt64(number.ToString().Substring(pos));
                                outputStr = DefineWholeNumberToWords(newNum1) + place + " " + DefineWholeNumberToWords(newNum2);
                            }
                            catch { }
                        }
                        else
                        {
                            var newNum1 = Convert.ToInt64(number.ToString().Substring(0, pos));
                            var newNum2 = Convert.ToInt64(number.ToString().Substring(pos));
                            outputStr = DefineWholeNumberToWords(newNum1) + place;
                        }
                        //check for trailing zeros
                        if (beginZero) outputStr = " and " + outputStr.Trim();
                    }

                    if (outputStr.Trim().Equals(place.Trim()))
                    {
                        outputStr = " ";
                    }
                }
            }
            catch { }

            return outputStr.Trim();
        }

        /// <summary>
        /// input param must be a 1 digit long string
        /// </summary>
        /// <param name="numberStr"></param>
        /// <returns></returns>
        private static string DefineOnes(string numberStr)
        {
            int number_ = 0;
            var res = Int32.TryParse(numberStr, out number_);
            if (!res || numberStr.Length > 1 || numberStr.Length <= 0)
            {
                return string.Empty;
            } 
            var outputStr = string.Empty;

            switch (number_)
            {
                case 0:
                    outputStr = "zero";
                    break;
                case 1:
                    outputStr = "one";
                    break;
                case 2:
                    outputStr = "two";
                    break;
                case 3:
                    outputStr = "three";
                    break;
                case 4:
                    outputStr = "four";
                    break;
                case 5:
                    outputStr = "five";
                    break;
                case 6:
                    outputStr = "six";
                    break;
                case 7:
                    outputStr = "seven";
                    break;
                case 8:
                    outputStr = "eight";
                    break;
                case 9:
                    outputStr = "nine";
                    break;
                default:
                    break;
            }
            return outputStr;
        }
      
        /// <summary>
        /// input param must be a 2 digit long string
        /// </summary>
        /// <param name="numberStr"></param>
        /// <returns>A string representing the input number parameter, in words,
        ///    without any leading, trailing, or embedded whitespace.</returns>
        private static string DefineTens(string numberStr)
        {
            int number_ = 0;
            var res = Int32.TryParse(numberStr, out number_);
            if (!res || numberStr.Length > 2 || numberStr.Length <= 0)
            {
                return string.Empty;
            }

           var outputStr = string.Empty;
            var numberFirstDigitStr_ = number_.ToString().Substring(0, 1);
            var numberOnesPartStr_ = number_.ToString().Substring(1, 1);


            switch (number_)
            {
                case 10:
                    outputStr = "ten";
                    break;
                case 11:
                    outputStr = "eleven";
                    break;
                case 12:
                    outputStr = "twelve";
                    break;
                case 13:
                    outputStr = "thirteen";
                    break;
                case 14:
                case 16:
                case 17:
                case 18:
                case 19:
                    outputStr = DefineOnes(numberOnesPartStr_) + "teen";
                    break;
                case 15:
                    outputStr = "fifteen";
                    break;
                case 20:
                    outputStr = "twenty";
                    break;
                case 30:
                    outputStr = "thirty";
                    break;
                case 40:
                case 50:
                case 60:
                case 70:
                case 80:
                case 90:
                    outputStr = DefineOnes(numberFirstDigitStr_) + "ty";
                    break;
                default:
                    if (number_ > 0)
                    {
                        var tensNumStr = number_.ToString().Substring(0, 1) + "0";
                        var onesNumStr = number_.ToString().Substring(1);
                        outputStr = DefineTens(tensNumStr) + " " + DefineOnes(onesNumStr);
                    }
                    break;
            }

            return outputStr;
        }

        private static ValueTuple<bool, Queue<BigInteger>> GetNumberParts(BigInteger number, out string message)
        {
            var results = new ValueTuple<bool, Queue<BigInteger>>(false, null);
            message = string.Empty;
            var numberParts = new Queue<BigInteger>();
            try
            {
                var numberLength = number.ToString().Length;
                if (numberLength <= 0)
                {
                    message = "Invalid number";
                    return results;
                }

                string source = number.ToString();
                string numberPartsStr = string.Join(",", source.Select((item, index) =>
                item.ToString().PadRight(
                    source.Length - index,
                    '0'
                    )));

                char[] numPartsStrSeparator = { ',' };
                numberPartsStr.
                    Split(numPartsStrSeparator, StringSplitOptions.RemoveEmptyEntries).
                    ToList().ForEach(c =>
                numberParts.Enqueue(Convert.ToInt64(c))
                );
                results.Item1 = true;
                results.Item2 = numberParts;
                return results;
                //outputStr = DefineOnes(Convert.ToInt64(_number.ToString().Substring(0, 1)));
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return new ValueTuple<bool, Queue<BigInteger>>(false, null);
            }
        }
    }
}
