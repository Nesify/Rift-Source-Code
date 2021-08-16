// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Controllers.CloudstorageController
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using Microsoft.AspNetCore.Mvc;
using Rift.Backend.Models.Cloudstorage;
using Rift.Backend.Models.Exceptions.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Rift.Backend.Controllers
{
  [Route("fortnite/api/[controller]")]
  [ApiController]
  public class CloudstorageController : ControllerBase
  {
    [HttpGet("system")]
    public ActionResult<List<CloudstorageFile>> GetCloudstorageSystemFiles()
    {
      switch (this.Request.GetSeasonNumber())
      {
        case 9:
        case 10:
        case 17:
          throw new NotFoundException();
        default:
          return (ActionResult<List<CloudstorageFile>>) ((IEnumerable<string>) Directory.GetFiles(Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Rift", "Cloudstorage", "System"))).Select<string, CloudstorageFile>((Func<string, CloudstorageFile>) (file => new CloudstorageFile(file)
          {
            UniqueFilename = CloudstorageController.GetCloudstorageFile(Path.GetFileNameWithoutExtension(file))
          })).ToList<CloudstorageFile>();
      }
    }

    [HttpGet("system/config")]
    public ActionResult<Config> GetCloudstorageSystemConfig() => (ActionResult<Config>) new Config();

    [HttpGet("system/{uniqueFilename}")]
    public ActionResult GetCloudstorageSystemFile(string uniqueFilename)
    {
      string str = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Rift", "Cloudstorage", "System", CloudstorageController.GetCloudstorageFile(uniqueFilename));
      return File.Exists(str + ".ini") ? (ActionResult) this.File((Stream) File.OpenRead(str + ".ini"), "application/octet-stream") : throw new NotFoundException();
    }

    [HttpGet("user/{accountId}")]
    public ActionResult<List<CloudstorageFile>> GetCloudstorageUserFiles(
      string accountId)
    {
      string path = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Rift", "Cloudstorage", "ClientSettings");
      Directory.CreateDirectory(path);
      int clNum = this.Request.GetCLNumber();
      List<CloudstorageFile> list = ((IEnumerable<string>) Directory.GetFiles(path)).Select<string, CloudstorageFile>((Func<string, CloudstorageFile>) (file =>
      {
        if (!file.Contains(string.Format("ClientSettings-{0}", (object) clNum)))
          return (CloudstorageFile) null;
        return new CloudstorageFile(file)
        {
          FileName = "ClientSettings.Sav",
          UniqueFilename = "ClientSettings.Sav"
        };
      })).ToList<CloudstorageFile>();
      list.RemoveAll((Predicate<CloudstorageFile>) (x => x == null));
      return (ActionResult<List<CloudstorageFile>>) list;
    }

    [HttpGet("user/{accountId}/{uniqueFilename}")]
    public ActionResult GetCloudstorageUserFile(string accountId, string uniqueFilename)
    {
      string path1 = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Rift", "Cloudstorage", "ClientSettings");
      int clNumber = this.Request.GetCLNumber();
      return File.Exists(Path.Join(path1, string.Format("ClientSettings-{0}.Sav", (object) clNumber))) ? (ActionResult) this.File((Stream) File.OpenRead(Path.Join(path1, string.Format("ClientSettings-{0}.Sav", (object) clNumber))), "application/octet-stream") : throw new Rift.Backend.Models.Exceptions.Cloudstorage.FileNotFoundException(uniqueFilename);
    }

    [HttpPut("user/{accountId}/{uniqueFilename}")]
    [RequestSizeLimit(5000000)]
    public async Task<ActionResult> UpdateCloudstorageUserFile(
      string accountId,
      string uniqueFilename)
    {
      CloudstorageController cloudstorageController = this;
      if (!uniqueFilename.Contains("ClientSettings"))
        throw new Rift.Backend.Models.Exceptions.Cloudstorage.FileNotFoundException(uniqueFilename);
      string cloudstoragePath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Rift", "Cloudstorage", "ClientSettings");
      int clNum = cloudstorageController.Request.GetCLNumber();
      if (!File.Exists(Path.Join(cloudstoragePath, string.Format("ClientSettings-{0}.Sav", (object) clNum))))
        await File.WriteAllTextAsync(Path.Join(cloudstoragePath, string.Format("ClientSettings-{0}.Sav", (object) clNum)), "");
      FileStream input = File.OpenWrite(Path.Join(cloudstoragePath, string.Format("ClientSettings-{0}.Sav", (object) clNum)));
      await cloudstorageController.Request.Body.CopyToAsync((Stream) input);
      input.Close();
      ActionResult actionResult = (ActionResult) cloudstorageController.NoContent();
      cloudstoragePath = (string) null;
      input = (FileStream) null;
      return actionResult;
    }

    private static string GetCloudstorageFile(string file)
    {
      Dictionary<string, string> source = new Dictionary<string, string>()
      {
        {
          "DefaultGame",
          "a22d837b6a2b46349421259c0a5411bf"
        },
        {
          "DefaultEngine",
          "3460cbe1c57d4a838ace32951a4d7171"
        },
        {
          "DefaultInput",
          "mhl5jvb7fm85e157u49k1lbf8p9kpj50"
        }
      };
      return !source.ContainsKey(file) ? source.FirstOrDefault<KeyValuePair<string, string>>((Func<KeyValuePair<string, string>, bool>) (x => x.Value == file)).Key : source[file];
    }
  }
}
