using UnityEngine;

namespace USM.Unity
{
  public abstract class Singleton : MonoBehaviour
  {
    public static bool quitting { get; private set; }

    private void OnApplicationQuit()
    {
      quitting = true;
    }
  }
}
