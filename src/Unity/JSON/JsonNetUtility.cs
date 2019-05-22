using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace USM.Unity.Json
{
  public static class JsonNetUtility
  {
    public const string JsonNETNamespace = nameof(Newtonsoft) + "." + nameof(Newtonsoft.Json);
    public const string USMNamespace = nameof(USM);

    public static JsonSerializerSettings defaultSettings = new JsonSerializerSettings()
    {
      Converters = CreateConverters()
    };

    [RuntimeInitializeOnLoadMethod]
    [UnityEditor.InitializeOnLoadMethod]
    private static void Initialize()
    {
      if (JsonConvert.DefaultSettings == null)
      {
        JsonConvert.DefaultSettings = () => defaultSettings;
      }
    }

    private static List<JsonConverter> CreateConverters()
    {
      var custom = FindConverterTypes()
        .Select(type => CreateConverter(type));

      var builtIn = new JsonConverter[]
      {
        new StringEnumConverter(),
        new VersionConverter()
      };

      return custom.Concat(builtIn)
        .Where(converter => converter != null)
        .ToList();
    }

    private static JsonConverter CreateConverter(Type type)
    {
      try
      {
        return Activator.CreateInstance(type) as JsonConverter;
      }
      catch (Exception ex)
      {
        Debug.LogErrorFormat("Can't create JsonConverter {0}:\n{1}", type, ex);
      }

      return null;
    }

    private static Type[] FindConverterTypes()
    {
      return AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(asm => asm.GetTypes())
        .Where(type => typeof(JsonConverter).IsAssignableFrom(type))
        .Where(type => !type.IsAbstract && !type.IsGenericTypeDefinition)
        .Where(type => type.GetConstructor(new Type[0]) != null)
        .Where(type => !(type.Namespace != null && type.Namespace.StartsWith(JsonNETNamespace)))
        .OrderBy(type => type.Namespace != null && type.Namespace.StartsWith(USMNamespace))
        .ToArray();
    }
  }
}
