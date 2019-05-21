using UnityEditor;

using USM.Middleware;

namespace USM.Unity
{
  public partial class USMDevTools<State> : EditorWindow
  {
    public static MiddlewareChainer middleware(Store<State> store) {
      return GetWindow<USMDevTools<State>>("Unity State Manager Developer Tools")
        .applyStore(store)
        .registerChainer();
    }
  }
}
