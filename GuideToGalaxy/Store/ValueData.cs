using System.Collections.Generic;

namespace GuideToGalaxy.Store
{
    /// <summary>
    /// This class is used to hold the value of galactic objects and their corresponding earth value
    /// </summary>
    class ValueData
    {
        private static ValueData valueData;

        // Stores the values of galactic objects in decimals
        private IDictionary<string, int> valueMap;
        // Stores the values of galactic objects in galactic units (roman)
        private IDictionary<string, string> galacticValueMap;

        /// <summary>
        /// Static method which instantiates the class
        /// </summary>
        /// <returns></returns>
        public static ValueData GetValueData()
        {
            if(valueData == null)
            {
                valueData = new ValueData();
            }
            return valueData;
        }

        /// <summary>
        /// Private constructor which initializes the variables
        /// </summary>
        private ValueData()
        {
            valueMap = new Dictionary<string, int>();
            galacticValueMap = new Dictionary<string, string>();
        }

        /// <summary>
        /// Getter/setter for value map
        /// </summary>
        public IDictionary<string, int> ValueMap
        {
            get { return valueMap; }
            set { valueMap = value; }
        }

        /// <summary>
        /// Getter/setter for galactic map
        /// </summary>
        public IDictionary<string, string> GalacticValueMap
        {
            get { return galacticValueMap; }
            set { galacticValueMap = value; }
        }
    }
}
