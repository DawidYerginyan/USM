using UnityEngine;

namespace USM.Unity.Json
{
  public class ColorConverter : PartialConverter<Color>
  {
    protected override string[] GetPropertyNames()
    {
      return new[] { "r", "g", "b", "a" };
    }
  }
}
