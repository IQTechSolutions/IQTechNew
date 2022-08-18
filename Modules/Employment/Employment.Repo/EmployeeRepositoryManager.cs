using Employment.Base.Repositories;
using Employment.Repo.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Employment.Repo
{
    public sealed class EmployeeRepositoryManager : IEmployeeRepositoryManager
    {
        private readonly DbContext _repositoryContext;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;

        public EmployeeRepositoryManager(DbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
        }

        public IEmployeeRepository Employees => _employeeRepository.Value;

        public void Save() => _repositoryContext.SaveChanges();
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }

}
