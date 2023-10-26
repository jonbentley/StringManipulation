using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation.Components
{
    using System.Globalization;

    /// <summary>
    /// compare 2 strings.
    /// If they are numeric then treat as numbers, shuffle alpha's to the top
    /// </summary>
    public class NumericAndAlphaComparer : IComparer<string>
    {
        /// <summary>
        /// Method to determine if a string is a number
        /// </summary>
        /// <param name="value">String to test</param>
        /// <returns>True if numeric</returns>
        public static bool IsNumeric(string value)
        {
            return double.TryParse(value, out _);
        }

        /// <inheritdoc />
        public int Compare(string s1, string s2)
        {
            const int s1GreaterThanS2 = 1;
            const int s2GreaterThanS1 = -1;

            var isNumeric1 = IsNumeric(s1);
            var isNumeric2 = IsNumeric(s2);

            if (isNumeric1 && isNumeric2)
            {
                var i1 = Convert.ToDecimal(s1);
                var i2 = Convert.ToDecimal(s2);

                if (i1 > i2)
                {
                    return s1GreaterThanS2;
                }

                if (i1 < i2)
                {
                    return s2GreaterThanS1;
                }

                return 0;
            }

            // if one is a string bring to the top
            if (isNumeric1)
            {
                return s2GreaterThanS1;
            }

            if (isNumeric2)
            {
                return s1GreaterThanS2;
            }

            // both strings, do normal sort
            return string.Compare(s1, s2, true, CultureInfo.InvariantCulture);
        }
    }
}
