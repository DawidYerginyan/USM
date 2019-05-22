using UnityEngine;

namespace USM.Unity.Json
{
  public class Vector3Converter : PartialConverter<Vector3>
  {
    protected override string[] GetPropertyNames()
    {
      return new[] { "x", "y", "z" };
    }
  }
}
