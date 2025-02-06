namespace Vanilla.API.Integration.Tests.Common;

public class TestResponse<T>
{
    public bool IsSucceed { get; set; } = true;
    public Dictionary<string, string[]> Messages { get; set; } = [];

    public T? Data { get; set; }
}