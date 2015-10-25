using System.Collections.Generic;

namespace GuideToGalaxy.Store
{
    /// <summary>
    /// This class holds question related data. This is implemented as singleton for ease of use once questions 
    /// are initialized by parser.
    /// </summary>
    class QuestionData
    {
        private static QuestionData questionData;
        private List<List<string>> questions;

        /// <summary>
        /// Static method which creates the instance
        /// </summary>
        /// <returns></returns>
        public static QuestionData GetQuestionData()
        {
            if(questionData == null)
            {
                questionData = new QuestionData();
            }
            return questionData;
        }

        /// <summary>
        /// Private constructor which instantiates the local variables
        /// </summary>
        private QuestionData()
        {
            questions = new List<List<string>>();
        }

        /// <summary>
        /// Set individual question
        /// </summary>
        /// <param name="question"></param>
        public void SetQuestion(List<string> question)
        {
            questions.Add(question);
        }

        /// <summary>
        /// Get all the questions
        /// </summary>
        /// <returns></returns>
        public List<List<string>> GetQuestions()
        {
            return questions;
        }


    }
}
