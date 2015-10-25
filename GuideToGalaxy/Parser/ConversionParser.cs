using GuideToGalaxy.Store;
using System.Xml;

namespace GuideToGalaxy.Parser
{
    /// <summary>
    /// This class reads the conversion related data from xml and stores it in ConversionData class
    /// </summary>
    class ConversionParser : IParser
    {
        private ConversionData conversionData;
        private const string ConversionDataXML = "ConversionData.xml";
        private const string XPathForSymbols = "/conversiondata/symbols/symbol";

        /// <summary>
        /// Constructor which initializes the local variable used for ConversionData
        /// </summary>
        /// <param name="conversionData"></param>
        public ConversionParser(ConversionData conversionData)
        {
            this.conversionData = conversionData;
        }

        /// <summary>
        /// Provide only getter for ConversionData
        /// </summary>
        public ConversionData ValueData
        {
            get { return conversionData; }
        }

        /// <summary>
        /// Read the data from xml and store it in ConversionData
        /// </summary>
        public void Read()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(ConversionDataXML);
            XmlNodeList nodeList = doc.DocumentElement.SelectNodes(XPathForSymbols);
            foreach (XmlNode node in nodeList)
            {
                string symbolName = node.SelectSingleNode("name").InnerText;
                string symbolValue = node.SelectSingleNode("value").InnerText;
                conversionData.ConversionMap.Add(symbolName, symbolValue);
            }
        } 
    }
}
