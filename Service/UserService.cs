using Core.Entity;
using DTO.User;
using Infrastructure.Repositories;

namespace Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<UserEntity> RegUser(RegUserRequest request)
        {
            return _userRepository.Create(new()
            {
                Role = request.Role,
                FIO = request.FIO,
                Username = request.Username,
                Password = request.Password,
                CreateDate = request.CreateDate,
                LastModifiedDate = request.LastModifiedDate
            });
        }

        public async Task<UserEntity> AuthUser(AuthUserRequest request)
        {
            var user = _userRepository.ShowByUsername(request.Username);
            if(user != null)
            {
                if (user.Password == request.Password)
                    return user;
            }
            return null;
        }

        public async Task<UserEntity> GrantAccessUser(GrantAccessUserRequest request)
        {
            var user = _userRepository.ShowByUsername(request.Username);
            if(user != null)
            {
                return _userRepository.GrantAccess(new()
                {
                    Username = request.Username,
                    Role = request.Role
                });
                
            }
            return null;
        }

        public async Task<UserEntity> ShowByUsername(string username)
        {
            return _userRepository.ShowByUsername(username);
        }

        public async Task<UserEntity> UpdateUser(int id, UpdateUserRequest request)
        {
            return _userRepository.Update(id, request);
        }

        public async Task Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
