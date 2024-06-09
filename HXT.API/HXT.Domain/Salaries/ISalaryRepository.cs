using HXT.Domain.Interfaces;
using HXT.Domain.Users;

namespace HXT.Domain.Salaries
{
    public interface ISalaryRepository : IRepository<Salary>
    {
        Salary AddUserSalary(User user, float coefficientsSalary, float workdays);
    }
}
