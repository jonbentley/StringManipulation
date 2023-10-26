namespace StringManipulation.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Xml;

    public static class StringExtension
    {
        public static bool Contains(this string source, string toCheck, StringComparison stringComparison)
        {
            return source?.IndexOf(toCheck, stringComparison) >= 0;
        }

        public static string HtmlEncode(this string s)
        {
            return HttpUtility.HtmlEncode(s);
        }

        public static string HtmlDecode(this string s)
        {
            return HttpUtility.HtmlDecode(s);
        }


        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static bool IsNotNullOrEmpty(this string s)
        {
            return !string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// Same as native .IsNullorEmpty
        /// but adds addition test regarding zero
        /// assume the following are zero
        /// 0 00 000 0000 (etc)  
        /// these are not
        /// .0  0.  0.0
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNullOrEmptyOrZeros(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return true;
            }

            s = s.Replace("0", string.Empty);

            return s.IsNullOrEmpty();
        }

        /// <summary>
        /// Truncate a string to a set length
        /// String.SubStr() exceptions if the string is too short so this avoids repetitive faffy testing
        /// </summary>
        /// <param name="s"></param>
        /// <param name="lengthToTruncateTo"></param>
        /// <returns></returns>
        public static string TruncateToLength(this string s, int lengthToTruncateTo)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            if (s.Length <= lengthToTruncateTo)
            {
                return s;
            }

            string truncatedString = s.Substring(0, lengthToTruncateTo);
            return truncatedString;
        }

        /// <summary>
        /// Truncate a string to a set length
        /// String.SubStr() exceptions if the string is too short so this avoids repetitive faffy testing
        /// If the string is truncated then append the supplied message to the end to indicate that truncation has taken place
        /// </summary>
        /// <param name="s"></param>
        /// <param name="lengthToTruncateTo"></param>
        /// <param name="truncateMessage"></param>
        /// <returns></returns>
        public static string TruncateToLength(this string s, int lengthToTruncateTo, string truncateMessage)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            if (s.Length <= lengthToTruncateTo)
            {
                return s;
            }

            string truncatedString = s.Substring(0, lengthToTruncateTo);
            return truncatedString + truncateMessage;
        }

        #region FormatXMLString

        /// <summary>
        /// Returns formatted xml string (indent and newlines) from unformatted XML string
        /// </summary>
        /// <param name="unformattedXml">Unformatted xml string.</param>
        /// <returns>Formatted xml string and any exceptions that occur.</returns>

        public static string FormatXmlString(this string unformattedXml)
        {
            // Use this when we go to .Net framework 3.5
            // This code will also do a bit of "tiding up" of your xml (eg namespanes names), it is not just a format-job
            // Run on some of our \OspreyTest\TestXMLFiles and you'll see that "caf:" gets replaced with "SOAPSDK1:"
            // System.Xml.Linq.XElement element = System.Xml.Linq.XElement.Parse(xmlString);
            // return element.ToString();
            if (string.IsNullOrEmpty(unformattedXml))
            {
                return string.Empty;
            }

            // does the formatting
            XmlTextWriter xmlTextWriter = null;

            // will hold formatted xml
            StringBuilder stringBuilder = new StringBuilder();

            try
            {
                // load unformatted xml into a dom
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(unformattedXml);

                // pumps the formatted xml into the StringBuilder above
                StringWriter stringWriter = new StringWriter(stringBuilder);

                // point the xtw at the StringWriter
                xmlTextWriter = new XmlTextWriter(stringWriter);

                // we want the output formatted
                xmlTextWriter.Formatting = Formatting.Indented;

                // get the dom to dump its contents into the xtw
                xmlDocument.WriteTo(xmlTextWriter);
            }
            catch (Exception)
            {
                return unformattedXml;
            }
            finally
            {
                // clean up even if error
                if (xmlTextWriter != null)
                    xmlTextWriter.Close();
            }

            // return the formatted xml
            return stringBuilder.ToString();
        }

        #endregion

        #region SplitStringOnLength

        /// <summary>
        /// Split a string into fixed length blocks
        /// "12345678".SplitStringIntoFixedLengths(3)
        /// returns
        ///   123
        ///   456
        ///   78
        /// </summary>
        /// <param name="s"></param>
        /// <param name="lengthOfSplit"></param>
        /// <returns></returns>
        public static List<string> SplitStringIntoFixedLengths(this string s, int lengthOfSplit)
        {
            var result = new List<string>();

            if (string.IsNullOrEmpty(s))
            {
                return result;
            }

            // If there's a silly length return whole string
            if (lengthOfSplit <= 0)
            {
                result.Add(s);
                return result;
            }

            string workingString = s;

            // split string into chunks
            do
            {
                string nextChunk = workingString.Substring(0, Math.Min(workingString.Length, lengthOfSplit));
                result.Add(nextChunk);
                workingString = workingString.Remove(0, nextChunk.Length);
            }
            while (workingString.Length > 0)
                ;

            return result;
        }

        #endregion

        #region ParseString

        /// <summary>
        /// This is a crude attempt to mimic the superior Rexx function "PARSE VAR"
        /// .Net is pretty poor at string handling in that it takes several index and substring calls
        /// plus a fair bit of processing to 'unpack' complex strings into target variables.
        /// Regex helps at times, groups especially, but even these can't help if you're seaching for 
        /// multiple delimiters and some are present but some are not (i.e. is just says Success=False)
        /// 
        ///Under certain circumstances this function will help
        ///
        ///Parameters
        ///==========
        ///   1) A source string (that is parsed)
        ///   2) A list of delimeter strings
        ///
        ///Processing
        ///==========
        ///
        ///All characters up to (but excluding) the 1st delimiter are put in results item[0]
        ///All subsequent characters up to (but excluding) the 2nd delimiter are put in the results item[1]
        ///etc
        ///
        ///All chars after the last delimiter go into the last variable
        ///
        ///If any delimiter is not found then all unassigned chars go into the next item
        ///
        /// There will always be 1 item more in the results that there are delimiters
        ///
        ///To Use
        ///======
        ///
        /// string phrase="This is the day! OK, got it ?"
        /// 
        /// var results = phrase.ParseString(false, "is", "!", "got i")
        /// 
        ///         results[0]  contains  "This ".
        ///         results[1]  contains  " the day"
        ///         results[2]  contains   " OK, "
        ///         results[3]  contains   "t ?"
        ///
        /// var results = "The Date =23/12/2010 9:12:56 AM".ParseString(true, "Date =", "/", "/", " ", ":", ":", " ")
        /// 
        ///         results[0]=The
        ///         results[1]=23
        ///         results[2]=12
        ///         results[3]=2010
        ///         results[4]=9
        ///         results[5]=12
        ///         results[6]=56
        ///         results[7]=AM
        ///
        /// </summary>
        /// <param name="s">the string to be parsed</param>
        /// <param name="trimItems">wheter the split strings are to have start and end spaces removed</param>
        /// <param name="delimiters">a list of string delimiters to parse the string on</param>
        /// <returns></returns>
        public static List<string> ParseString(this string s, bool trimItems, params string[] delimiters)
        {
            List<string> results = new List<string>();

            string textToParse = s;

            // Loop round the delimiters looking for each in turn
            foreach (string delim in delimiters)
            {
                // If the delimiter is null then assume it is NOT found
                if ((!string.IsNullOrEmpty(delim)) && textToParse.IndexOf(delim) >= 0)
                {
                    // Find the position of the delimiter and store the text before it and after it
                    int position = textToParse.IndexOf(delim);
                    string before = textToParse.Substring(0, position);
                    string after = textToParse.Substring(position + delim.Length);

                    // Store the before in the results list and send the remainder off to be parsed again
                    if (trimItems)
                    {
                        before = before.Trim();
                    }

                    results.Add(before);
                    textToParse = after;
                }
                else
                {
                    // if a delimiter is not found then all unassigned chars go into proceeding variable
                    if (trimItems)
                    {
                        textToParse = textToParse.Trim();
                    }

                    results.Add(textToParse);
                    textToParse = string.Empty;
                }

                // No need to terminate if textToParse is empty - use the looping to fully populate the results list
            }

            // Anything that is left is passed back too as the last results
            results.Add(textToParse);

            return results;
        }

        #endregion

        #region CSV encoding / decoding

        private enum State
        {
            AtBeginningOfToken, // parser is expecting the first character of a token ie; at start of line or just after a comma
            InNonQuotedToken,   // parser is working through a token expecting a comma to complete it
            InQuotedToken,      // parser is working through a token expecting a quote to complete it
            ExpectingComma,     // parser has just finished a closing quote so next character should be a comma
            InEscapedCharacter  // parser has found a slash so next characer is excaped
        };

        /// <summary>
        /// Extends a string with the ability to parse a comma seperated string into an array of individual strings
        /// Taking into account values surrounded in "'s with commas inside the quoted value.
        /// </summary>
        /// <param name="source">The source string to parse</param>
        /// <returns>string array containing each value found</returns>
        public static string[] CsvSplit(this string source)
        {
            List<string> splitString = new List<string>();
            List<int> slashesToRemove = new List<int>();
            State state = State.AtBeginningOfToken;
            char[] sourceCharArray = source.ToCharArray();
            int tokenStart = 0;
            int len = sourceCharArray.Length;

            // work through the source string character by character...
            for (int i = 0; i < len; ++i)
            {
                switch (state)
                {
                    case State.AtBeginningOfToken:
                        if (sourceCharArray[i] == '"')
                        {
                            state = State.InQuotedToken;
                            slashesToRemove = new List<int>();
                            continue;
                        }

                        if (sourceCharArray[i] == ',')
                        {
                            // we have found and empty value so add it to the output
                            splitString.Add(string.Empty);
                            tokenStart = i + 1;
                            continue;
                        }

                        state = State.InNonQuotedToken;
                        continue;

                    case State.InNonQuotedToken:
                        if (sourceCharArray[i] == ',')
                        {
                            // we have found a token so add it to the output
                            splitString.Add(source.Substring(tokenStart, i - tokenStart));
                            state = State.AtBeginningOfToken;
                            tokenStart = i + 1;
                        }

                        continue;

                    case State.InQuotedToken:
                        if (sourceCharArray[i] == '"')
                        {
                            state = State.ExpectingComma;
                            continue;
                        }

                        if (sourceCharArray[i] == '\\')
                        {
                            state = State.InEscapedCharacter;
                            slashesToRemove.Add(i - tokenStart);
                            continue;
                        }

                        continue;

                    case State.ExpectingComma:
                        if (sourceCharArray[i] != ',')
                            throw new ApplicationException("Expecting comma");
                        string stringWithSlashes = source.Substring(tokenStart, i - tokenStart);
                        foreach (int item in slashesToRemove.Reverse<int>())
                            stringWithSlashes = stringWithSlashes.Remove(item, 1);
                        splitString.Add(stringWithSlashes.Substring(1, stringWithSlashes.Length - 2));
                        state = State.AtBeginningOfToken;
                        tokenStart = i + 1;
                        continue;

                    case State.InEscapedCharacter:
                        state = State.InQuotedToken;
                        continue;
                }
            }

            // Finally deal with the end of the line
            switch (state)
            {
                case State.AtBeginningOfToken:
                    splitString.Add(string.Empty);
                    return splitString.ToArray();

                case State.InNonQuotedToken:
                    splitString.Add(source.Substring(tokenStart, source.Length - tokenStart));
                    return splitString.ToArray();

                case State.InQuotedToken:
                    throw new ApplicationException("Expecting ending quote");

                case State.ExpectingComma:
                    string stringWithSlashes = source.Substring(tokenStart, source.Length - tokenStart);
                    foreach (int item in slashesToRemove.Reverse<int>())
                        stringWithSlashes = stringWithSlashes.Remove(item, 1);
                    splitString.Add(stringWithSlashes.Substring(1, stringWithSlashes.Length - 2));
                    return splitString.ToArray();

                case State.InEscapedCharacter:
                    throw new ApplicationException("Expecting escaped character");
            }

            // If we get here then something's gone awry
            throw new ApplicationException("Unexpected error");
        }

        // Extends string type with ability to construct a CSV line, reverse to CSVSplit
        public static string CsvJoin(this string[] source)
        {
            return "\"" + string.Join("\",\"", source) + "\"";
        }

        // ForEach iterator
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T item in source) action(item);
        }

        #endregion

        /// <summary>
        /// Replaces all occurances of a specified string with another specified string.
        /// including the option to ignore the case of the search string.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="oldValue">The string to be replaced</param>
        /// <param name="newValue">The string to replace all occurances of the old value</param>
        /// <param name="caseSensitive">If false then the oldValue is matched regardless of the case</param>
        /// <returns></returns>
        public static string Replace(this string s, string oldValue, string newValue, bool caseSensitive)
        {
            if (caseSensitive)
            {
                return s.Replace(oldValue, newValue);
            }
            else
            {
                // If oldValue and newValue match then just return the original string
                if ((oldValue.ToUpper() == newValue.ToUpper()) || oldValue.IsNullOrEmpty())
                {
                    return s;
                }
                else
                {
                    // Take copy of the new string 
                    string newString = s;

                    // Find the old string ignoring case
                    int idx = newString.ToUpper().IndexOf(oldValue.ToUpper());

                    // If the old string has been found then replace it
                    while (idx >= 0)
                    {
                        newString = newString.Substring(0, idx) + newValue + newString.Substring(idx + oldValue.Length);
                        idx = newString.ToUpper().IndexOf(oldValue.ToUpper());
                    }

                    return newString;
                }
            }
        }

        // split a line on a delimiter and return as a list
        public static List<string> StringToList(this string s)
        {
            return s.StringToList(Environment.NewLine);
        }

        public static List<string> StringToList(this string s, string delimiter)
        {
            string[] linesArray = Regex.Split(s, Environment.NewLine);
            List<string> lines = new List<string>();

            foreach (string line in linesArray)
            {
                lines.Add(line);
            }

            return lines;
        }

        /// <summary>
        /// replace the nth occurrence of a string, within a string
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="find"></param>
        /// <param name="replace"></param>
        /// <param name="nthOccurrence"></param>
        /// <returns></returns>
        public static string ReplaceNthOccurrence(this string inputText, string find, string replace, int nthOccurrence)
        {
            // assume 0 means all
            if (nthOccurrence == 0)
            {
                return inputText.Replace(find, replace);
            }

            // find all matches
            MatchCollection matchCollection = Regex.Matches(inputText, Regex.Escape(find));

            // if there are less matches than the occurrence then make no changes
            if (matchCollection.Count >= nthOccurrence)
            {
                Match match = matchCollection[nthOccurrence - 1];
                string removed = inputText.Remove(match.Index, match.Length);
                string replaced = removed.Insert(match.Index, replace);
                return replaced;
            }

            return inputText;
        }
    }
}
