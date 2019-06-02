using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace USM
{
  public static partial class StoreHelper<State> where State : struct
  {
    private static Reducer<State> combineHandler(List<(FieldInfo, Delegate)> handlers)
    {
      return (State state, Object action) =>
      {
        State newState = state;
        foreach (var (field, reducer) in handlers)
        {
          var prevState = field.GetValue(state);
          var reducedState = reducer.DynamicInvoke(prevState, action);

          Object box = newState;
          field.SetValue(box, reducedState);
          newState = (State) box;
        }
        return newState;
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

    public static Reducer<State> combineReducers<T, T2, T3>(
      (Expression<Func<State, T>>, Reducer<T>) composerA,
      (Expression<Func<State, T2>>, Reducer<T2>) composerB,
      (Expression<Func<State, T3>>, Reducer<T3>) composerC
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

      handlers.Add((
        (FieldInfo) (composerC.Item1.Body as MemberExpression).Member,
        composerC.Item2
      ));

      return combineHandler(handlers);
    }

    public static Reducer<State> combineReducers<T, T2, T3, T4>(
      (Expression<Func<State, T>>, Reducer<T>) composerA,
      (Expression<Func<State, T2>>, Reducer<T2>) composerB,
      (Expression<Func<State, T3>>, Reducer<T3>) composerC,
      (Expression<Func<State, T4>>, Reducer<T4>) composerD
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

      handlers.Add((
        (FieldInfo) (composerC.Item1.Body as MemberExpression).Member,
        composerC.Item2
      ));

      handlers.Add((
        (FieldInfo) (composerD.Item1.Body as MemberExpression).Member,
        composerD.Item2
      ));

      return combineHandler(handlers);
    }

    public static Reducer<State> combineReducers<T, T2, T3, T4, T5>(
      (Expression<Func<State, T>>, Reducer<T>) composerA,
      (Expression<Func<State, T2>>, Reducer<T2>) composerB,
      (Expression<Func<State, T3>>, Reducer<T3>) composerC,
      (Expression<Func<State, T4>>, Reducer<T4>) composerD,
      (Expression<Func<State, T5>>, Reducer<T5>) composerE
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

      handlers.Add((
        (FieldInfo) (composerC.Item1.Body as MemberExpression).Member,
        composerC.Item2
      ));

      handlers.Add((
        (FieldInfo) (composerD.Item1.Body as MemberExpression).Member,
        composerD.Item2
      ));

      handlers.Add((
        (FieldInfo) (composerE.Item1.Body as MemberExpression).Member,
        composerE.Item2
      ));

      return combineHandler(handlers);
    }

    public static Reducer<State> combineReducers<T, T2, T3, T4, T5, T6>(
      (Expression<Func<State, T>>, Reducer<T>) composerA,
      (Expression<Func<State, T2>>, Reducer<T2>) composerB,
      (Expression<Func<State, T3>>, Reducer<T3>) composerC,
      (Expression<Func<State, T4>>, Reducer<T4>) composerD,
      (Expression<Func<State, T5>>, Reducer<T5>) composerE,
      (Expression<Func<State, T6>>, Reducer<T6>) composerF
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

      handlers.Add((
        (FieldInfo) (composerC.Item1.Body as MemberExpression).Member,
        composerC.Item2
      ));

      handlers.Add((
        (FieldInfo) (composerD.Item1.Body as MemberExpression).Member,
        composerD.Item2
      ));

      handlers.Add((
        (FieldInfo) (composerE.Item1.Body as MemberExpression).Member,
        composerE.Item2
      ));

      handlers.Add((
        (FieldInfo) (composerF.Item1.Body as MemberExpression).Member,
        composerF.Item2
      ));

      return combineHandler(handlers);
    }
  }
}
