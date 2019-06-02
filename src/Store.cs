using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reactive.Subjects;
using Newtonsoft.Json;

using USM.Middleware;

namespace USM
{
  public sealed class INIT_STORE { }

  public class Store<State> where State : struct
  {
    State state;
    MiddlewareDispatcher middleware;
    readonly Reducer<State> rootReducer;
    readonly BehaviorSubject<State> emitter;

    public Store(Reducer<State> reducer)
    {
      applyMiddleware();
      rootReducer = reducer;
      reduce(new INIT_STORE());
      emitter = new BehaviorSubject<State>(state);
    }

    public State getState()
    {
      return state;
    }

    public void dispatch(Object action)
    {
      middleware(action);
    }

    public IDisposable subscribe(IObserver<State> observer)
    {
      return emitter.Subscribe(observer);
    }

    public string serialize()
    {
      return JsonConvert.SerializeObject(state, Formatting.Indented);
    }

    public void applyMiddleware(params Middleware<State>[] middlewares)
    {
      middleware = middlewares
        .Select(middleware => middleware(this))
        .Reverse()
        .Aggregate<MiddlewareChainer, MiddlewareDispatcher>(
          execute,
          (executor, chainer) => chainer(executor)
        );
    }

    private void reduce(Object action)
    {
      state = rootReducer(state, action);
    }

    private void emit()
    {
      emitter.OnNext(state);
    }

    private void execute(Object action)
    {
      State prevState = state;
      reduce(action);

      if (!state.Equals(prevState))
      {
        emit();
      }
    }
  }
}
