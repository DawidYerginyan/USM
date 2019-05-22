using System;
using UnityEngine;
using System.Reactive;

namespace USM.Unity
{
  public abstract class Component<State, T> : MonoBehaviour where T : MonoBehaviourStore<State, T>
  {
    protected T store;
    private IObserver<State> observer;

    protected virtual void Awake()
    {
      store = Singleton<T>.getInstance();
      observer = Observer.Create<State>(Render);
      store.subscribe(observer);
    }

    protected abstract void Render(State state);
  }
}
