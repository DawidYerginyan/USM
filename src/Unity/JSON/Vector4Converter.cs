using UnityEngine;

namespace USM.Unity.Json
{
  public class Vector4Converter : PartialConverter<Vector4>
  {
    protected override string[] GetPropertyNames()
    {
      return new[] { "x", "y", "z", "w" };
    }
  }
}
