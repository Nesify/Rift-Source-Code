// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Models.Exceptions.BaseException
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Newtonsoft.Json;
using System;

namespace Rift.Backend.Models.Exceptions
{
  [JsonObject(MemberSerialization.OptIn)]
  public class BaseException : Exception
  {
    public int Status = 400;

    public BaseException(int numericCode, string message, params string[] variables)
      : base(string.Format(message, (object[]) variables))
    {
      this.Variables = variables;
      this.NumericCode = numericCode;
    }

    [JsonProperty("errorCode")]
    public string Code => this.GetType().FullName.Replace(".Backend.Models", "").ToLower();

    [JsonProperty("errorMessage")]
    public override string Message => base.Message;

    [JsonProperty("messageVars")]
    public string[] Variables { get; private set; }

    [JsonProperty("numericErrorCode")]
    public int NumericCode { get; private set; }

    [JsonProperty("originatingService")]
    public string OriginatingService => "rift";

    [JsonProperty("intent")]
    public string Intent => "prod";
  }
}
