using UnityEngine;

namespace USM.Unity.Json
{
  public class BoundsConverter : PartialConverter<Bounds>
  {
    protected override string[] GetPropertyNames()
    {
      return new[] { "extents", "center" };
    }
  }
}
