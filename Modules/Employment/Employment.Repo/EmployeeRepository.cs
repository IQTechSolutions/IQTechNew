using Employment.Base.Entities;
using Employment.Repo.Contracts;
using EnviBin.Web.DataStores.BaseTypes;
using Microsoft.EntityFrameworkCore;

namespace Employment.Base.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Employee> GetAllEmployees(bool trackChanges)
        {
            var employees = FindAll(trackChanges).OrderBy(c => c.Name).ToList();
            return employees;
        }
    }

}