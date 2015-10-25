using GuideToGalaxy.Parser;
using GuideToGalaxy.Store;
using System;

namespace GuideToGalaxy
{
    /// <summary>
    /// This is the main class of the program which ignites the process
    /// </summary>
    class Driver
    {
        static void Main(string[] args)
        {
            //Initialize the converter values and other related data and store it
            Initializer initializer = new Initializer();
            initializer.Start();

            //Parse the input and store it
            IParser inputParser = ParserFactory.GetParser(ParserFactory.ParserType.Input);
            inputParser.Read();

            //Generate answers for questions and store it
            IParser quesionParser = ParserFactory.GetParser(ParserFactory.ParserType.Question);
            quesionParser.Read();

            //Display the answers generated
            foreach(string answer in AnswerData.GetAnswerData().Answers)
            {
                Console.WriteLine(answer);
            }

            //Wait till the user enters a key
            Console.Read();
        }
    }
}
