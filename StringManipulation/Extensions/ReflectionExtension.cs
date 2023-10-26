using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace StringManipulation.Extensions
{
  public static class ReflectionExtension
  {
    public static List<T> GetAttributes<T>(this ICustomAttributeProvider pi)
      where T : Attribute
    {
      List<T> attrs = new List<T>();

      foreach (object a in pi.GetCustomAttributes(typeof(T), false))
        if (a is T) attrs.Add(a as T);

      return attrs;
    }
  }
}
