// Decompiled with JetBrains decompiler
// Type: Costura.AssemblyLoader
// Assembly: Shard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6B48981-D8C7-4092-89E2-EB158745CDB1
// Assembly location: C:\Users\vloge\Downloads\Rift-2.1.0.3 (1)\Shard.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Costura
{
  [CompilerGenerated]
  internal static class AssemblyLoader
  {
    private static object nullCacheLock = new object();
    private static Dictionary<string, bool> nullCache = new Dictionary<string, bool>();
    private static Dictionary<string, string> assemblyNames = new Dictionary<string, string>();
    private static Dictionary<string, string> symbolNames = new Dictionary<string, string>();
    private static int isAttached;

    private static string CultureToString(CultureInfo culture) => culture == null ? "" : culture.Name;

    private static Assembly ReadExistingAssembly(AssemblyName name)
    {
      foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
      {
        AssemblyName name1 = assembly.GetName();
        // ISSUE: reference to a compiler-generated method
        // ISSUE: reference to a compiler-generated method
        if (string.Equals(name1.Name, name.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(AssemblyLoader.CultureToString(name1.CultureInfo), AssemblyLoader.CultureToString(name.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
          return assembly;
      }
      return (Assembly) null;
    }

    private static void CopyTo(Stream source, Stream destination)
    {
      byte[] buffer = new byte[81920];
      int count;
      while ((count = source.Read(buffer, 0, buffer.Length)) != 0)
        destination.Write(buffer, 0, count);
    }

    private static Stream LoadStream(string fullName)
    {
      Assembly executingAssembly = Assembly.GetExecutingAssembly();
      if (!fullName.EndsWith(".compressed"))
        return executingAssembly.GetManifestResourceStream(fullName);
      using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(fullName))
      {
        using (DeflateStream deflateStream = new DeflateStream(manifestResourceStream, CompressionMode.Decompress))
        {
          MemoryStream memoryStream = new MemoryStream();
          // ISSUE: reference to a compiler-generated method
          AssemblyLoader.CopyTo((Stream) deflateStream, (Stream) memoryStream);
          memoryStream.Position = 0L;
          return (Stream) memoryStream;
        }
      }
    }

    private static Stream LoadStream(Dictionary<string, string> resourceNames, string name)
    {
      string fullName;
      // ISSUE: reference to a compiler-generated method
      return resourceNames.TryGetValue(name, out fullName) ? AssemblyLoader.LoadStream(fullName) : (Stream) null;
    }

    private static byte[] ReadStream(Stream stream)
    {
      byte[] buffer = new byte[stream.Length];
      stream.Read(buffer, 0, buffer.Length);
      return buffer;
    }

    private static Assembly ReadFromEmbeddedResources(
      Dictionary<string, string> assemblyNames,
      Dictionary<string, string> symbolNames,
      AssemblyName requestedAssemblyName)
    {
      string name = requestedAssemblyName.Name.ToLowerInvariant();
      if (requestedAssemblyName.CultureInfo != null && !string.IsNullOrEmpty(requestedAssemblyName.CultureInfo.Name))
        name = requestedAssemblyName.CultureInfo.Name + "." + name;
      byte[] rawAssembly;
      // ISSUE: reference to a compiler-generated method
      using (Stream stream = AssemblyLoader.LoadStream(assemblyNames, name))
      {
        if (stream == null)
          return (Assembly) null;
        // ISSUE: reference to a compiler-generated method
        rawAssembly = AssemblyLoader.ReadStream(stream);
      }
      // ISSUE: reference to a compiler-generated method
      using (Stream stream = AssemblyLoader.LoadStream(symbolNames, name))
      {
        if (stream != null)
        {
          // ISSUE: reference to a compiler-generated method
          byte[] rawSymbolStore = AssemblyLoader.ReadStream(stream);
          return Assembly.Load(rawAssembly, rawSymbolStore);
        }
      }
      return Assembly.Load(rawAssembly);
    }

    public static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
    {
      // ISSUE: reference to a compiler-generated field
      object nullCacheLock1 = AssemblyLoader.nullCacheLock;
      bool lockTaken1 = false;
      try
      {
        Monitor.Enter(nullCacheLock1, ref lockTaken1);
        // ISSUE: reference to a compiler-generated field
        if (AssemblyLoader.nullCache.ContainsKey(e.Name))
          return (Assembly) null;
      }
      finally
      {
        if (lockTaken1)
          Monitor.Exit(nullCacheLock1);
      }
      AssemblyName assemblyName = new AssemblyName(e.Name);
      // ISSUE: reference to a compiler-generated method
      Assembly assembly1 = AssemblyLoader.ReadExistingAssembly(assemblyName);
      if ((object) assembly1 != null)
        return assembly1;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      Assembly assembly2 = AssemblyLoader.ReadFromEmbeddedResources(AssemblyLoader.assemblyNames, AssemblyLoader.symbolNames, assemblyName);
      if ((object) assembly2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        object nullCacheLock2 = AssemblyLoader.nullCacheLock;
        bool lockTaken2 = false;
        try
        {
          Monitor.Enter(nullCacheLock2, ref lockTaken2);
          // ISSUE: reference to a compiler-generated field
          AssemblyLoader.nullCache[e.Name] = true;
        }
        finally
        {
          if (lockTaken2)
            Monitor.Exit(nullCacheLock2);
        }
        if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != AssemblyNameFlags.None)
          assembly2 = Assembly.Load(assemblyName);
      }
      return assembly2;
    }

    static AssemblyLoader()
    {
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("costura", "costura.costura.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.symbolNames.Add("costura", "costura.costura.pdb.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.aspnetcore.authorization", "costura.microsoft.aspnetcore.authorization.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.aspnetcore.components", "costura.microsoft.aspnetcore.components.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.aspnetcore.components.forms", "costura.microsoft.aspnetcore.components.forms.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.aspnetcore.components.web", "costura.microsoft.aspnetcore.components.web.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.aspnetcore.jsonpatch", "costura.microsoft.aspnetcore.jsonpatch.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.aspnetcore.metadata", "costura.microsoft.aspnetcore.metadata.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.aspnetcore.mvc.newtonsoftjson", "costura.microsoft.aspnetcore.mvc.newtonsoftjson.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.configuration.abstractions", "costura.microsoft.extensions.configuration.abstractions.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.configuration.binder", "costura.microsoft.extensions.configuration.binder.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.configuration.commandline", "costura.microsoft.extensions.configuration.commandline.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.configuration", "costura.microsoft.extensions.configuration.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.configuration.environmentvariables", "costura.microsoft.extensions.configuration.environmentvariables.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.configuration.fileextensions", "costura.microsoft.extensions.configuration.fileextensions.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.configuration.json", "costura.microsoft.extensions.configuration.json.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.configuration.usersecrets", "costura.microsoft.extensions.configuration.usersecrets.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.dependencyinjection.abstractions", "costura.microsoft.extensions.dependencyinjection.abstractions.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.dependencyinjection", "costura.microsoft.extensions.dependencyinjection.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.fileproviders.abstractions", "costura.microsoft.extensions.fileproviders.abstractions.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.fileproviders.embedded", "costura.microsoft.extensions.fileproviders.embedded.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.fileproviders.physical", "costura.microsoft.extensions.fileproviders.physical.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.filesystemglobbing", "costura.microsoft.extensions.filesystemglobbing.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.hosting.abstractions", "costura.microsoft.extensions.hosting.abstractions.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.hosting", "costura.microsoft.extensions.hosting.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.logging.abstractions", "costura.microsoft.extensions.logging.abstractions.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.logging.configuration", "costura.microsoft.extensions.logging.configuration.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.logging.console", "costura.microsoft.extensions.logging.console.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.logging.debug", "costura.microsoft.extensions.logging.debug.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.logging", "costura.microsoft.extensions.logging.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.logging.eventlog", "costura.microsoft.extensions.logging.eventlog.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.logging.eventsource", "costura.microsoft.extensions.logging.eventsource.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.options.configurationextensions", "costura.microsoft.extensions.options.configurationextensions.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.options", "costura.microsoft.extensions.options.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.extensions.primitives", "costura.microsoft.extensions.primitives.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.jsinterop", "costura.microsoft.jsinterop.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("microsoft.mobileblazorbindings.hosting", "costura.microsoft.mobileblazorbindings.hosting.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.symbolNames.Add("microsoft.mobileblazorbindings.hosting", "costura.microsoft.mobileblazorbindings.hosting.pdb.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("newtonsoft.json.bson", "costura.newtonsoft.json.bson.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.symbolNames.Add("newtonsoft.json.bson", "costura.newtonsoft.json.bson.pdb.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("newtonsoft.json", "costura.newtonsoft.json.dll.compressed");
      // ISSUE: reference to a compiler-generated field
      AssemblyLoader.assemblyNames.Add("system.runtime.compilerservices.unsafe", "costura.system.runtime.compilerservices.unsafe.dll.compressed");
    }

    public static void Attach()
    {
      // ISSUE: reference to a compiler-generated field
      if (Interlocked.Exchange(ref AssemblyLoader.isAttached, 1) == 1)
        return;
      AppDomain.CurrentDomain.AssemblyResolve += (ResolveEventHandler) ((sender, e) =>
      {
        // ISSUE: reference to a compiler-generated field
        object nullCacheLock1 = AssemblyLoader.nullCacheLock;
        bool lockTaken1 = false;
        try
        {
          Monitor.Enter(nullCacheLock1, ref lockTaken1);
          // ISSUE: reference to a compiler-generated field
          if (AssemblyLoader.nullCache.ContainsKey(e.Name))
            return (Assembly) null;
        }
        finally
        {
          if (lockTaken1)
            Monitor.Exit(nullCacheLock1);
        }
        AssemblyName assemblyName = new AssemblyName(e.Name);
        // ISSUE: reference to a compiler-generated method
        Assembly assembly1 = AssemblyLoader.ReadExistingAssembly(assemblyName);
        if ((object) assembly1 != null)
          return assembly1;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        Assembly assembly2 = AssemblyLoader.ReadFromEmbeddedResources(AssemblyLoader.assemblyNames, AssemblyLoader.symbolNames, assemblyName);
        if ((object) assembly2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          object nullCacheLock2 = AssemblyLoader.nullCacheLock;
          bool lockTaken2 = false;
          try
          {
            Monitor.Enter(nullCacheLock2, ref lockTaken2);
            // ISSUE: reference to a compiler-generated field
            AssemblyLoader.nullCache[e.Name] = true;
          }
          finally
          {
            if (lockTaken2)
              Monitor.Exit(nullCacheLock2);
          }
          if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != AssemblyNameFlags.None)
            assembly2 = Assembly.Load(assemblyName);
        }
        return assembly2;
      });
    }
  }
}
