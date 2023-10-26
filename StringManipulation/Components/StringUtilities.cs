using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web;

namespace StringManipulation.Components
{
  public class StringUtilities
  {
    /// <summary>
    /// Returns a specific value from the QueryString or a blank string if the key is not found
    /// </summary>
    /// <param name="Request">The current HttpRequest object</param>
    /// <param name="findString">The key for which to search the QueryString</param>
    /// <returns></returns>
    public static string GetValueFromQueryString(HttpRequest Request, string findString)
    {
      string queryString = Request.RawUrl;

      return GetValueFromQueryStringInternal(findString, queryString);
    }

    public static string GetValueFromQueryStringInternal(string findString, string queryString)
    {
      HttpUtility.UrlDecode(queryString);
      HttpUtility.HtmlDecode(queryString);

      if (queryString.Contains("customerName"))
      {
        queryString = RemoveInvalidCharactersFromCustomerName(queryString);
      }

      string[] queryStringVariables = queryString.Split('?');
      if (queryStringVariables.Length > 1)
      {
        string[] queryStringVariablesArray = queryStringVariables[1].Split('&');

        Hashtable queryStringVariablesHash = new Hashtable();
        foreach (string s in queryStringVariablesArray)
        {
          if (!s.StartsWith("ReturnUrl"))
          {
            queryStringVariablesHash.Add(s.Substring(0, s.IndexOf('=')), s.Substring(s.IndexOf('=')).Replace("%A3", "£").Replace("%a3", "£").Replace("=", string.Empty)
              .Replace("%20", " ").Replace("%c2", ",").Replace("%C2", ",").Replace("%ufffd", "£").Replace("%2f", "/").Replace("%2F", "/").Replace("%32", " ")
              .Replace("%38", "&").Replace("%63", "?").Replace("%34", "\"").Replace("%61", "=").Replace("%43", "+").Replace("%26", "&").Replace("%7b", "{")
              .Replace("%7B", "{").Replace("%7d", "}").Replace("%7D", "}").Replace("%28", "(").Replace("%29", ")"));
          }
        }

        try
        {
          return queryStringVariablesHash[findString].ToString();
        }
        catch (Exception)
        {
          return string.Empty;
        }
      }

      return string.Empty;
    }

