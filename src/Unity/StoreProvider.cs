using System;
using UnityEngine;

namespace USM.Unity
{
  public static class StoreProvider<State> where State : struct
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
        throw new NullReferenceException("No store in the store provider. Probably due to missing registration or invalid script execution order. Please register the store first through: StoreProvider<T>.registerStore(store) and check if #create() in your GameStore class is defined. Otherwise, fix the script execution order.");
      }

      return store;
    }
  }
}
