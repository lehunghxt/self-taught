using HXT.Domain.Departments;
using HXT.Domain.Interfaces;

namespace HXT.Domain.Users
{
    public interface IUserRepository : IRepository<User>
    {
        User NewUser(string userName
            , string email
            , Department department);
    }
}
