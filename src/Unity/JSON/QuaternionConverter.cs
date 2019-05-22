using UnityEngine;

namespace USM.Unity.Json
{
  public class QuaternionConverter : PartialConverter<Quaternion>
  {
    protected override string[] GetPropertyNames()
    {
      return new[] { "x", "y", "z", "w" };
    }
  }
}
