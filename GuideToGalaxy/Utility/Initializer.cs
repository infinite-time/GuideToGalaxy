using GuideToGalaxy.Parser;

namespace GuideToGalaxy
{
    /// <summary>
    /// This class initializes conversion and separator reading from xml
    /// </summary>
    class Initializer
    {
        public void Start ()
	    {
            // Get the conversion mapping
            IParser conversionParser = ParserFactory.GetParser(ParserFactory.ParserType.Conversion);
            conversionParser.Read();
            //

            // Get the separator used in questions
            IParser separatorParser = ParserFactory.GetParser(ParserFactory.ParserType.Separator);
            separatorParser.Read();
	    }        
    }
}
