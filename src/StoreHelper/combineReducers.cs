using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace USM
{
  public static partial class StoreHelper<State>
  {
    private static Reducer<State> combineHandler(List<(FieldInfo, Delegate)> handlers)
    {
      return (State state, Object action) =>
      {
        var result = state;
        foreach (var handler in handlers)
        {
          var prevState = handler.Item1.GetValue(state);
          var newState = handler.Item2.DynamicInvoke(prevState, action);

          object boxer = result;
          handler.Item1.SetValue(boxer, newState);
          result = (State) boxer;
        }
        return result;
      };
    }

    public static Reducer<State> combineReducers<T, T2>(
      (Expression<Func<State, T>>, Reducer<T>) composerA,
      (Expression<Func<State, T2>>, Reducer<T2>) composerB
    )
    {
      List<(FieldInfo, Delegate)> handlers = new List<(FieldInfo, Delegate)>();

      handlers.Add((
        (FieldInfo) (composerA.Item1.Body as MemberExpression).Member,
        composerA.Item2
      ));

      handlers.Add((
        (FieldInfo) (composerB.Item1.Body as MemberExpression).Member,
        composerB.Item2
      ));

      return combineHandler(handlers);
    }
  }
}
