﻿// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Utilities.StringUtilities
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Rift.Frontend.Utilities
{
  public static class StringUtilities
  {
    public static string GetDescription(this Enum value)
    {
      Type type = value.GetType();
      string name = Enum.GetName(type, (object) value);
      if (name == null)
        return (string) null;
      FieldInfo field = type.GetField(name);
      if (field == (FieldInfo) null)
        return (string) null;
      return Attribute.GetCustomAttribute((MemberInfo) field, typeof (DescriptionAttribute)) is DescriptionAttribute customAttribute ? customAttribute.Description : (string) null;
    }

    public static string FilterLaunchArguments(this string[] userArgs, List<string> baseArgs)
    {
      List<string> list = baseArgs.Select<string, string>((Func<string, string>) (x => !x.Contains("=") ? x : x.Split("=")[0])).ToList<string>();
      foreach (string userArg in userArgs)
      {
        if (userArg.Contains("="))
        {
          string str = userArg.Split("=")[0];
          if (!list.Contains(str))
            baseArgs.Add(userArg);
        }
        else if (!baseArgs.Contains(userArg))
          baseArgs.Add(userArg);
      }
      return string.Join(" ", (IEnumerable<string>) baseArgs);
    }
  }
}
