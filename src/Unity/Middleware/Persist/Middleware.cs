using USM;
using USM.Middleware;

namespace USM.Unity.Middleware
{
  public static partial class Persist<State>
  {
    public static MiddlewareChainer middleware(Store<State> store)
    {
      Persist<State>.store = store;
      return next => action => next(action);
    }
  }
}
