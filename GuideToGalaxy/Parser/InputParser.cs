using GuideToGalaxy.Store;
using GuideToGalaxy.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GuideToGalaxy.Parser
{
    /// <summary>
    /// This class reads the input given to the program and parses it
    /// </summary>
    class InputParser : IParser
    {
        private const string TestInput = "TestInput.txt";
        private const string QuestionStarterType1 = "How";
        private const string QuestionStarterType2 = "how";
        private const string QuestionEndingType = "?";
        private const string ErrorString = "I have no idea what you are talking about";

        /// <summary>
        /// Read the questions and parse
        /// </summary>
        public void Read()
        {
            string line;
            StreamReader file = new StreamReader(TestInput);
            ValueData valueData = ValueData.GetValueData();
            QuestionData questionData = QuestionData.GetQuestionData();

            // Read the input text line by line
            while ((line = file.ReadLine()) != null)
            {
                // Split the string based on "is" separator
                string[] inputParts = line.Split(new[] { " is " }, StringSplitOptions.RemoveEmptyEntries);
                // Split the first part of the string based on space
                string[] commodities = inputParts[0].Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                // Check if this question or not
                if (!inputParts[0].Contains(QuestionStarterType1) && !inputParts[0].Contains(QuestionStarterType2))
                {
                    if (commodities.Length == 1)
                    {
                        // Validate the inputs
                        if (InputValidator.Validate(inputParts[1]))
                        {
                            string value = ConversionData.GetConversionData().ConversionMap[inputParts[1]];
                            valueData.ValueMap.Add(commodities[0], Int32.Parse(value));
                            valueData.GalacticValueMap.Add(commodities[0], inputParts[1]);
                        }
                    }
                    if (commodities.Length > 2)
                    {
                        string[] rightPart = inputParts[0].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        string[] leftPart = inputParts[1].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        int credit = Int32.Parse(leftPart[0]);
                        CalculateValueAndUpdate(rightPart, credit);
                    }
                }
                // This part is a question
                else if (inputParts[0].Contains(QuestionStarterType1) || inputParts[0].Contains(QuestionStarterType2))
                {
                    if (inputParts.Length > 1)
                    {
                        string[] rightPart = inputParts[1].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        List<string> items = rightPart.ToList();
                        items.Remove(QuestionEndingType);
                        questionData.SetQuestion(items);
                    }
                    else
                    {
                        questionData.SetQuestion(new List<string>(){"Invalid"});
                    }
                }
                
            }
        }

        /// <summary>
        /// Calculate the value of the commodity based on values of the galactic values available
        /// </summary>
        /// <param name="commodities"></param>
        /// <param name="credit"></param>
        private void CalculateValueAndUpdate(string[] commodities, int credit)
        {
            ValueData valueData = ValueData.GetValueData();
            IList<int> values = new List<int>(commodities.Length);
            int commodityCounter = 0;
            string commodityForWhichValueIsToBeFound = String.Empty;
            foreach(string commodity in commodities)
            {  
                if(valueData.ValueMap.ContainsKey(commodity))
                {
                    commodityCounter++;
                }
                else
                {
                    if(String.IsNullOrEmpty(commodityForWhichValueIsToBeFound))
                    {
                        commodityForWhichValueIsToBeFound = commodity;
                    }
                }
            }
            string galacticValue = string.Empty;
            foreach (string commodity in commodities)
            {
                if (valueData.GalacticValueMap.ContainsKey(commodity))
                {
                    galacticValue += valueData.GalacticValueMap[commodity];
                }
            }
            int decimalValue = ConversionCalculator.ConvertGalacticNumtoInt(galacticValue);
            int commodityValue = credit / decimalValue;
            valueData.ValueMap.Add(commodityForWhichValueIsToBeFound, commodityValue);

        }
    }
}
