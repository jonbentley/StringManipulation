using System;
using System.Collections.Generic;
using System.Text;

namespace StringManipulation.Extensions
{
  /// <summary>
  /// 
  /// </summary>
  public static class ListStringExtension
  {
    /// <summary>
    /// Take a List of Strings and concatenate the items into a single String, delimited by a supplied value
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string ListToString(this List<string> s)
    {
        return s.ListToString(Environment.NewLine);
    }

    public static string ListToString(this List<string> s, string delimiter)
    {
      if (s == null) return string.Empty;
      if (s.Count == 0) return string.Empty;
 
      // Loop round the List building up a string of its contents
      var sb = new StringBuilder();
      bool first = true;
      foreach (string item in s)
      {
        if (!first)
        {
          sb.Append(delimiter);
        }

        sb.Append(item);
        first = false;
      }

      return sb.ToString();
    }
  }
}
