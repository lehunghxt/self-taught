using HXT.Domain.Interfaces;

namespace HXT.Domain.Departments
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Department AddDepartment(string departmentName);
    }
}
