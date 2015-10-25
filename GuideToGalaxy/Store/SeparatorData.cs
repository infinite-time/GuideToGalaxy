using System.Collections.Generic;

namespace GuideToGalaxy.Store
{
    /// <summary>
    /// This class is used to store the separator used in text input
    /// </summary>
    class SeparatorData
    {
        private IList<string> separator;

        /// <summary>
        /// Constructor which initializes the local variable
        /// </summary>
        public SeparatorData()
        {
            separator = new List<string>();
        }

        /// <summary>
        /// Getter/setter
        /// </summary>
        public IList<string> Separator
        {
            get { return separator; }
            set { separator = value; }
        }
    }
}
