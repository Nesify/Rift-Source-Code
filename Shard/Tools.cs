// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Tools
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Rift.Backend.Models.Exceptions.Common;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Rift.Backend
{
  public static class Tools
  {
    public static string CreateRandomHexString()
    {
      Random random = new Random();
      string empty = string.Empty;
      for (int index = 0; index < 4; ++index)
      {
        int num = random.Next(0, int.MaxValue);
        empty += num.ToString("X8");
      }
      return empty.ToLower();
    }

    public static int GetSeasonNumber(this HttpRequest request) => Decimal.ToInt32(request.GetBuildVersion());

    public static Decimal GetBuildVersion(this HttpRequest request)
    {
      string header = (string) request.Headers["User-Agent"];
      if (!string.IsNullOrEmpty(header))
      {
        if (header.Contains("Fortnite"))
        {
          try
          {
            string s = header.Split("-")[1];
            return s == "Next" || s == "Cert" || s.Contains("+++Fortnite+Release") ? 2.0M : Decimal.Parse(s);
          }
          catch
          {
            return 1.0M;
          }
        }
      }
      return 1.0M;
    }

    public static int GetCLNumber(this HttpRequest request)
    {
      string header = (string) request.Headers["User-Agent"];
      if (!string.IsNullOrEmpty(header))
      {
        if (header.Contains("Fortnite"))
        {
          try
          {
            string str = header.Remove(0, header.IndexOf("CL-")).Replace("CL-", "");
            int result;
            return int.TryParse(str, out result) ? result : int.Parse(new string(str.TakeWhile<char>(new Func<char, bool>(char.IsDigit)).ToArray<char>()));
          }
          catch
          {
            return 0;
          }
        }
      }
      return 0;
    }

    public static IApplicationBuilder UseEpicStatusErrors(
      this IApplicationBuilder app)
    {
      app.UseStatusCodePages((Func<StatusCodeContext, Task>) (async context =>
      {
        string str = "";
        context.HttpContext.Response.Headers["Content-Type"] = (StringValues) "application/json; charset=utf-8";
        string text;
        switch ((HttpStatusCode) context.HttpContext.Response.StatusCode)
        {
          case HttpStatusCode.NotFound:
            text = JsonConvert.SerializeObject((object) new NotFoundException());
            break;
          case HttpStatusCode.MethodNotAllowed:
            text = JsonConvert.SerializeObject((object) new MethodNotAllowedException());
            break;
          default:
            text = str;
            break;
        }
        await context.HttpContext.Response.WriteAsync(text);
      }));
      return app;
    }

    public static DateTime TrimDate(this DateTime date) => new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond, date.Kind);
  }
}
