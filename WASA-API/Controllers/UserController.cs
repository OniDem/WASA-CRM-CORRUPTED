using Core.Entity;
using DTO.User;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WASA_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<UserEntity?> RegUser([FromBody] RegUserRequest request)
        {
            if (ModelState.IsValid)
            {
               return await _userService.RegUser(request);
            }
            return null;
        }

        [HttpPost]
        public async Task<UserEntity?> AuthUser([FromBody] AuthUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.AuthUser(request);
                return user;
            }
            return null;
        }

        [HttpPost]
        public async Task<UserEntity?> GrantAccessUser([FromBody] GrantAccessUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.GrantAccessUser(request);
                return user;
            }
            return null;
        }

        [HttpPut]
        public async Task<UserEntity?> UpdateUser(int id, UpdateUserRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.UpdateUser(id, request);
                return user;
            }
            return null;
        }

        [HttpDelete]
        public async Task DeleteUser([FromBody] int id)
        {
            await _userService.Delete(id);
        }
    }
}
