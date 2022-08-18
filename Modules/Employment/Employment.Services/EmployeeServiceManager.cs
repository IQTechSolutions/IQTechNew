using Contracts.Logger;
using Employment.Repo.Contracts;
using Employment.Services.Contracts;

namespace Employment.Services
{
    public sealed class EmployeeServiceManager : IEmployeeServiceManager
    {
        private readonly Lazy<IEmployeeService> _employeeService;
        public EmployeeServiceManager(IEmployeeRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger));
        }

        public IEmployeeService EmployeeService => _employeeService.Value;
    }
}
