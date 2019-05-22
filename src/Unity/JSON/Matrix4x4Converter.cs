using UnityEngine;
using System.Linq;

namespace USM.Unity.Json
{
  public class Matrix4x4Converter : PartialConverter<Matrix4x4>
  {
    string[] indices = new[] { "0", "1", "2", "3" };

    protected override string[] GetPropertyNames()
    {
      return indices
        .SelectMany(row => indices.Select(column => $"m{row}{column}"))
        .ToArray();
    }
  }
}
