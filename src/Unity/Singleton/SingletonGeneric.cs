using UnityEngine;

namespace USM.Unity
{
  public abstract class Singleton<T> : Singleton where T : MonoBehaviour
  {
    [SerializeField]
    private bool persist = true;
    private static T instance;
    private static readonly Object padlock = new Object();

    public static T getInstance()
    {
      if (quitting)
      {
        Debug.LogWarning($"[{nameof(Singleton)}<{typeof(T)}>] Instance will not be returned because the application is quitting.");
        return null;
      }

      lock (padlock)
      {
        if (instance != null)
        {
          return instance;
        }

        T[] instances = FindObjectsOfType<T>();
        int count = instances.Length;

        if (count > 0)
        {
          if (count == 1)
          {
            return instance = instances[0];
          }

          Debug.LogWarning($"[{nameof(Singleton)}<{typeof(T)}>] There should never be more than one {nameof(Singleton)} of type {typeof(T)} in the scene, but {count} were found. The first instance found will be used, and all others will be destroyed.");

          for (int i = 1, l = instances.Length; i < l; i++)
          {
            Destroy(instances[i]);
          }

          return instance = instances[0];
        }

        Debug.Log($"[{nameof(Singleton)}<{typeof(T)}>] An instance is needed in the scene and no existing instances were found, so a new instance will be created.");
        return instance = new GameObject($"({nameof(Singleton)}){typeof(T)}")
          .AddComponent<T>();
      }
    }

    private void Awake()
    {
      if (persist)
      {
        DontDestroyOnLoad(gameObject);
      }

      OnAwake();
    }

    protected virtual void OnAwake() { }
  }
}
