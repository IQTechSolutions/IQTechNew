using Contracts.Logger;
using Employment.Base.Entities;
using Employment.Repo.Contracts;
using Employment.Services.Contracts;

namespace Employment.Services
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public EmployeeService(IEmployeeRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<Employee> GetAllCompanies(bool trackChanges)
        {
            try
            {
                var companies = _repository.Employees.GetAllEmployees(trackChanges);
                return companies;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllCompanies)} service method {ex}");
            throw;
            }

        }
    }
}
