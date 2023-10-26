using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;
using Microsoft.XmlDiffPatch;

namespace StringManipulation.Extensions
{
  public class DeepPublicCompareException : Exception
  {
    public DeepPublicCompareException(string exceptionText)
      : base(exceptionText)
    {
    }
  }

  public class DeepPublicCompareDifferenceException : DeepPublicCompareException
  {
    public DeepPublicCompareDifferenceException(string exceptionText)
      : base(exceptionText)
    {
    }
  }

  /// <summary>
  /// Deep compare utility for more complex objects
  /// </summary>
  public static class ComparisionExtension
  {


    /// <summary>
    /// Does a deep compare of the public properties.
    /// properties names matching the strings on the ignore list are not compared.
    /// Assumption - an Exception will be thrown on a difference and no difference diagnostics returned
    /// </summary>
    /// <param name="self"></param>
    /// <param name="expected"></param>
    /// <param name="ignore"></param>
    public static bool DeepPublicCompare<T>(this T self, T expected, params string[] ignore) where T : class
    {
      // Create a dummy SB so that we can see the results while debugging 
      var dummySb = new StringBuilder();
      return DeepPublicCompare(self, expected, dummySb, true, ignore);
    }

    /// <summary>
    /// Does a deep compare of the public properties.
    /// properties names matching the strings on the ignore list are not compared.
    /// <param name="self"></param>
    /// <param name="expected"></param>
    /// <param name="compareDiagnostics">byref - returns details of the difference if one is found</param>
    /// <param name="throwExceptionOnDifference">If a difference is found either return a bool or throw an exception</param>
    /// <param name="ignore"></param>
    /// </summary>
    public static bool DeepPublicCompare<T>(this T self, T expected, StringBuilder compareDiagnostics, bool throwExceptionOnDifference, params string[] ignore) where T : class
      {
          // TODO need to handle arrays
          string currentType = string.Empty;
          string currentPropertyName = string.Empty;
          string currentSelfValue = string.Empty;
          string currentExpectedValue = string.Empty;

// StringBuilder sbCompareDiagnostics = new StringBuilder();
          try
          {
              if (compareDiagnostics == null)
              {
                  compareDiagnostics =
                      new StringBuilder("____________________ Deep Public Compare diagnostics _____________________");
                  compareDiagnostics.AppendLine();
              }

              if (ignore == null) ignore = new string[0];

              if (self != null && expected != null)
              {
                  Type type = self.GetType();
                  currentType = type.Name;
                  var ignoreList = new List<string>(ignore);

                  // Before we loop round the Object's properties test to see if the Objects are of type "List<>" or "String" - handle these as specific cases.
                  // Are the objects passed in strings
                  if (type.IsValueType || type.Name == "String")
                  {
                      // Type is a string - nice and easy
                      currentSelfValue = GetStringValue(self);
                      currentExpectedValue = GetStringValue(expected);
                      return CompareStrings(currentSelfValue, currentExpectedValue, compareDiagnostics,
                          throwExceptionOnDifference);
                  }

                  if (type.Name == "XmlDocument" || type.Name == "XmlNode")
                  {
                      // Type is a XmlNode
                      XmlNode selfXML = self as XmlNode;
                      XmlNode expectedXML = expected as XmlNode;
                      return CompareXMLNodes(selfXML, expectedXML, compareDiagnostics, throwExceptionOnDifference);
                  }


                  // Are the objects passed in Lists 
                  if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(List<>)))
                  {
                      // The property is a List<> - these are a bit messy so handle separately
                      IEnumerable selfCollection = (IEnumerable) self;
                      IEnumerable expectedCollection = (IEnumerable) expected;
                      return CompareLists(selfCollection, expectedCollection, type.Name, compareDiagnostics,
                          throwExceptionOnDifference, ignoreList.ToArray());
                  }

                  // A property is considered public to reflection if it has at least one accessor that is public
                  // Loop round the properties of the object
                  foreach (PropertyInfo pi in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                  {
                      compareDiagnostics.AppendFormat("Type='" + type.Name + "' Property='" + pi.Name + "' ");
                      currentPropertyName = pi.Name;
                      currentSelfValue = string.Empty;
                      currentExpectedValue = string.Empty;

// is it to be ignored
                      if (!ignoreList.Contains(pi.Name))
                      {
                          // Get the values of the properties to be compared. Could be strings or complex objects or null or Lists
                          object selfValue = (self.GetType().Name == "String")
                              ? self
                              : type.GetProperty(pi.Name).GetValue(self, null);
                          object toValue = (expected.GetType().Name == "String")
                              ? expected
                              : type.GetProperty(pi.Name).GetValue(expected, null);

                          // Are we comparing null values
                          if (selfValue == null || toValue == null)
                          {
                              currentSelfValue = (selfValue == null) ? "null" : "not null";
                              currentExpectedValue = (toValue == null) ? "null" : "not null";
                              compareDiagnostics.AppendFormat(
                                  "Expected='" + currentExpectedValue + "' Actual='" + currentSelfValue + "' ");
                              compareDiagnostics.AppendLine();

                              if (selfValue != toValue)
                              {
                                  // Add details of the non-null value
                                  if (toValue != null)
                                  {
                                      compareDiagnostics.AppendFormat(
                                          "Expected Value ='" + GetStringValue(toValue) + "'");
                                  }

                                  if (selfValue != null)
                                  {
                                      compareDiagnostics.AppendFormat(
                                          "Actual Value ='" + GetStringValue(selfValue) + "'");
                                  }

                                  compareDiagnostics.AppendLine();
                                  if (throwExceptionOnDifference)
                                  {
                                      // using \n does not throw a new line in the VS Test Results window so use an sb
                                      var sbExceptionText = new StringBuilder();
                                      sbExceptionText.AppendLine("DeepPublicCompare Difference");
                                      sbExceptionText.AppendLine(compareDiagnostics.ToString());
                                      sbExceptionText.AppendLine();
                                      throw new DeepPublicCompareDifferenceException(sbExceptionText.ToString());
                                  }

                                  return false;
                              }
 // values differ
                          }
 // at least 1 value is null

                          // Neither object is Null
                          // Is it a List
                          else if (pi.PropertyType.IsGenericType &&
                                   (pi.PropertyType.GetGenericTypeDefinition() == typeof(List<>)))
                          {
                              // The property is a List<> - these are a bit messy so handle separately
                              IEnumerable selfCollection = (IEnumerable) pi.GetValue(self, null);
                              IEnumerable expectedCollection = (IEnumerable) pi.GetValue(expected, null);
                              if (!CompareLists(selfCollection, expectedCollection, pi.Name, compareDiagnostics,
                                  throwExceptionOnDifference, ignoreList.ToArray()))
                              {
                                  return false;
                              }
                          }

// Value is a string
                          else if (pi.PropertyType.IsValueType || pi.PropertyType.Name == "String")
                          {
                              // Type is a string - nice and easy
                              currentSelfValue = GetStringValue(selfValue);
                              currentExpectedValue = GetStringValue(toValue);
                              if (!CompareStrings(currentSelfValue, currentExpectedValue, compareDiagnostics,
                                  throwExceptionOnDifference))
                                  return false;
                          }

// Value is a Byte Array
                          else if (pi.PropertyType.Name == "Byte[]")
                          {
                              // Type is a Byte Array
                              currentSelfValue = BitConverter.ToString((byte[]) selfValue);
                              currentExpectedValue = BitConverter.ToString((byte[]) toValue);
                              if (!CompareStrings(currentSelfValue, currentExpectedValue, compareDiagnostics,
                                  throwExceptionOnDifference))
                                  return false;
                          }

// comparing more complex type objects
                          else if (!selfValue.DeepPublicCompare(toValue, compareDiagnostics, throwExceptionOnDifference,
                              ignoreList.ToArray()))
                          {
                              return false;
                          }
                      }
 // not ignored
                      else
                      {
                          compareDiagnostics.AppendFormat("ignored");
                          compareDiagnostics.AppendLine();
                      }
                  }
 // for each property

                  // We have got through each property with none them returning false - so return true
                  return true;
              }
 // neither Object is null

              // At least one is null
              if (self == expected)
              {
                  // both null
                  return true;
              }

              // Either self or expected is null and the other isn't
              // Return false or exception 
              if (throwExceptionOnDifference)
              {
                  // using \n does not throw a new line in the VS Test Results window so use an sb
                  var sbExceptionText = new StringBuilder();
                  sbExceptionText.AppendLine("DeepPublicCompare Difference");
                  sbExceptionText.AppendLine(compareDiagnostics.ToString());
                  sbExceptionText.AppendLine("Actual");
                  sbExceptionText.AppendLine(self == null ? "null" : self.ToString());
                  sbExceptionText.AppendLine("Expected");
                  sbExceptionText.AppendLine(expected == null ? "null" : expected.ToString());
                  sbExceptionText.AppendLine();

                  throw new DeepPublicCompareDifferenceException(sbExceptionText.ToString());
              }

              return false;
          }
          catch (DeepPublicCompareDifferenceException ex)
          {
              // If the exception is a comparision then just pass it on
              if (DateTime.Today.ToString() != "Dummy Value to allow avoiding an exception while debugging")
              {
                  throw ex;
              }

              return false;
          }
          catch (Exception ex)
          {
              // It's a real Exception - display diagnostics
              // throw new Exception("\nDeepPublicCompare Exception" + "\n" + ex + "\n" + "Type=" + currentType + " : Property='" + currentPropertyName + "' Expected='" + currentExpectedValue + "' Actual='" + currentSelfValue + "'");
              if (DateTime.Today.ToString() != "Dummy Value to allow avoiding an exception while debugging")
              {
                  throw new DeepPublicCompareException("\nDeepPublicCompare Exception" + "\n" + ex + "\n" +
                                                       compareDiagnostics.ToString() + "\n");
              }

              return false;
          }
      }

