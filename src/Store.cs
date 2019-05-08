namespace USM
{
  public class Store<TState>
  {
    TState state;

    public void dispatch<T>(Action<T> action) { }

    public TState getState()
    {
      return this.state;
    }
  }
}
