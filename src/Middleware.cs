using System;

namespace USM.Middleware
{
  public delegate void MiddlewareDispatcher(Object action);
  public delegate MiddlewareDispatcher MiddlewareChainer(MiddlewareDispatcher dispatcher);
  public delegate MiddlewareChainer Middleware<State>(Store<State> store);
}
