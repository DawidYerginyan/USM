using System;
using System.Reactive;
using UnityEngine;

namespace USM.Unity
{
  public class MonoBehaviourStore<State> : Singleton<MonoBehaviourStore<State>>
  {
    [SerializeField]
    private bool debug = false;
    Store<State> store;

    public State getState()
    {
      return store.getState();
    }

    public void dispatch(object action)
    {
      store.dispatch(action);
    }

    public IDisposable subscribe(IObserver<State> observer)
    {
      return store.subscribe(observer);
    }

    protected override void OnAwake()
    {
      if (debug)
      {
        USMDevTools.open();
      }
    }
  }
}
