namespace Dependency_Injection_Lifetime.Interface
{
    public interface ITransientInterface
    {
        Guid GetOperationId();
    }
    public interface IScopeInterface
    {
        Guid GetOperationId();
    }
    public interface ISingletonInterface
    {
        Guid GetOperationId();
    }
}
