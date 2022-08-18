using Employment.Base.Entities;

namespace Employment.Repo.Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees(bool trackChanges);
    }
}
