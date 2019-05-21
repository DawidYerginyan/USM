using UnityEditor;

using USM.Middleware;

namespace USM.Unity
{
  public partial class USMDevTools<State> : EditorWindow
  {
    private Store<State> store;

    private MiddlewareChainer chainer = next => action => {
      next(action);
    };

    public USMDevTools<State> applyStore(Store<State> store)
    {
      this.store = store;

      return this;
    }

    public MiddlewareChainer registerChainer()
    {
      return this.chainer;
    }
  }
}
