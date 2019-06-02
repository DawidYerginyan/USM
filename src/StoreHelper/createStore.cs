using USM.Middleware;

namespace USM
{
  public static partial class StoreHelper<State> where State : struct
  {
    public static Store<State> createStore(Reducer<State> rootReducer) {
      store = new Store<State>(rootReducer);
      return store;
    }

    public static Store<State> createStore(
      Reducer<State> rootReducer,
      params Middleware<State>[] middleware
    )
    {
      store = new Store<State>(rootReducer);
      store.applyMiddleware(middleware);

      return store;
    }
  }
  }
