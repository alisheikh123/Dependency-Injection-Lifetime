using Dependency_Injection_Lifetime.Interface;

namespace Dependency_Injection_Lifetime.Controllers.Service
{
    public class OperationService : ITransientInterface, IScopeInterface, ISingletonInterface
    {
        private readonly Guid Id;
        public OperationService()
        {
            Id = Guid.NewGuid();
        }
        public Guid GetOperationId()
        {
            return Id;
        }
    }
}
