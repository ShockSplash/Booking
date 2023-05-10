using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IdentityProvider.Data;
using IdentityProvider.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer4.Quickstart.UI
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public UserController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<RegistrationResponse> Index([FromBody] RegistrationViewModel model)
        {
            var isUserExist = await _dbContext.Users
                .Where(x => x.UserName == model.UserName)
                .AnyAsync(CancellationToken.None);

            if (isUserExist)
            {
                return new RegistrationResponse()
                {
                    IsSuccess = false,
                    Comment = "ПОльзователь с таким именем уже существует"
                };
            }

            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password) ||
                string.IsNullOrEmpty(model.UserName))
            {
                return new RegistrationResponse()
                {
                    IsSuccess = false,
                    Comment = "Не заполнены обязательные поля"
                };
            }
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return new RegistrationResponse()
                {
                    IsSuccess = true
                };
            }
            else
            {
                return new RegistrationResponse()
                {
                    IsSuccess = false,
                    Comment = string.Join("; ", result.Errors.Select(x => x.Description))
                };
            }

        } 
    }
}