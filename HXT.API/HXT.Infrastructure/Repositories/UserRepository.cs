using HXT.Domain.Departments;
using HXT.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace HXT.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public User NewUser(string userName, string email, Department department)
        {
            var user = new User(userName, email, department);
            if (user.ValidOnAdd())
            {
                this.Add(user);
                return user;
            }
            else
                throw new Exception("User invalid");
        }

        public User Edit(User user)
        {
            if (user.ValidOnAdd())
            {
                this.Update(user);
                return user;
            }
            else
                throw new Exception("User invalid");
        }

        public User Remove(User user)
        {
            this.Delete(user);
            return user;
        }

        public async Task<User?> GetUserId(Guid userId)
        {
            var user = await this.Find(e => e.Id == userId).FirstOrDefaultAsync();
            return user;
        }
    }
}
