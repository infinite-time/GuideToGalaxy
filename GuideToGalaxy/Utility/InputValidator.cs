using GuideToGalaxy.Store;

namespace GuideToGalaxy.Utility
{
    /// <summary>
    /// This class validates whether the input received is a valid galactic input or not
    /// </summary>
    class InputValidator
    {
        public static bool Validate(string value)
        {
            bool valid = false;
            ConversionData conversionData = ConversionData.GetConversionData();
            if(conversionData.ConversionMap.Keys.Contains(value))
            {
                valid = true;
            }
            return valid;
        }
    }
}