    /// <summary>
    /// Takes a string with exotic characters and maybe spaces and encodes it to be safely passed as a url querystring parameter.
    /// This is needed as HTMLEncode and URLEncode change spaces into '+'
    /// </summary>
    /// <param name="StringName"></param>
    /// <returns>String in URL Safe format</returns>
    public static string EncodeStringAsUrl(string StringName)
    {
      // WARNING Percentage '%' Symbol *MUST* be the 1st symbol replaced, if not it will strip the control % away from other character replacements...
      return StringName.Replace(@"%", @"%25")
                        .Replace(@" ", @"%20")
                        .Replace(@"!", @"%21")
                        .Replace("\"", @"%22")
                        .Replace(@"#", @"%23")
                        .Replace(@"$", @"%24")
                        .Replace(@"&", @"%26")
                        .Replace(@"'", @"%27")
                        .Replace(@"(", @"%28")
                        .Replace(@")", @"%29")
                        .Replace(@"*", @"%2A")
                        .Replace(@"+", @"%2B")
                        .Replace(@",", @"%2C")
                        .Replace(@"-", @"%2D")
                        .Replace(@".", @"%2E")
                        .Replace(@"/", @"%2F")
                        .Replace(@":", @"%3A")
                        .Replace(@";", @"%3B")
                        .Replace(@"<", @"%3C")
                        .Replace(@"=", @"%3D")
                        .Replace(@">", @"%3E")
                        .Replace(@"?", @"%3F")
                        .Replace(@"@", @"%40")
                        .Replace(@"[", @"%5B")
                        .Replace("\\", @"%5C")
                        .Replace(@"]", @"%5D")
                        .Replace(@"^", @"%5E")
                        .Replace(@"_", @"%5F")
                        .Replace(@"`", @"%60")
                        .Replace(@"{", @"%7B")
                        .Replace(@"|", @"%7C")
                        .Replace(@"}", @"%7D")
                        .Replace(@"~", @"%7E")
                        .Replace(@"€", @"%80")
                        .Replace(@"‚", @"%82")
                        .Replace(@"ƒ", @"%83")
                        .Replace(@"„", @"%84")
                        .Replace(@"…", @"%85")
                        .Replace(@"†", @"%86")
                        .Replace(@"‡", @"%87")
                        .Replace(@"ˆ", @"%88")
                        .Replace(@"‰", @"%89")
                        .Replace(@"Š", @"%8A")
                        .Replace(@"‹", @"%8B")
                        .Replace(@"Œ", @"%8C")
                        .Replace(@"Ž", @"%8E")
                        .Replace(@"‘", @"%91")
                        .Replace(@"’", @"%92")
                        .Replace(@"“", @"%93")
                        .Replace(@"”", @"%94")
                        .Replace(@"•", @"%95")
                        .Replace(@"–", @"%96")
                        .Replace(@"—", @"%97")
                        .Replace(@"˜", @"%98")
                        .Replace(@"™", @"%99")
                        .Replace(@"š", @"%9A")
                        .Replace(@"›", @"%9B")
                        .Replace(@"œ", @"%9C")
                        .Replace(@"ž", @"%9E")
                        .Replace(@"Ÿ", @"%9F")
                        .Replace(@"¡", @"%A1")
                        .Replace(@"¢", @"%A2")
                        .Replace(@"£", @"%A3")
                        .Replace(@"¥", @"%A5")
                        .Replace(@"|", @"%A6")
                        .Replace(@"§", @"%A7")
                        .Replace(@"¨", @"%A8")
                        .Replace(@"©", @"%A9")
                        .Replace(@"ª", @"%AA")
                        .Replace(@"«", @"%AB")
                        .Replace(@"¬", @"%AC")
                        .Replace(@"¯", @"%AD")
                        .Replace(@"®", @"%AE")
                        .Replace(@"¯", @"%AF")
                        .Replace(@"°", @"%B0")
                        .Replace(@"±", @"%B1")
                        .Replace(@"²", @"%B2")
                        .Replace(@"³", @"%B3")
                        .Replace(@"´", @"%B4")
                        .Replace(@"µ", @"%B5")
                        .Replace(@"¶", @"%B6")
                        .Replace(@"·", @"%B7")
                        .Replace(@"¸", @"%B8")
                        .Replace(@"¹", @"%B9")
                        .Replace(@"º", @"%BA")
                        .Replace(@"»", @"%BB")
                        .Replace(@"¼", @"%BC")
                        .Replace(@"½", @"%BD")
                        .Replace(@"¾", @"%BE")
                        .Replace(@"¿", @"%BF")
                        .Replace(@"À", @"%C0")
                        .Replace(@"Á", @"%C1")
                        .Replace(@"Â", @"%C2")
                        .Replace(@"Ã", @"%C3")
                        .Replace(@"Ä", @"%C4")
                        .Replace(@"Å", @"%C5")
                        .Replace(@"Æ", @"%C6")
                        .Replace(@"Ç", @"%C7")
                        .Replace(@"È", @"%C8")
                        .Replace(@"É", @"%C9")
                        .Replace(@"Ê", @"%CA")
                        .Replace(@"Ë", @"%CB")
                        .Replace(@"Ì", @"%CC")
                        .Replace(@"Í", @"%CD")
                        .Replace(@"Î", @"%CE")
                        .Replace(@"Ï", @"%CF")
                        .Replace(@"Ð", @"%D0")
                        .Replace(@"Ñ", @"%D1")
                        .Replace(@"Ò", @"%D2")
                        .Replace(@"Ó", @"%D3")
                        .Replace(@"Ô", @"%D4")
                        .Replace(@"Õ", @"%D5")
                        .Replace(@"Ö", @"%D6")
                        .Replace(@"Ø", @"%D8")
                        .Replace(@"Ù", @"%D9")
                        .Replace(@"Ú", @"%DA")
                        .Replace(@"Û", @"%DB")
                        .Replace(@"Ü", @"%DC")
                        .Replace(@"Ý", @"%DD")
                        .Replace(@"Þ", @"%DE")
                        .Replace(@"ß", @"%DF")
                        .Replace(@"à", @"%E0")
                        .Replace(@"á", @"%E1")
                        .Replace(@"â", @"%E2")
                        .Replace(@"ã", @"%E3")
                        .Replace(@"ä", @"%E4")
                        .Replace(@"å", @"%E5")
                        .Replace(@"æ", @"%E6")
                        .Replace(@"ç", @"%E7")
                        .Replace(@"è", @"%E8")
                        .Replace(@"é", @"%E9")
                        .Replace(@"ê", @"%EA")
                        .Replace(@"ë", @"%EB")
                        .Replace(@"ì", @"%EC")
                        .Replace(@"í", @"%ED")
                        .Replace(@"î", @"%EE")
                        .Replace(@"ï", @"%EF")
                        .Replace(@"ð", @"%F0")
                        .Replace(@"ñ", @"%F1")
                        .Replace(@"ò", @"%F2")
                        .Replace(@"ó", @"%F3")
                        .Replace(@"ô", @"%F4")
                        .Replace(@"õ", @"%F5")
                        .Replace(@"ö", @"%F6")
                        .Replace(@"÷", @"%F7")
                        .Replace(@"ø", @"%F8")
                        .Replace(@"ù", @"%F9")
                        .Replace(@"ú", @"%FA")
                        .Replace(@"û", @"%FB")
                        .Replace(@"ü", @"%FC")
                        .Replace(@"ý", @"%FD")
                        .Replace(@"þ", @"%FE")
                        .Replace(@"ÿ", @"%FF");
    }

