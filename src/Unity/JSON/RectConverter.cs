using UnityEngine;

namespace USM.Unity.Json
{
  public class RectConverter : PartialConverter<Rect>
  {
    protected override string[] GetPropertyNames()
    {
      return new[] { "x", "y", "width", "height" };
    }
  }
}
