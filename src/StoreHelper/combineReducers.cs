using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace USM
{
  public static partial class StoreHelper<State>
  {
    private static Reducer<State> combineHandler(List<Tuple<FieldInfo, Delegate>> handlers)
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
      Tuple<Expression<Func<State, T>>, Reducer<T>> composer,
      Tuple<Expression<Func<State, T2>>, Reducer<T2>> composer2
    )
    {
      List<Tuple<FieldInfo, Delegate>> handlers = new List<Tuple<FieldInfo, Delegate>>();

      handlers.Add(new Tuple<FieldInfo, Delegate>(
        (FieldInfo) (composer.Item1.Body as MemberExpression).Member,
        composer.Item2
      ));

      handlers.Add(new Tuple<FieldInfo, Delegate>(
        (FieldInfo) (composer2.Item1.Body as MemberExpression).Member,
        composer2.Item2
      ));

      return combineHandler(handlers);
    }
  }
}
