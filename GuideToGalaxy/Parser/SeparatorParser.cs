using GuideToGalaxy.Store;
using System.Xml;

namespace GuideToGalaxy.Parser
{
    /// <summary>
    /// This class is used to parse the separator used in the input text
    /// </summary>
    class SeparatorParser : IParser
    {
        private SeparatorData separatorData;
        private const string ConversionDataXML = "ConversionData.xml";
        private const string XPathForSeparator = "/conversiondata/question";

        /// <summary>
        /// Constructor which initializes the local variables
        /// </summary>
        /// <param name="separatorData"></param>
        public SeparatorParser(SeparatorData separatorData)
        {
            this.separatorData = separatorData;
        }

        /// <summary>
        /// Provide only getter for SeparatorData
        /// </summary>
        public SeparatorData SeparatorData
        {
            get { return separatorData; }
        }

        /// <summary>
        /// Read the data from xml and store it in SeparatorData
        /// </summary>
        public void Read()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(ConversionDataXML);
            XmlNodeList nodeList = doc.DocumentElement.SelectNodes(XPathForSeparator);
            foreach (XmlNode node in nodeList)
            {
                string separatorName = node.SelectSingleNode("separator").InnerText;
                separatorData.Separator.Add(separatorName);
            }
        }
    }
}
