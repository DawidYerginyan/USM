namespace USM
{
  public interface IAction
  {
    string Type { get; }
    dynamic payload { get; }
  }
  public class Action<T>
  {
    public string type { get; private set; }
    public T payload { get; private set; }
    public Action(string type, T payload)
    {
      this.type = type;
      this.payload = payload;
    }
  }
}
