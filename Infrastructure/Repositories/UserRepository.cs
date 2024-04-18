using Core.Entity;
using DTO.User;

namespace Infrastructure.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationContext _applicationContext;

        public UserRepository(ApplicationContext applicationContext) 
        {
            _applicationContext = applicationContext;
        }

        public UserEntity Create(UserEntity user)
        {
            _applicationContext.Users.Add(user);
            _applicationContext.SaveChanges();
            return user;
        }

        public UserEntity Update(int id, UpdateUserRequest request)
        {
            var user = _applicationContext.Users.FirstOrDefault(x => x.Id == id);
            user.FIO = request.FIO;
            user.Password = request.Password;
            user.LastModifiedDate = request.LastModifiedDate;

            _applicationContext.Users.Update(user);
            _applicationContext.SaveChanges();
            return user;
        }

        public UserEntity GrantAccess(GrantAccessUserRequest request)
        {
            var user = _applicationContext.Users.FirstOrDefault(x => x.Username == request.Username);
            user.Role = request.Role;
            _applicationContext.Users.Update(user);
            _applicationContext.SaveChanges();
            return user;
        }

        public UserEntity ShowByUsername(string Username)
        {
            return _applicationContext.Users.FirstOrDefault(x => x.Username == Username);
        }

        public void Delete(int id)
        {
            _applicationContext.Users.Remove(_applicationContext.Users.FirstOrDefault(x => x.Id == id)!);
            _applicationContext.SaveChanges();
        }
    }
}
