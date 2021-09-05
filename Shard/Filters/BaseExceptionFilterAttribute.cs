// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Filters.BaseExceptionFilterAttribute
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Rift.Backend.Models.Exceptions;
using Rift.Backend.Models.Exceptions.Common;
using System;

namespace Rift.Backend.Filters
{
  public class BaseExceptionFilterAttribute : ExceptionFilterAttribute
  {
    public override void OnException(ExceptionContext context)
    {
      if (!(context.Exception is BaseException))
        context.Exception = (Exception) new UnhandledErrorException(context.Exception.Message ?? "");
      BaseException exception = (BaseException) context.Exception;
      context.HttpContext.Response.Headers.Add("X-Epic-Error-Name", (StringValues) exception.Code);
      context.HttpContext.Response.Headers.Add("X-Epic-Error-Code", (StringValues) exception.NumericCode.ToString());
      context.Result = (IActionResult) new JsonResult((object) exception)
      {
        StatusCode = new int?(exception.Status)
      };
    }
  }
}
