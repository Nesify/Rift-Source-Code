// Decompiled with JetBrains decompiler
// Type: Rift.Backend.Startup
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6F3E0BBF-2B21-48FA-A25C-D99F6888BB4F
// Assembly location: C:\Users\vloge\Downloads\RiftMultiplayerLauncher\Shard.dll

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Rift.Backend.Filters;
using Rift.Backend.Services;
using System;
using System.IO;

namespace Rift.Backend
{
  public class Startup
  {
    public Startup(IConfiguration configuration) => this.Configuration = configuration;

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().AddNewtonsoftJson((Action<MvcNewtonsoftJsonOptions>) (options =>
      {
        options.SerializerSettings.Converters.Add((JsonConverter) new IsoDateTimeConverter()
        {
          DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff'Z'"
        });
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
      }));
      services.AddMvc((Action<MvcOptions>) (options => options.Filters.Add((IFilterMetadata) new BaseExceptionFilterAttribute())));
      services.AddSingleton<IProfileService, ProfileService>();
      services.AddHttpContextAccessor();
      services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();
      if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();
      app.UseEpicStatusErrors();
      app.UseRouting();
      app.UseAuthorization();
      string str = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Rift", "Cloudstorage", "System");
      Directory.CreateDirectory(str);
      File.WriteAllText(Path.Join(str, "DefaultEngine.ini"), "[/Script/FortniteGame.FortPlayerController]\nTurboBuildInterval=0.005f\nTurboBuildFirstInterval=0.005f\nbClientSideEditPrediction=false");
      File.WriteAllText(Path.Join(str, "DefaultInput.ini"), "[/Script/Engine.InputSettings]\n+ConsoleKeys=Tilde\n+ConsoleKeys=F8");
      File.WriteAllText(Path.Join(str, "DefaultGame.ini"), "[/Script/FortniteGame.FortTextHotfixConfig]\n+TextReplacements=(Category=Game, bIsMinimalPatch=True, Namespace=\"Fortnite.FortMatchmakingV2\", Key=\"FailedToContactGameServices\", NativeString=\"Weird. We couldn't connect to the match. You can try again, but if the problem continues, check out {CheckStatusURL}.\", LocalizedStrings=((\"ar\",\"Press F3 to go in-game.\"),(\"en\",\"Press F3 to go in-game.\"),(\"de\",\"Press F3 to go in-game.\"),(\"es\",\"Press F3 to go in-game.\"),(\"es-419\",\"Press F3 to go in-game.\"),(\"fr\",\"Press F3 to go in-game.\"),(\"it\",\"Press F3 to go in-game.\"),(\"ja\",\"Press F3 to go in-game.\"),(\"ko\",\"Press F3 to go in-game.\"),(\"pl\",\"Press F3 to go in-game.\"),(\"pt-BR\",\"Press F3 to go in-game.\"),(\"ru\",\"Press F3 to go in-game.\"),(\"tr\",\"Press F3 to go in-game.\"),(\"zh-CN\",\"Press F3 to go in-game.\"),(\"zh-Hant\",\"Press F3 to go in-game.\")))\n+TextReplacements=(Category=Game, bIsMinimalPatch=True, Namespace=\"Fortnite.FortMatchmakingV2\", Key=\"FailedToContactGameServices\", NativeString=\"Failed to contact Game Services.\", LocalizedStrings=((\"ar\",\"Press F3 to go in-game.\"),(\"en\",\"Press F3 to go in-game.\"),(\"de\",\"Press F3 to go in-game.\"),(\"es\",\"Press F3 to go in-game.\"),(\"es-419\",\"Press F3 to go in-game.\"),(\"fr\",\"Press F3 to go in-game.\"),(\"it\",\"Press F3 to go in-game.\"),(\"ja\",\"Press F3 to go in-game.\"),(\"ko\",\"Press F3 to go in-game.\"),(\"pl\",\"Press F3 to go in-game.\"),(\"pt-BR\",\"Press F3 to go in-game.\"),(\"ru\",\"Press F3 to go in-game.\"),(\"tr\",\"Press F3 to go in-game.\"),(\"zh-CN\",\"Press F3 to go in-game.\"),(\"zh-Hant\",\"Press F3 to go in-game.\")))\n+TextReplacements=(Category=Game, bIsMinimalPatch=True, Namespace=\"\", Key=\"711EFB7C44CC114DCDF4DC9782AA4A72\", NativeString=\"UH OH!  SOMETHING GOOFED\", LocalizedStrings=((\"ar\",\"\"),(\"en\",\"\"),(\"de\",\"\"),(\"es\",\"\"),(\"es-419\",\"\"),(\"fr\",\"\"),(\"it\",\"\"),(\"ja\",\"\"),(\"ko\",\"\"),(\"pl\",\"\"),(\"pt-BR\",\"\"),(\"ru\",\"\"),(\"tr\",\"\"),(\"zh-CN\",\"\"),(\"zh-Hant\",\"\")))\n+TextReplacements=(Category=Game, bIsMinimalPatch=True, Namespace=\"\", Key=\"ADD78AB04A37750183B9FD948D07DD20\", NativeString=\"UH OH!  SOMETHING BROKE\", LocalizedStrings=((\"ar\",\"\"),(\"en\",\"\"),(\"de\",\"\"),(\"es\",\"\"),(\"es-419\",\"\"),(\"fr\",\"\"),(\"it\",\"\"),(\"ja\",\"\"),(\"ko\",\"\"),(\"pl\",\"\"),(\"pt-BR\",\"\"),(\"ru\",\"\"),(\"tr\",\"\"),(\"zh-CN\",\"\"),(\"zh-Hant\",\"\")))\n+TextReplacements=(Category=Game, bIsMinimalPatch=True, Namespace=\"\", Key=\"81BDCD5B41E0740BBA33328ACFC51136\", NativeString=\"THERE WAS AN ERROR\", LocalizedStrings=((\"ar\",\"\"),(\"en\",\"\"),(\"de\",\"\"),(\"es\",\"\"),(\"es-419\",\"\"),(\"fr\",\"\"),(\"it\",\"\"),(\"ja\",\"\"),(\"ko\",\"\"),(\"pl\",\"\"),(\"pt-BR\",\"\"),(\"ru\",\"\"),(\"tr\",\"\"),(\"zh-CN\",\"\"),(\"zh-Hant\",\"\")))\n+TextReplacements=(Category=Game, bIsMinimalPatch=True, Namespace=\"\", Key=\"B911AF014B3EA35585D927AC7F445603\", NativeString=\"THERE WAS A PROBLEM\", LocalizedStrings=((\"ar\",\"\"),(\"en\",\"\"),(\"de\",\"\"),(\"es\",\"\"),(\"es-419\",\"\"),(\"fr\",\"\"),(\"it\",\"\"),(\"ja\",\"\"),(\"ko\",\"\"),(\"pl\",\"\"),(\"pt-BR\",\"\"),(\"ru\",\"\"),(\"tr\",\"\"),(\"zh-CN\",\"\"),(\"zh-Hant\",\"\")))\n+TextReplacements=(Category=Game, bIsMinimalPatch=True, Namespace=\"\", Key=\"49078FDB479B899A7EA33392850E138D\", NativeString=\"THERE WAS A PROBLEM\", LocalizedStrings=((\"ar\",\"\"),(\"en\",\"\"),(\"de\",\"\"),(\"es\",\"\"),(\"es-419\",\"\"),(\"fr\",\"\"),(\"it\",\"\"),(\"ja\",\"\"),(\"ko\",\"\"),(\"pl\",\"\"),(\"pt-BR\",\"\"),(\"ru\",\"\"),(\"tr\",\"\"),(\"zh-CN\",\"\"),(\"zh-Hant\",\"\")))\n+TextReplacements=(Category=Game, bIsMinimalPatch=True, Namespace=\"\", Key=\"001FA3AE413EB94BF6FFED8370FE38D0\", NativeString=\"NOT THE LLAMA YOU'RE LOOKING FOR\", LocalizedStrings=((\"ar\",\"\"),(\"en\",\"\"),(\"de\",\"\"),(\"es\",\"\"),(\"es-419\",\"\"),(\"fr\",\"\"),(\"it\",\"\"),(\"ja\",\"\"),(\"ko\",\"\"),(\"pl\",\"\"),(\"pt-BR\",\"\"),(\"ru\",\"\"),(\"tr\",\"\"),(\"zh-CN\",\"\"),(\"zh-Hant\",\"\")))\n+TextReplacements=(Category=Game, bIsMinimalPatch=True, Namespace=\"\", Key=\"1D63ABC445833F2DC25DF69AB432B8C1\", NativeString=\"THAT WASN'T SUPPOSED TO HAPPEN\", LocalizedStrings=((\"ar\",\"\"),(\"en\",\"\"),(\"de\",\"\"),(\"es\",\"\"),(\"es-419\",\"\"),(\"fr\",\"\"),(\"it\",\"\"),(\"ja\",\"\"),(\"ko\",\"\"),(\"pl\",\"\"),(\"pt-BR\",\"\"),(\"ru\",\"\"),(\"tr\",\"\"),(\"zh-CN\",\"\"),(\"zh-Hant\",\"\")))\n+TextReplacements=(Category=Game, bIsMinimalPatch=True, Namespace=\"\", Key=\"08B2314B49478829F8A3AF82F872D959\", NativeString=\"WHOOPS!\", LocalizedStrings=((\"ar\",\"\"),(\"en\",\"\"),(\"de\",\"\"),(\"es\",\"\"),(\"es-419\",\"\"),(\"fr\",\"\"),(\"it\",\"\"),(\"ja\",\"\"),(\"ko\",\"\"),(\"pl\",\"\"),(\"pt-BR\",\"\"),(\"ru\",\"\"),(\"tr\",\"\"),(\"zh-CN\",\"\"),(\"zh-Hant\",\"\")))\n+TextReplacements=(Category=Game, bIsMinimalPatch=True, Namespace=\"\", Key=\"24B1F50A4C02F1858ED11284FFFC7D15\", NativeString=\"WE HIT A ROADBLOCK\", LocalizedStrings=((\"ar\",\"\"),(\"en\",\"\"),(\"de\",\"\"),(\"es\",\"\"),(\"es-419\",\"\"),(\"fr\",\"\"),(\"it\",\"\"),(\"ja\",\"\"),(\"ko\",\"\"),(\"pl\",\"\"),(\"pt-BR\",\"\"),(\"ru\",\"\"),(\"tr\",\"\"),(\"zh-CN\",\"\"),(\"zh-Hant\",\"\")))\n+TextReplacements=(Category=Game, bIsMinimalPatch=True, Namespace=\"\", Key=\"AF37334C4044DC4BA5E879B0E5287F7E\", NativeString=\"DRAT! WE'RE SORRY\", LocalizedStrings=((\"ar\",\"\"),(\"en\",\"\"),(\"de\",\"\"),(\"es\",\"\"),(\"es-419\",\"\"),(\"fr\",\"\"),(\"it\",\"\"),(\"ja\",\"\"),(\"ko\",\"\"),(\"pl\",\"\"),(\"pt-BR\",\"\"),(\"ru\",\"\"),(\"tr\",\"\"),(\"zh-CN\",\"\"),(\"zh-Hant\",\"\")))");
      app.UseEndpoints((Action<IEndpointRouteBuilder>) (endpoints => endpoints.MapControllers()));
    }
  }
}
