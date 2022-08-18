using Employment.Base.Entities;

namespace Employment.Services.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllCompanies(bool trackChanges);
    }
}
