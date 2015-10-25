using GuideToGalaxy.Store;
using GuideToGalaxy.Utility;
using System;
using System.Collections.Generic;

namespace GuideToGalaxy.Parser
{
    /// <summary>
    /// This class is used to handle the questions in the input. This is used by Driver class.
    /// </summary>
    class QuestionParser : IParser
    {
        AnswerData answerData;
        QuestionData questionData;
        ValueData valueData;
        const string ReplyForInvalidQuestion = " I have no idea what you are talking about";

        /// <summary>
        /// Constructor which initializes the local variables
        /// </summary>
        public QuestionParser()
        {
            answerData = AnswerData.GetAnswerData();
            questionData = QuestionData.GetQuestionData();
            valueData = ValueData.GetValueData();
        }

        /// <summary>
        /// Read the questions and generate answers and store in AnswerData
        /// </summary>
        public void Read()
        {
            List<List<string>> questions = questionData.GetQuestions();
            foreach(List<string> question in questions)
            {
                int totalValue = 0;
                bool succesful = false;
                string galacticValue = string.Empty;
                string commodity = string.Empty;

                foreach(string item in question)
                {
                    if(valueData.GalacticValueMap.ContainsKey(item))
                    {
                        galacticValue += valueData.GalacticValueMap[item];
                        succesful = true;
                    }
                    else
                    {
                        if (item.Equals("Invalid", StringComparison.InvariantCulture))
                        {
                            answerData.Answers.Add(ReplyForInvalidQuestion);
                            succesful = false;
                            break;
                        }
                        else
                        {
                            commodity = question[question.Count - 1];
                        }
                    }
                }
                if(succesful)
                {
                    totalValue = !String.IsNullOrEmpty(commodity) ?
                        ConversionCalculator.ConvertGalacticNumtoInt(galacticValue) * valueData.ValueMap[commodity] :
                        ConversionCalculator.ConvertGalacticNumtoInt(galacticValue);
                    string itemNames = string.Empty;
                    foreach(string itemName in question)
                    {
                        itemNames += " " + itemName;
                    }
                    string answer = String.Format("{0} {1} is {2} {3}", itemNames, commodity, totalValue, "credits");
                    answerData.Answers.Add(answer);
                    galacticValue = string.Empty;
                }
            }
        }
    }
}
