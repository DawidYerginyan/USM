using System;
using UnityEngine;
using System.Reactive;

namespace USM.Unity
{
  public abstract class Component<State> : MonoBehaviour
  {
    protected MonoBehaviourStore<State> store;
    private IObserver<State> observer;

    protected virtual void Awake()
    {
      store = StoreProvider<State>.provideStore();
      observer = Observer.Create<State>(Render);
      store.subscribe(observer);
    }

    protected abstract void Render(State state);
  }
}
