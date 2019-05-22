using UnityEngine;

namespace USM.Unity.Json
{
  public class RectOffsetConverter : PartialConverter<RectOffset>
  {
    protected override string[] GetPropertyNames()
    {
      return new[] { "left", "right", "top", "bottom" };
    }
  }
}
