using System;

namespace StringManipulation.Extensions
{
  public static class DateTimeExtension
  {

    /// <summary>
    /// Converts DateTime? to DateTime. Null's will be converted to DateTime.MinValue
    /// </summary>
    public static DateTime OptionalDateTimeToSystemDateTime(this DateTime? dateTime)
      {
          if (dateTime.HasValue)
          {
              return (DateTime) dateTime;
          }

// Null DateTime has been passed in so return minimum date
          return DateTime.MinValue;
      }
  }
}
