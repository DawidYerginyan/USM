using UnityEngine;

namespace USM.Unity.Json
{
  public class Vector2Converter : PartialConverter<Vector2>
  {
    protected override string[] GetPropertyNames()
    {
      return new[] { "x", "y" };
    }
  }
}
