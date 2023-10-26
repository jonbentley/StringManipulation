using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using StringManipulation.Attributes;

namespace StringManipulation.Attributes
{
    /// <summary>
    /// A custom attribute used to provide enum values with descriptive text
    /// </summary>
    public class TextStringAttribute : Attribute
    {
        /// <summary>
        /// An array of strings containing descriptive text
        /// </summary>
        public string[] Description;

        /// <summary>
        /// Default constructor for the TextString attribute
        /// </summary>
        /// <param name="description"></param>
        public TextStringAttribute(params string[] description)
        {
            this.Description = description;
        }
    }
}

namespace StringManipulation.Extensions
{
  /// <summary>
  /// This class contains C# 3.0 extension methods for the System.Enum type. In order to
  /// use the methods in this class make sure you have added a 'Using Osprey.Model;' directive
  /// at the top of your code.
  /// </summary>
  public static class EnumExtension
  {
    /// <summary>
    /// An extension method that will convert the name of an enum value to the first text
    /// value contained in any TextString attribute decorating the enum value. If no
    /// TextString attribute is present then the name of the enum value is split into
    /// words. The example below provides an illustration.
    /// 
    ///     public enum MyEnum
    ///     {
    ///         [TextString("Big Fat Lazy Dog"]
    ///         BigDog = 1,
    ///         [TextString("Big Cat"]
    ///         BigCat = 2
    ///         [TextString("Bigfrog"]
    ///         Bigfrog = 3
    ///     }
    ///     
    ///     MyEnum.BigDog.ToText() will return 'Big Fat Lazy Dog'
    ///     MyEnum.BigCat.ToText() will return 'Big Cat'
    ///     MyEnum.Bigfrog.ToText() will return 'Bigfrog'
    /// 
    /// </summary>
    /// <returns>The enum value converted to a string suitable for display</returns>
    public static string ToText(this Enum value)
    {
      return ToText(value, 0);
    }

    /// <summary>
    /// An extension method that will convert the name of an enum value to the specified text
    /// value contained in any TextString attribute decorating the enum value. If no
    /// TextString attribute is present then the name of the enum value is split into
    /// words. If the specified value does not exist an empty string is returned.
    /// The example below provides an illustration.
    /// 
    ///     public enum MyEnum
    ///     {
    ///         [TextString("Big Fat Lazy Dog", "130", "Shoot It"]
    ///         BigDog = 1,
    ///         BigCat = 2
    ///         Bigfrog = 3
    ///     }
    ///     
    ///     MyEnum.BigDog.ToText(0) will return 'Big Fat Lazy Dog'
    ///     MyEnum.BigDog.ToText(1) will return '130'
    ///     MyEnum.BigCat.ToText(2) will return 'Shoot It'
    ///     MyEnum.Bigfrog.ToText(3) will return an empty string
    /// 
    /// </summary>
    /// <returns>The enum value converted to a string suitable for display</returns>
    public static string ToText(this Enum value, int index)
    {
      // Use reflection to get a FieldInfo object for the enum value
      Type type = value.GetType();
      FieldInfo info = type.GetField(value.ToString());

      // If we obtained a FieldInfo object then search it for a TextString attribute
      // and if we find one then return the first string from its Description[] array
      if (info != null)
      {
        object[] arAttrib = info.GetCustomAttributes(typeof(TextStringAttribute), false);
        if (arAttrib != null && arAttrib.Length > 0)
        {
          TextStringAttribute textStringAttribute = (TextStringAttribute)arAttrib[0];
          int length = textStringAttribute.Description.Length;
          return (length > index) ? textStringAttribute.Description[index] : string.Empty;
        }
      }

      // If all else fails then return the name of the enum value converted to words
      return value.Wordify();
    }

