using System;
using System.Reactive;
using UnityEngine;

namespace USM.Unity
{
  public class MonoBehaviourStore<State, T> : Singleton<T> where T : MonoBehaviour
  {
    protected Store<State> store;

    public State getState()
    {
      return store.getState();
    }

    public void dispatch(System.Object action)
    {
      store.dispatch(action);
    }

    public IDisposable subscribe(IObserver<State> observer)
    {
      return store.subscribe(observer);
    }

    protected override void OnAwake() { }
  }
}
