using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USM.Unity.Json
{
  public class DictionaryConverter : JsonConverter
  {
    public override bool CanConvert(Type objectType)
    {
      if (!objectType.IsGenericType)
      {
        return false;
      }

      Type type = objectType.GetGenericTypeDefinition();

      return typeof(Dictionary<,>) == type || typeof(IDictionary<,>) == type;
    }

    public override System.Object ReadJson(
      JsonReader reader,
      Type objectType,
      System.Object existingValue,
      JsonSerializer serializer
    )
    {
      if (reader.TokenType == JsonToken.Null)
      {
        return null;
      }

      IDictionary result = Activator.CreateInstance(objectType) as IDictionary;
      Type[] args = objectType.GetGenericArguments();

      foreach (JObject pair in JArray.Load(reader))
      {
        System.Object key = pair["Key"].ToObject(args[0], serializer);
        System.Object value = pair["Value"].ToObject(args[1], serializer);

        if (!result.Contains(key))
        {
          result.Add(key, value);
          continue;
        }

        Debug.LogWarningFormat("Ignore pair with repeat key: {0}", pair.ToString(Formatting.None));
      }

      return result;
    }

    public override void WriteJson(
      JsonWriter writer,
      System.Object value,
      JsonSerializer serializer
    )
    {
      serializer.Serialize(
        writer,
        (value as IDictionary).Cast<System.Object>()
      );
    }
  }
}
