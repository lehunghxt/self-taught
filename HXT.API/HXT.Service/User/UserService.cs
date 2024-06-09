using HXT.Domain.Users;
using HXT.RedisCache;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HXT.Service.User
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICacheHandler _cacheHandler;

        public UserService(IUserRepository userRepository, ICacheHandler cacheHandler)
        {
            _userRepository = userRepository;
            _cacheHandler = cacheHandler;
        }

        public async Task<List<Domain.Users.User>> Get()
        {
            var usersFromCache = await _cacheHandler.StringGetAsync("listUser");
            if (!string.IsNullOrEmpty(usersFromCache))
            {
                return JsonConvert.DeserializeObject<List<Domain.Users.User>>(usersFromCache);
            }

            var users = await _userRepository.GetAll().ToListAsync();

            if (users != null)
            {
                await _cacheHandler.StringSetAsync("listUser", JsonConvert.SerializeObject(users));
            }
            return users;
        }
    }
}
