using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace USM
{
  public static partial class StoreHelper
  {
    static Func<I, R> memoize<I, R>(
      Func<I, R> selectorFunction
    )
    {
      ConcurrentDictionary<I, R> memo = new ConcurrentDictionary<I, R>(EqualityComparer<I>.Default);

      R result(I selector)
      {
        if (memo.TryGetValue(selector, out R memoisedResult))
        {
          return memoisedResult;
        }
        else
        {
          R rawResult = selectorFunction(selector);
          memo[selector] = rawResult;

          return rawResult;
        }
      }
      return result;
    }

    public static Func<I, R> createSelector<I, R, T1>(
        Func<I, T1> selector1,
        Func<T1, R> combine)
    {
      return memoize<I, R>(state => combine(selector1(state)));
    }
  }
}
