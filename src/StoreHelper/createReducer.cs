using System;

namespace USM
{
  public static partial class StoreHelper<State>
  {
    public static Reducer<State> createReducer(Func<State, Object, State> fun) {
      return new Reducer<State>(fun);
    }
  }
}