    /// <summary>
    /// An extension method that will convert a string value to its equivalent enum value using
    /// any TextString attributes decorating the enum's values. If no TextString attributes are
    /// present the string will be matched to either the name of an enum value or it's wordified
    /// eqivalent. If no match can be found an ArgumentException() is thrown. The example below 
    /// provides an illustration.
    /// 
    ///     public enum MyEnum
    ///     {
    ///         [TextString("Big Fat Lazy Dog", "Just Another Dog"]
    ///         BigDog = 1,
    ///         BigCat = 2
    ///         Bigfrog = 3
    ///     }
    ///     
    ///     MyEnum.BigDog.FromText("Big Fat Lazy Dog") will return MyEnum.BigDog
    ///     MyEnum.BigCat.FromText("Just Another Dog") will return MyEnum.BigDog
    ///     MyEnum.Bigfrog.FromText("Big Dog") will return MyEnum.BigDog
    ///     MyEnum.Bigfrog.FromText("Big Cat") will return MyEnum.BigCat
    ///     MyEnum.Bigfrog.FromText("Bigfrog") will return MyEnum.Bigfrog
    ///     MyEnum.Bigfrog.FromText("Big Frog") will throw an exception
    /// 
    /// </summary>
    /// <returns>An enum value</returns>
    public static Enum FromText(this Enum value, string text)
    {
      // Throw an exception if passed a null string
      if (text == null)
      {
        throw new ArgumentNullException();
      }

      // Use reflection to get an array of FieldInfo objects for the enum
      Type type = value.GetType();
      FieldInfo[] arInfo = type.GetFields();

      // If we get a valid array then loop through the FieldInfo objects
      if (arInfo != null && arInfo.Length > 0)
      {
        foreach (FieldInfo info in arInfo)
        {
          // We are ony interested in static literal fields
          if (!(info.IsLiteral && info.IsStatic))
          {
            continue;
          }

          // Get the actual enum value for this FieldInfo object
          Enum enumValue = (Enum)info.FieldType.InvokeMember(info.Name, BindingFlags.GetField, null, value, null);

          // Check for an ordinary plain match first
          if (string.Compare(enumValue.ToString(), text, true) == 0)
          {
            return enumValue;
          }

          // Next check for a wordified match
          if (string.Compare(enumValue.Wordify(), text, true) == 0)
          {
            return enumValue;
          }

          // And finally check for any match with a TextString custom attribute
          object[] arAttrib = info.GetCustomAttributes(typeof(TextStringAttribute), false);
          if (arAttrib != null && arAttrib.Length > 0)
          {
            TextStringAttribute textStringAttribute = (TextStringAttribute)arAttrib[0];

            // If the enum value has a TextString attribute then search for a match
            // on every string value in its Description array
            foreach (string description in textStringAttribute.Description)
            {
              if (string.Compare(description, text, true) == 0)
              {
                return enumValue;
              }
            }
          }
        }
      }

      // We haven't been able to find a match so throw an exception
      throw new ArgumentException("Enumeration FromText value unknown: '" + text + "'");
    }
    

    /// <summary>
    /// An extension method that will convert a string value to its equivalent enum value using
    /// any TextString attributes decorating the enum's values. If no TextString attributes are
    /// present the string will be matched to either the name of an enum value or it's wordified
    /// eqivalent. If no match can be found then the defaultValue parameter is returned. The example below 
    /// provides an illustration.
    /// 
    ///     public enum MyEnum
    ///     {
    ///         [TextString("Big Fat Lazy Dog", "Just Another Dog"]
    ///         Unknown = 0,
    ///         BigDog = 1,
    ///         BigCat = 2
    ///         Bigfrog = 3
    ///     }
    ///     
    ///     MyEnum.BigDog.FromText("Big Fat Lazy Dog", MyEnum.Unknown) will return MyEnum.BigDog
    ///     MyEnum.BigCat.FromText("Just Another Dog", MyEnum.Unknown) will return MyEnum.BigDog
    ///     MyEnum.Bigfrog.FromText("Big Dog", MyEnum.Unknown) will return MyEnum.BigDog
    ///     MyEnum.Bigfrog.FromText("Big Cat", MyEnum.Unknown) will return MyEnum.BigCat
    ///     MyEnum.Bigfrog.FromText("Bigfrog", MyEnum.Unknown) will return MyEnum.Bigfrog
    ///     MyEnum.Bigfrog.FromText("Big Frog", MyEnum.Unknown) will return MyEnum.Unknown
    /// 
    /// </summary>
    /// <returns>An enum value</returns>
    public static Enum FromText(this Enum value, string text, Enum defaultValue)
    {
      // Attempt to convert the text string to an enum value
      Enum en;

      // Throw an exception if passed a null string
      if (string.IsNullOrEmpty(text))
      {
        return defaultValue;
      }
      
      try
      {
        en = FromText(value, text);
      }
      catch (ArgumentException)
      {
        // If we can't convert then use the default enum value
        en = defaultValue;
      }

      // Return the final value
      return en;
    }

    /// <summary>
    /// An extension method that will convert a delimited string value to a list of all the enumerables in it
    /// It uses the FromText method to match the string to its equivalent Enumeration.
    /// 
    /// The example below provides an illustration.
    /// 
    ///     public enum MyEnum
    ///     {
    ///         [TextString("Big Fat Lazy Dog", "Just Another Dog"]
    ///         BigDog = 1,
    ///         BigCat = 2
    ///         Bigfrog = 3
    ///     }
    ///     
    ///     MyEnum.BigDog.FromText("Big Fat Lazy Dog|Big Cat|Bigfrog") 
    ///     will return an IEnumerable of (MyEnum.BigDog, MyEnum.BigCat, MyEnum.Bigfrog)
    /// 
    ///     MyEnum.Bigfrog.FromText("Big Frog") will throw an exception
    /// </summary>
    /// <returns>An flagged enum value</returns>
    public static IEnumerable<Enum> FromFlaggedText(this Enum value, string text)
    {
      string[] enumerationStrings = text.Split('|');
      foreach (string enumerationString in enumerationStrings)
      {
         yield return FromText(value, enumerationString);
      }
    }

    /// <summary>
    /// Helper extension method that will break the name of an enum value into words
    /// e.g. MyEnum.BigDog becomes the string 'Big Dog'
    /// </summary>
    /// <returns>The name of the enum value converted to words</returns>
    private static string Wordify(this Enum value)
    {
      // A magic regular expression to extract the words from the enum value
      Regex r = new Regex("(?<=[a-z])(?<x>[A-Z])|(?<=.)(?<x>[A-Z])(?=[a-z])");

      return r.Replace(value.ToString(), " ${x}");
    }
  }
}