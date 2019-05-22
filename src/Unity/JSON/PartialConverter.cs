using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace USM.Unity.Json
{
  public abstract class PartialConverter<T> : JsonConverter
  {
    private static MemberInfo GetMember(string name)
    {
      BindingFlags flag = BindingFlags.Instance | BindingFlags.Public;
      FieldInfo field = typeof(T).GetField(name, flag);

      if (field != null)
      {
        return field;
      }

      PropertyInfo property = typeof(T).GetProperty(name, flag);

      if (property == null)
      {
        Throw(name, "Public instance field or property {0} not found.");
      }

      if (property.GetGetMethod() == null)
      {
        Throw(name, "Property getter {0} is not readable.");
      }

      if (property.GetSetMethod() == null)
      {
        Throw(name, "Property setter {0} is not writable.");
      }

      if (property.GetIndexParameters().Any())
      {
        Throw(name, "Not support property {0} with indexes.");
      }

      return property;
    }

    private static void Throw(string name, string format)
    {
      throw new ArgumentException(
        string.Format(format, $"{typeof(T).Name}.{name}"),
        "name"
      );
    }

    private static Object GetValue(MemberInfo member, Object target)
    {
      if (member is FieldInfo)
      {
        return (member as FieldInfo).GetValue(target);
      }

      return (member as PropertyInfo).GetValue(target, null);
    }

    private static void SetValue(MemberInfo member, Object target, Object value)
    {
      if (member is FieldInfo)
      {
        (member as FieldInfo).SetValue(target, value);
        return;
      }

      (member as PropertyInfo).SetValue(target, value, null);
    }

    private static Type GetValueType(MemberInfo member)
    {
      if (member is FieldInfo)
      {
        return (member as FieldInfo).FieldType;
      }

      return (member as PropertyInfo).PropertyType;
    }

    private static Dictionary<string, MemberInfo> properties;

    private Dictionary<string, MemberInfo> GetProperties()
    {
      if (null != properties)
      {
        return properties;
      }

      string[] names = GetPropertyNames();

      if (names == null || !names.Any())
      {
        throw new InvalidProgramException("GetPropertyNames() cannot return empty.");
      }

      if (names.Any(name => string.IsNullOrEmpty(name)))
      {
        throw new InvalidProgramException("GetPropertyNames() cannot contain empty value.");
      }

      properties = names.Distinct()
        .ToDictionary(
          name => name,
          name => GetMember(name)
        );

      return properties;
    }

    protected abstract string[] GetPropertyNames();

    protected virtual T CreateInstance()
    {
      return Activator.CreateInstance<T>();
    }

    public override bool CanConvert(Type objectType)
    {
      return typeof(T) == objectType;
    }

    public override Object ReadJson(
      JsonReader reader,
      Type objectType,
      Object existingValue,
      JsonSerializer serializer
    )
    {
      if (reader.TokenType == JsonToken.Null)
      {
        return null;
      }

      JObject obj = JObject.Load(reader);
      var result = CreateInstance() as Object;

      foreach (var pair in GetProperties())
      {
        Object value = obj[pair.Key].ToObject(
          GetValueType(pair.Value),
          serializer
        );
        SetValue(pair.Value, result, value);
      }

      return result;
    }

    public override void WriteJson(
      JsonWriter writer,
      Object value,
      JsonSerializer serializer
    )
    {
      JObject obj = new JObject();

      foreach (var pair in GetProperties())
      {
        var val = GetValue(pair.Value, value);
        obj[pair.Key] = JToken.FromObject(val, serializer);
      }

      obj.WriteTo(writer);
    }
  }
}
