// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Utilities.Hammer
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

using IniParser.Model;
using IniParser.Parser;
using Rift.Frontend.Enums;
using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;


#nullable enable
namespace Rift.Frontend.Utilities
{
  public class Hammer
  {
    private static async 
    #nullable disable
    Task<string> GetCloudstorage()
    {
      try
      {
        using (WebClient webClient = new WebClient())
          return await webClient.DownloadStringTaskAsync("https://rift.jake.how/api/cloudstorage");
      }
      catch
      {
        return "";
      }
    }

    public static async Task Patch()
    {
      string cloudstorage = await Hammer.GetCloudstorage();
      if (string.IsNullOrEmpty(cloudstorage))
        return;
      IniData iniData = new IniDataParser().Parse(cloudstorage);
      foreach (SectionData section in iniData.Sections)
      {
        Type type = Type.GetType(section.SectionName);
        if (!(type == (Type) null))
        {
          foreach (FieldInfo field in type.GetFields())
          {
            if (section.Keys.ContainsKey(field.Name))
            {
              if (field.FieldType == typeof (bool))
                field.SetValue((object) null, (object) bool.Parse(iniData[section.SectionName][field.Name]));
              else if (field.FieldType == typeof (int))
                field.SetValue((object) null, (object) int.Parse(iniData[section.SectionName][field.Name]));
              else if (field.FieldType == typeof (string))
                field.SetValue((object) null, (object) iniData[section.SectionName][field.Name].Substring(1, iniData[section.SectionName][field.Name].Length - 2));
              else if (field.FieldType == typeof (float))
                field.SetValue((object) null, (object) float.Parse(iniData[section.SectionName][field.Name]));
              else if (field.FieldType == typeof (byte))
                field.SetValue((object) null, (object) byte.Parse(iniData[section.SectionName][field.Name]));
              Logger.Log("Successfully hammered " + field.Name + " to " + iniData[section.SectionName][field.Name], LogCategory.Patcher);
            }
          }
        }
      }
    }
  }
}
