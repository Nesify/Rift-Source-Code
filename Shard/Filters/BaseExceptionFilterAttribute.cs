// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Filters.BaseExceptionFilterAttribute
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

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
