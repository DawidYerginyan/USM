using System;

namespace USM
{
  public delegate State Reducer<State>(State state, Object action);
}
