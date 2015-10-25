using System.Linq;

namespace GuideToGalaxy.Utility
{
    /// <summary>
    /// This class is used to calculate decimal equivalent of galactic number (roman).
    /// Note: This class has more scope for improvement and has to be made generic so that 
    /// there is no code change when symbol mapping changes. Due to time constraint, I have not done this.
    /// </summary>
    class ConversionCalculator
    {
        /// <summary>
        /// Static method which is used to find the decimal equivalent of roman value
        /// </summary>
        /// <param name="galacticValue"></param>
        /// <returns></returns>
        public static int ConvertGalacticNumtoInt(string galacticValue)
        {
            var decimalValue = 0;
            var lastNumHandled = 0;
            foreach (var item in galacticValue.Reverse())
            { 
                switch (item)
                {
                    case 'I':
                        decimalValue = handleLastTwo(1, lastNumHandled, decimalValue);
                        lastNumHandled = 1;
                        break;
                    case 'V':
                        decimalValue = handleLastTwo(5, lastNumHandled, decimalValue);
                        lastNumHandled = 5;
                        break;
                    case 'X':
                        decimalValue = handleLastTwo(10, lastNumHandled, decimalValue);
                        lastNumHandled = 10;
                        break;
                    case 'L':
                        decimalValue = handleLastTwo(50, lastNumHandled, decimalValue);
                        lastNumHandled = 50;
                        break;
                    case 'C':
                        decimalValue = handleLastTwo(100, lastNumHandled, decimalValue);
                        lastNumHandled = 100;
                        break;
                    case 'D':
                        decimalValue = handleLastTwo(500, lastNumHandled, decimalValue);
                        lastNumHandled = 500;
                        break;
                    case 'M':
                        decimalValue = handleLastTwo(1000, lastNumHandled, decimalValue);
                        lastNumHandled = 1000;
                        break;
                }
            }
            return decimalValue;
        }

        /// <summary>
        /// Handle the last two values parsed to decide whether they have to be subtracted or added
        /// </summary>
        /// <param name="dec"></param>
        /// <param name="lastNum"></param>
        /// <param name="lastDec"></param>
        /// <returns></returns>
        public static int handleLastTwo(int dec, int lastNum, int lastDec)
        {
            if (lastNum > dec)
            {
                return lastDec - dec;
            }
            else
            {
                return lastDec + dec;
            }
        }
    }
}

