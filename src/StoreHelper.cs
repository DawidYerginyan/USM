namespace USM
{
  public static partial class StoreHelper
  {
    public static void createStore() { }
    public static void provideStore() {  }
    public static void applyMiddleware() { }

    public static void createReducer() { }
    public static void combineReducers() { }

    public static Action<T> createAction<T>(string type, T payload)
    {
      return new Action<T>(type, payload);
    }
  }
}
