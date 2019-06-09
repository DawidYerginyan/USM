using System;
using UnityEngine;
using System.Reactive;

namespace USM.Unity
{
  public abstract class ComponentBase<State> : MonoBehaviour where State : struct
  {
    protected MonoBehaviourStore<State> store;
    protected IObserver<State> observer;

    protected void action(System.Object action)
    {
      store.dispatch(action);
    }
  }

  public abstract class Component<State> : ComponentBase<State> where State : struct
  {
    protected virtual void Awake()
    {
      store = StoreProvider<State>.provideStore();
      observer = Observer.Create<State>(Render);
      store.subscribe(observer);
    }

    protected abstract void Render(State state);
  }

  public abstract class Component<Props, State> : ComponentBase<State>
    where State : struct
    where Props : struct
  {
    protected virtual void Awake()
    {
      store = StoreProvider<State>.provideStore();
      Action<State> compose = (State state) => Render(mapStateToProps(state));
      observer = Observer.Create<State>(compose);
      store.subscribe(observer);
    }

    protected abstract Props mapStateToProps(State state);

    protected abstract void Render(Props props);
  }
}
