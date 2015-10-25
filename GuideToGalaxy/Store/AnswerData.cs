using System.Collections.Generic;

namespace GuideToGalaxy.Store
{
    /// <summary>
    /// This class is used to store the answers. This has been implemented as singleton because once the
    /// answers are generated, they can be accessed from anywhere and at anytime
    /// </summary>
    class AnswerData
    {
        private static AnswerData answerData;
        IList<string> answers;

        /// <summary>
        /// Static method which constructs the instance
        /// </summary>
        /// <returns></returns>
        public static AnswerData GetAnswerData()
        {
            if(answerData == null)
            {
                answerData = new AnswerData();
            }
            return answerData;
        }

        /// <summary>
        /// Private constructor which initializes local variables
        /// </summary>
        private AnswerData()
        {
            answers = new List<string>();
        }

        /// <summary>
        /// Set/Get answers
        /// </summary>
        public IList<string> Answers
        {
            get { return answers; }
            set { answers = value; }
        }
    }
}
