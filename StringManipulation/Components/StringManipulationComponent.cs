

namespace StringManipulation.Components
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using StringManipulation.Extensions;

    public class StringManipulationComponent
    {
        public string DeleteEmptyLines(string textInput)
        {
            List<string> filtered = new List<string>();

            // loop round every line in the list
            foreach (var line in textInput.StringToList())
            {
                if (!line.IsNullOrEmpty())
                {
                    filtered.Add(line);
                }
            }

            return filtered.ListToString();
        }

        public string DeleteLinesContaining(string textInput, string searchString, bool caseSensitive)
        {
            if (searchString.IsNullOrEmpty())
            {
                return textInput;
            }

            // set up string comparison depending on whether or not we want case insensitive comparison
            StringComparison stringComparison = caseSensitive ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;

            List<string> filtered = new List<string>();

            // loop round every line in the list
            foreach (var line in textInput.StringToList())
            {
                if (!line.Contains(searchString, stringComparison))
                {
                    filtered.Add(line);
                }
            }

            return filtered.ListToString();
        }

        public string DeleteLinesNotContaining(string textInput, string searchString, bool caseSensitive)
        {
            if (searchString.IsNullOrEmpty())
            {
                return textInput;
            }

            // set up string comparison depending on whether or not we want case insensitive comparison
            StringComparison stringComparison = caseSensitive ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;

            List<string> filtered = new List<string>();

            // loop round every line in the list
            foreach (var line in textInput.StringToList())
            {
                if (line.Contains(searchString, stringComparison))
                {
                    filtered.Add(line);
                }
            }

            return filtered.ListToString();
        }

        /// <summary>
        /// remove all text before the first occurrence of the search string
        /// </summary>
        /// <param name="textInput"></param>
        /// <returns></returns>
        public string Trim(string textInput)
        {
            List<string> filtered = new List<string>();

            // loop round every line in the list
            foreach (var line in textInput.StringToList())
            {
                filtered.Add(line.Trim());
            }

            return filtered.ListToString();
        }

        /// <summary>
        /// remove all text before the first occurrence of the search string
        /// </summary>
        /// <param name="textInput"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public string TrimBeforeFirst(string textInput, string searchString)
        {
            if (searchString.IsNullOrEmpty()) return textInput;

            List<string> filtered = new List<string>();

            // loop round every line in the list
            foreach (var line in textInput.StringToList())
            {
                if (line.Contains(searchString))
                {
                    // split on the delimiter, keep the 'after'
                    var parsed = line.ParseString(false, searchString);
                    filtered.Add(parsed[1]);
                }
                else
                {
                    // if the search string is not found return the whole line
                    filtered.Add(line);
                }
            }

            return filtered.ListToString();
        }

        /// <summary>
        /// remove all text after the first occurrence of the search string
        /// </summary>
        /// <param name="textInput"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public string TrimAfterFirst(string textInput, string searchString)
        {
            if (searchString.IsNullOrEmpty()) return textInput;

            List<string> filtered = new List<string>();

            // loop round every line in the list
            foreach (var line in textInput.StringToList())
            {
                // split on the delimiter, keep the 'after'
                var parsed = line.ParseString(false, searchString);
                filtered.Add(parsed[0]);
            }

            return filtered.ListToString();

        }

        public string SortAscendingString(string textInput)
        {
            var textList = textInput.StringToList();
            textList.Sort();
            return textList.ListToString();
        }

        public string SortDescendingString(string textInput)
        {
            List<string> textList = textInput.StringToList();
            textList = textList.OrderByDescending(x => x).ToList();
            return textList.ListToString();
        }

        /// <summary>
        /// sort numbers "1 a" is a string not a number
        /// 1      2      10     100      1 a        1 b      a
        /// </summary>
        /// <param name="textInput"></param>
        /// <returns></returns>
        public string SortAscendingNumeric(string textInput)
        {
            var textList = textInput.StringToList();
            textList = textList.OrderBy(x => x, new NumericAndAlphaComparer()).ToList();
            return textList.ListToString();
        }

        public string SortDescendingNumeric(string textInput)
        {
            string sortedAsc = this.SortAscendingNumeric(textInput);
            List<string> sortedDesc = sortedAsc.StringToList();
            sortedDesc.Reverse();

            return sortedDesc.ListToString();
        }

        public string SortLineLength(string textInput)
        {
            var textList = textInput.StringToList();
            textList = textList.OrderBy(x => x.Length).ThenBy(x => x).ToList();
            return textList.ListToString();
        }

        public string ReverseCurrentOrder(string textInput)
        {
            var text = textInput.StringToList();
            text.Reverse();

            return text.ListToString();
        }

        /// <summary>
        /// remove duplicates leaving just one of each, not necessary to sort first
        /// </summary>
        /// <param name="textInput"></param>
        /// <returns></returns>
        public string RemoveDuplicates(string textInput)
        {
            List<string> filtered = new List<string>();

            // loop round every line in the list
            foreach (var line in textInput.StringToList())
            {
                // add if not already present
                if (!filtered.Contains(line))
                {
                    filtered.Add(line);
                }
            }

            return filtered.ListToString();
        }

        /// <summary>
        /// find unique items, i.e. remove all occurrences of items that have duplicates
        /// </summary>
        /// <param name="textInput"></param>
        /// <returns></returns>
        public string FindUniqueItems(string textInput)
        {
            List<string> inputList = textInput.StringToList();

            // loop round every line in the list - and for each see if there 1 of it
            List<string> filtered = inputList.Where(line => inputList.Count(x => x == line) == 1).ToList();

            return filtered.ListToString();
        }

        /// <summary>
        /// find every occurrence of every item that is a duplicate
        /// this is the same as removing all unique items
        /// </summary>
        /// <param name="textInput"></param>
        /// <returns></returns>
        public string FindAllItemsThatAreDuplicates(string textInput)
        {
            List<string> inputList = textInput.StringToList();

            // loop round every line in the list - and for each see if there are > 1 of it
            List<string> filtered = inputList.Where(line => inputList.Count(x => x == line) > 1).ToList();

            return filtered.ListToString();
        }

        /// <summary>
        /// how many occurrences of each item is there - makes sense to remove duplicates first but not necessary
        /// </summary>
        /// <param name="textInput"></param>
        /// <returns></returns>
        public string CountOccurrences(string textInput)
        {
            List<string> inputList = textInput.StringToList();

            // count the most commonly repeated item so we know how much to pad the counts with
            var grouped = inputList.ToLookup(x => x);
            int maxRepetitions = grouped.Max(x => x.Count());

            int paddingLength = maxRepetitions.ToString().Length;

            // List<string> maxRepeatedItems = grouped.Where(x => x.Count() == maxRepetitions)
            //    .Select(x => x.Key).ToList();

            List<string> filtered = new List<string>();

            // loop round every line in the list
            foreach (var line in textInput.StringToList())
            {
                int count = inputList.Count(x => x == line);

                // prefix with padded (so can sort) count
                filtered.Add(count.ToString().PadLeft(paddingLength, ' ') + " - " + line);
            }

            return filtered.ListToString();
        }

        /// <summary>
        /// add up all lines that are numeric
        /// non numeric lines are commented and ignored
        /// </summary>
        /// <param name="textInput"></param>
        /// <returns></returns>
        public string Sum(string textInput)
        {
            double total = 0.0;
            int lineCount = 0;
            string result = string.Empty;

            // loop round every line in the list
            foreach (var line in textInput.StringToList())
            {
                // ignore blank lines
                if (!string.IsNullOrWhiteSpace(line))
                {
                    lineCount += 1;
                    if (double.TryParse(line.Trim(), out double value))
                    {
                        total += value;
                    }
                    else
                    {
                        result += $"line {lineCount} does not contain a number so is ignored : {line}{Environment.NewLine}";
                    }
                }
            }

            result += total.ToString(CultureInfo.InvariantCulture) + Environment.NewLine + total.ToString("0,0.000,000") +
                                         Environment.NewLine + total.ToString("N2") + Environment.NewLine + Environment.NewLine + textInput;
            return result;
        }

        public string InsertAtStartOfEachLine(string textInput, string insertText)
        {
            List<string> filtered = new List<string>();

            // loop round every line in the list
            foreach (var line in textInput.StringToList())
            {
                filtered.Add(insertText + line);
            }

            return filtered.ListToString();
        }

        public string InsertAtEndOfEachLine(string textInput, string insertText)
        {
            List<string> filtered = new List<string>();

            // loop round every line in the list
            foreach (var line in textInput.StringToList())
            {
                filtered.Add(line + insertText);
            }

            return filtered.ListToString();
        }

        public Tuple<string, int> InsertAtPosition(string textInput, int position, string insertText)
        {
            List<string> filtered = new List<string>();
            int countLinesTooShort = 0;

            // loop round every line in the list
            foreach (var line in textInput.StringToList())
            {
                if (line.Length < position)
                {
                    filtered.Add(line + " <line too short>");
                    countLinesTooShort += 1;
                }
                else
                {
                    string newLine = line.Substring(0, position) + insertText + line.Substring(position);
                    filtered.Add(newLine);
                }
            }

            return Tuple.Create(filtered.ListToString(), countLinesTooShort);
        }

        /// <summary>
        /// find items that are in one list but not the other
        /// </summary>
        /// <returns></returns>
        public string List1NotList2(string textInput1, string textInput2)
        {
            List<string> onlyInList1 = new List<string>();
            List<string> list2 = textInput2.StringToList();

            // loop round every line in list 1
            foreach (var list1Item in textInput1.StringToList())
            {
                // add if not in list 2
                if (!list2.Contains(list1Item))
                {
                    onlyInList1.Add(list1Item);
                }
            }

            return onlyInList1.ListToString();
        }

        /// <summary>
        /// find items that are in one both of 2 lists
        /// </summary>
        /// <returns></returns>
        public string List1AndList2(string textInput1, string textInput2)
        {
            List<string> inList1AndList2 = new List<string>();
            List<string> list2 = textInput2.StringToList();

            // loop round every line in list 1
            foreach (var list1Item in textInput1.StringToList())
            {
                // add if in list 2
                if (list2.Contains(list1Item))
                {
                    inList1AndList2.Add(list1Item);
                }
            }

            return inList1AndList2.ListToString();
        }

        public string FindAndReplace(string textInput, string fromText, string toText, int nthOccurrence, int fromCol, int toCol)
        {
            if (string.IsNullOrEmpty(fromText)) return textInput;

            // if it's a straight replace then do all rows in one hit
            if (nthOccurrence == 0 && fromCol == 0 && toCol == 0)
            {
                return textInput.Replace(fromText, toText);
            }

            // sanity test
            if (fromCol > toCol && (toCol != 0))
            {
                throw new Exception($"The from column number '{fromCol}' is greater that the to column '{toCol}'");
            }

            List<string> result = new List<string>();

            // loop round every line
            foreach (var line in textInput.StringToList())
            {
                // isolate the columns we are looking at
                var splitString = this.SplitStringInto3OnPositions(line, fromCol, toCol);

                // do replacing on the relevant columns
                string middleUpdated = splitString.Item2.ReplaceNthOccurrence(fromText, toText, nthOccurrence);

                // glue it back together
                result.Add(splitString.Item1 + middleUpdated + splitString.Item3);
            }

            return result.ListToString();
        }

        /// <summary>
        /// split a string into 3
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="fromPosition">the 1 based position of where we split from </param>
        /// <param name="toPosition">the 1 based position of where we split to</param>
        /// <returns></returns>
        public Tuple<string, string, string> SplitStringInto3OnPositions(string inputText, int fromPosition, int toPosition)
        {
            string start;
            string middle = string.Empty;
            string end = string.Empty;

            // sort out the default values of 0
            if (fromPosition == 0) fromPosition = 1;
            if (toPosition == 0) toPosition = inputText.Length;

            // option 1 - string too short
            if (inputText.Length < fromPosition)
            {
                start = inputText;
                return Tuple.Create(start, middle, end);
            }

            // option 2 - the middle is populated but the end is empty
            if (inputText.Length <= toPosition)
            {
                start = inputText.Substring(0, fromPosition - 1);
                middle = inputText.Substring(fromPosition - 1);
                return Tuple.Create(start, middle, end);
            }

            // option 3 - all 3 bits are populated
            start = inputText.Substring(0, fromPosition - 1);
            middle = inputText.Substring(fromPosition - 1, toPosition - fromPosition + 1);
            end = inputText.Substring(toPosition);
            return Tuple.Create(start, middle, end);
        }
    }

}