      /// <summary>
    /// Compare 2 strings and return true/false/Exception as appropriate
    /// </summary>
    /// <param name="selfValue"></param>
    /// <param name="expectedValue"></param>
    /// <param name="compareDiagnostics"></param>
    /// <param name="throwExceptionOnDifference"></param>
    /// <returns></returns>
    private static bool CompareStrings(string selfValue, string expectedValue, StringBuilder compareDiagnostics, bool throwExceptionOnDifference)
      {
          compareDiagnostics.Append("Expected='" + expectedValue + "'");
          compareDiagnostics.Append("Actual='" + selfValue + "'");
          compareDiagnostics.AppendLine();

// comparing value type and String objects
          if (selfValue != expectedValue)
          {
              if (throwExceptionOnDifference)
              {
                  // using \n does not throw a new line in the VS Test Results window so use an sb
                  var sbExceptionText = new StringBuilder();
                  sbExceptionText.AppendLine("DeepPublicCompare Difference");
                  sbExceptionText.AppendLine(compareDiagnostics.ToString());
                  sbExceptionText.AppendLine();
                  throw new DeepPublicCompareDifferenceException(sbExceptionText.ToString());
              }

              return false;
          }

          return true;
      }

      /// <summary>
    /// Unpack a List and call DeepPublicCompare to compare each individual element
    /// NB - hopefully the entries are in the same order!
    /// </summary>
    /// <param name="selfCollection"></param>
    /// <param name="expectedCollection"></param>
    /// <param name="listName"></param>
    /// <param name="compareDiagnostics"></param>
    /// <param name="throwExceptionOnDifference"></param>
    /// <param name="ignore"></param>
    /// <returns></returns>
    private static bool CompareLists(IEnumerable selfCollection, IEnumerable expectedCollection, string listName, StringBuilder compareDiagnostics, bool throwExceptionOnDifference, params string[] ignore)
    {
      var ignoreList = new List<string>(ignore);
      compareDiagnostics.AppendLine("Comparing Lists : " + listName);

      // Get the collection object
      // IEnumerable selfCollection = (IEnumerable)pi.GetValue(self, null);
      // IEnumerable selfCollection = (IEnumerable)self;
      // IEnumerable expectedCollection = (IEnumerable)expected;

      // We need to iterate through the collection by index not "foreach" so have to get into a format that can be indexed
      // If you can find a better way than creating a List and adding manually please change this.
      var selfList = new List<object>();
      var expectedList = new List<object>();

      foreach (var x in selfCollection)
      {
        selfList.Add(x);
      }

      foreach (var x in expectedCollection)
      {
        expectedList.Add(x);
      }

      // If there are different number of entries then error
      if (selfList.Count != expectedList.Count)
      {
        compareDiagnostics.AppendFormat("Different sizes of list '{2}' : self.count={0}  expected.count={1}", selfList.Count, expectedList.Count, listName);
        compareDiagnostics.AppendLine();
        if (throwExceptionOnDifference)
        {
          // using \n does not throw a new line in the VS Test Results window so use an sb
          var sbExceptionText = new StringBuilder();
          sbExceptionText.AppendLine("DeepPublicCompare List Difference");
          sbExceptionText.AppendLine(compareDiagnostics.ToString());
          sbExceptionText.AppendLine();
          throw new DeepPublicCompareDifferenceException(sbExceptionText.ToString());
        }

        return false;

        // useful stuff that might be useful when tinkering with this
        // String indexerName = ((DefaultMemberAttribute)selfCollection.GetType()
        // .GetCustomAttributes(typeof(DefaultMemberAttribute), true)[0]).MemberName;

        // PropertyInfo pi2 = selfCollection.GetType().GetProperty(indexerName);
        // Object value = pi2.GetValue(selfCollection, new Object[] { 0 });
        // Type[] typeParameters = pi.PropertyType.GetGenericArguments();
        // foreach (Type tParam in typeParameters)
        // {
        // }
        // var xx1 = type.GetProperty(pi.Name);
        // var xx2 = type.GetProperty(pi.Name).GetValue(self, null);
        // var xx3 = type.GetProperty(pi.Name).GetValue(expected, null);
      }

      // Loop round the Lists comparing each object in turn
      for (int i = 1; i <= selfList.Count; i++)
      {
        compareDiagnostics.AppendLine("List : " + listName + ".  Item " + i + " of " + selfList.Count);
        if (!selfList[i - 1].DeepPublicCompare(expectedList[i - 1], compareDiagnostics, throwExceptionOnDifference, ignoreList.ToArray()))
        {
          return false;
        }
      }

      return true;

    }


