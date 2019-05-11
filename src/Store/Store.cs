using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reactive.Subjects;

namespace USM
{
  public sealed class INIT_STORE { }

  public class Store<State>
  {
    State state;
    readonly Reducer<State> rootReducer;
    readonly BehaviorSubject<State> stateStream;

    Store(Reducer<State> reducer)
    {
      rootReducer = reducer;
      state = rootReducer(state, new INIT_STORE());
      stateStream = new BehaviorSubject<State>(state);
    }

    public State getState()
    {
      return state;
    }

    public void dispatch(Object action)
    {
      state = rootReducer(state, action);
      stateStream.OnNext(state);
    }

    public IDisposable subscribe(IObserver<State> observer)
    {
      return stateStream.Subscribe(observer);
    }
  }
}
