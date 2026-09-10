

namespace ServiceContracts;

public class ServiceResults<T>
{
    public bool Success { get; set; }

    public T? Data { get; set; }

    public List<string> errors { get; set; } = new();
}
