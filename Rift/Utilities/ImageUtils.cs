// Decompiled with JetBrains decompiler
// Type: Rift.Frontend.Utilities.ImageUtils
// Assembly: Rift, Version=2.1.0.3, Culture=neutral, PublicKeyToken=null
// MVID: AAC5CA4C-9311-43E3-8158-D708D13A5729
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Rift.dll

using System;
using System.Drawing;
using System.IO;

namespace Rift.Frontend.Utilities
{
  public static class ImageUtils
  {
    public static string ImageToBase64(this Image image)
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        image.Save((Stream) memoryStream, image.RawFormat);
        return Convert.ToBase64String(memoryStream.ToArray());
      }
    }
  }
}
