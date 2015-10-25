using System.Collections.Generic;
namespace GuideToGalaxy.Store
{
    /// <summary>
    /// This class holds the data related to conversion between galactic(roman) and decimal.
    /// This has been implemented as singleton class to enable anywhere access once it is initialized.
    /// </summary>
    class ConversionData
    {
        private static ConversionData conversionData;
        private IDictionary<string, string> conversionMap;
        private IDictionary<string, string> repetitionMap;

        /// <summary>
        /// Static method which creates the instance
        /// </summary>
        /// <returns></returns>
        public static ConversionData GetConversionData()
        {
            if(conversionData == null)
            {
                conversionData = new ConversionData();
            }
            return conversionData;
        }

        /// <summary>
        /// Private constructor which instantiates the local variables
        /// </summary>
        private ConversionData()
        {
            conversionMap = new Dictionary<string, string>();
            repetitionMap = new Dictionary<string, string>();
        }

        /// <summary>
        /// Set/Get conversionmap
        /// </summary>
        public IDictionary<string, string> ConversionMap
        {
            get { return conversionMap; }
            set { conversionMap = value; }
        }

        /// <summary>
        /// Set/Get repetitio related information for symbols
        /// </summary>
        public IDictionary<string, string> RepetitionMap
        {
            get { return repetitionMap; }
            set { repetitionMap = value; }
        }
    }
}
