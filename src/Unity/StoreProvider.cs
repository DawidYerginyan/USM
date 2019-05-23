using System;
using UnityEngine;

namespace USM.Unity
{
  public static class StoreProvider<State>
  {
    private static MonoBehaviourStore<State> store;
    public static void registerStore(MonoBehaviourStore<State> store)
    {
      StoreProvider<State>.store = store;
    }

    public static MonoBehaviourStore<State> provideStore()
    {
      if (store == null)
      {
        throw new NullReferenceException("No store in the store provider. Please register the store first through: StoreProvider<T>.registerStore(store). Probably missing #create() in your GameStore class.");
      }

      return store;
    }
  }
}
