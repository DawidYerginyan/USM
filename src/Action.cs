namespace USM
{
  public class Action<T>
  {
    public string type { get; private set; }
    public T payload { get; private set; }
  }
}
