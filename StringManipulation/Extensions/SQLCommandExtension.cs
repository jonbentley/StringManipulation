using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;

namespace StringManipulation.Extensions
{
  public static class SQLCommandExtension
  {
    /// <summary>
    /// Format a ToString for a SQLCommand - useful for displaying in logs and error messages
    /// </summary>
    /// <param name="s"></param>
    public static string SQLCommandToString(this SqlCommand s)
    {
      // call with default delimiter
      return s.SQLCommandToString(", ");
    }

    /// <summary>
    /// Format a ToString for a SQLCommand - useful for displaying in logs and error messages
    /// </summary>
    /// <param name="s"></param>
    /// <param name="parameterListDelimiter"></param>
    /// <returns></returns>
    public static string SQLCommandToString(this SqlCommand s, string parameterListDelimiter)
    {
      try
      {
        string result = string.Empty;
        
        if (s.CommandType == CommandType.StoredProcedure)
        {
          result += "Stored Procedure, name = " + s.CommandText + parameterListDelimiter;
        }
        else
        {
          result += "Command Text: " + s.CommandText + parameterListDelimiter;
          result += "Command Type: " + s.CommandType + parameterListDelimiter;
        }

        result += s.ParameterListToString(parameterListDelimiter);
        return result;
      }
      catch
      {
        return string.Empty;
      }
    }


    /// <summary>
    /// create a list of parameters and values separated by a chosen delimiter
    /// </summary>
    /// <param name="s"></param>
    /// <param name="delimiter"></param>
    /// <returns></returns>
    public static string ParameterListToString(this SqlCommand s, string delimiter)
    {
      try
      {
        // return blank if nothing passed in
        if ((s == null) || (s.Parameters.Count == 0))
        {
          return string.Empty;
        }

        string result = string.Empty;

        // Loop round the parameters
        for (int i = 0; i <= s.Parameters.Count - 1; i++)
        {
          result += s.Parameters[i].ParameterName + "=" + s.Parameters[i].Value;
          if (i < s.Parameters.Count - 1)
          {
            result += delimiter;
          }
        }

        return result;
      }
      catch
      {
        return string.Empty;
      }

    }

  }
}
