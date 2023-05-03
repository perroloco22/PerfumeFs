using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfumeApiBackend.DataAccess;
using PerfumeApiBackend.Helpers.Jwt;
using PerfumeApiBackend.Models;

namespace PerfumeApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly PerfumeContext _perfumeContext;
        private readonly JwtSettings _jwtSettings;

        public LoginController( PerfumeContext perfumeContext, JwtSettings jwtSettings)
        {
            _perfumeContext = perfumeContext;
            _jwtSettings = jwtSettings; 

        }

        [HttpPost]
        public async Task<ActionResult<UserToken>> GetToken(UserLogin userLogin)
        {
            try
            {
                var searchUser = await (from u in _perfumeContext.Users
                           where userLogin.Email == u.Email && userLogin.Password == u.Password
                           select new UserToken 
                           {
                               UserName = u.Name,
                               EmailId = u.Email,
                               Id = u.ID,
                               Category = u.UserCategory.Category
                           }).FirstOrDefaultAsync();

                if (searchUser == null)
                {
                    return NotFound("Wrong Credentials");
                }

                var userToken = new UserToken();
                userToken = JwtHelpers.GetToken(searchUser, _jwtSettings); ;

                return Ok(userToken);

            }
            catch (Exception ex)
            {

                throw new Exception("Get Token Error", ex);
            }
          
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Super")]
        public async Task<ActionResult> GetUsersList()
        {
            var listUser = await (from user in _perfumeContext.Users
                           select new
                           {
                               Name = user.Name,
                               LastName = user.LastName,
                               Email = user.Email,
                           }).ToListAsync();

            return Ok(listUser);
        }



    }
}