    /// <summary>
    /// Specific logic for removing all the shite in Onyx customer names - " ? / \ $ £ & % etc
    /// </summary>
    /// <param name="queryString"></param>
    /// <returns></returns>
    public static string RemoveInvalidCharactersFromCustomerName(string queryString)
      {
          string SecondBit;
          try
          {
              SecondBit = queryString.Substring(queryString.IndexOf("&productNumber"));
          }
          catch (Exception)
          {
              SecondBit = queryString.Substring(queryString.IndexOf("?productNumber"));
          }

          string CustomerName = SecondBit.Substring(SecondBit.IndexOf("customerName"));

          string OriginalCustomerName = CustomerName;

          CustomerName = CustomerName.Replace("&", "%26");
          CustomerName = CustomerName.Replace(" ", "%32");

// SecondBit = SecondBit.Replace("=", "%61");
          CustomerName = CustomerName.Replace("+", "%43");

// SecondBit = SecondBit.Replace("&", "@@@");
          CustomerName = CustomerName.Replace("?", "%63");
          CustomerName = CustomerName.Replace("\"", "%34");

          queryString = queryString.Replace(OriginalCustomerName, CustomerName);

          return queryString;
      }

      public static string BoolToString(bool value)
    {
      return value ? "1" : "0";
    }

    public static int StringToInt(string value)
    {
      return string.IsNullOrEmpty(value) ? 0 : int.Parse(value);
    }

    public static string IntToString(int value)
    {
      return value == 0 ? string.Empty : value.ToString();
    }

    public static decimal StringToDecimal(string value)
    {
      return string.IsNullOrEmpty(value) ? decimal.Zero : decimal.Parse(value);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value">String value to convert</param>
    /// <param name="decimalPlaces">Number of decimal places to display</param>
    /// <returns></returns>
    public static decimal StringToDecimal(string value, int decimalPlaces)
    {
      decimal tmp = StringToDecimal(value);
      return decimal.Round(tmp, decimalPlaces);
    }




    /// <summary>
        /// 
    /// </summary>
        /// <param name="value">Phone number string to convert</param>
        /// <returns></returns>
    /// <returns>True if string(value) matches the regularExpression pattern. Null or Empty strings will also return true</returns>
    public static bool StringMatchesRegularExpressionPattern(string value, string regularExpression)
    {
      bool containsRegEx = false;
      if (!string.IsNullOrEmpty(value))
      {
        Regex r = new Regex(regularExpression);
        Match m = r.Match(value);
        if (m.Success)
          {
// Strip off any leading zero
              containsRegEx = true;
          }
      }
      else
      {
        containsRegEx = true;
      }

      return containsRegEx;
    }

      
  }
}
