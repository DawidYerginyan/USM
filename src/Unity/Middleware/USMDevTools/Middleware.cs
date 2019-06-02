using UnityEditor;
using Newtonsoft.Json;

using USM;
using USM.Middleware;

namespace USM.Unity.Middleware
{
  public partial class USMDevTools : EditorWindow
  {
    public static MiddlewareChainer middleware<State>(Store<State> store) where State : struct
    {
      var window = GetWindow<USMDevTools>("Unity State Manager Developer Tools");

      return next => action =>
      {
        next(action);
        window.addAction(
          action.GetType().DeclaringType.Name,
          action.GetType().Name,
          JsonConvert.SerializeObject(action, Formatting.Indented)
        );

        window.setStateString(JsonConvert.SerializeObject(store.getState(), Formatting.Indented));
      };
    }
  }
}
