using Newtonsoft.Json;

using USM;
using USM.Middleware;

namespace USM.Unity.Middleware
{
  public static partial class Persist<State>
  {
    private static Store<State> store;

    public static string snap()
    {
      return JsonConvert.SerializeObject(store.getState(), Formatting.Indented);
    }
  }
}
