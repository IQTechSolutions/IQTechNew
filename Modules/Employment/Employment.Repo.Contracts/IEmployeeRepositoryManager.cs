namespace Employment.Repo.Contracts
{
    public interface IEmployeeRepositoryManager
    {
        IEmployeeRepository Employees { get; }

        void Save();
    }
}
