using GuideToGalaxy.Store;

namespace GuideToGalaxy.Parser
{
    /// <summary>
    /// This class is used as a factory to provide relevant parsers based on the type
    /// </summary>
    class ParserFactory
    {
        /// <summary>
        /// Types of parsers
        /// </summary>
        public enum ParserType
        {
            Conversion,
            Separator,
            Input,
            Question
        }

        /// <summary>
        /// Return the relevant parser based on the type
        /// </summary>
        /// <param name="parserType"></param>
        /// <returns></returns>
        public static IParser GetParser(ParserType parserType)
        {
            IParser parser = null;
            switch(parserType)
            {
                case ParserType.Conversion:
                    parser = new ConversionParser(ConversionData.GetConversionData());
                    break;
                case ParserType.Separator:
                    parser = new SeparatorParser(new Store.SeparatorData());
                    break;
                case ParserType.Input:
                    parser = new InputParser();
                    break;
                case ParserType.Question:
                    parser = new QuestionParser();
                    break;
                default:
                    break;
            }
            return parser;
        }
    }
}