    /// <summary>
    /// Compare 2 xmlnodes and return true/false/Exception as appropriate
    /// </summary>
    /// <param name="selfValue"></param>
    /// <param name="expectedValue"></param>
    /// <param name="compareDiagnostics"></param>
    /// <param name="throwExceptionOnDifference"></param>
    /// <returns></returns>
    private static bool CompareXMLNodes(XmlNode selfValue, XmlNode expectedValue, StringBuilder compareDiagnostics, bool throwExceptionOnDifference)
    {
      // if there's a difference then show the outer xml
      // differences in the outer xml do not necessarily mean differences in XmlDiff.Compare
      // e.g.  <fred><fred>
      // and   <fred />
      // are different as strings but the same from an xml point of view
      compareDiagnostics.Append("Expected='" + expectedValue.OuterXml + "'");
      compareDiagnostics.Append("Actual='" + selfValue.OuterXml + "'");
      compareDiagnostics.AppendLine();

      // comparing value type and String objects
      XmlDiff XmlDiff = new XmlDiff();
      if (!XmlDiff.Compare(selfValue, expectedValue))
      {
        if (throwExceptionOnDifference)
        {
          // using \n does not throw a new line in the VS Test Results window so use an sb
          var sbExceptionText = new StringBuilder();
          sbExceptionText.AppendLine("DeepPublicCompare Difference in XMLNodes");
          sbExceptionText.AppendLine(compareDiagnostics.ToString());
          sbExceptionText.AppendLine();
          throw new DeepPublicCompareDifferenceException(sbExceptionText.ToString());
        }

        return false;
      }

      return true;
    }


    /// <summary>
    /// Extract the string value from the Expected/Actual object
    /// Usually this is just .ToString
    /// but if the object is a DateTime then we want to remove the time part as seconds can change during the test
    /// causing a false fail
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private static string GetStringValue(object value)
    {
      try
      {
          DateTime dummydate = DateTime.Parse(value.ToString());

// to get here the value is a date/time
          // return just the date part
          return dummydate.ToShortDateString().ToString();
      }
      catch
      {
        // the value is not a valid DateTime so return its string value
        return value.ToString();
      }
    }
  }
}
