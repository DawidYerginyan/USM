using UnityEditor;

using USM;
using USM.Middleware;

namespace USM.Unity.Middleware
{
  public partial class USMDevTools : EditorWindow
  {
    public static MiddlewareChainer middleware<State>(Store<State> store)
    {
      var window = GetWindow<USMDevTools>("Unity State Manager Developer Tools");

      return next => action =>
      {
        next(action);
      };
    }
  }
}
