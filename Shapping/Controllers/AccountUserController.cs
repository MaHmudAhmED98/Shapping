using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shapping.DTO;
using Shapping.DTO.RegestarDto;
using Shapping.Handler;
using Shapping.Model;
using Shapping.Reprostary;

namespace Shapping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountUserController : ControllerBase
    {
        private readonly AccountHandler  _accountHandler;
        private readonly IAccountUser _accountRepository;

        public AccountUserController(UserManager<AppUser> userManager, IConfiguration config, IAccountUser accountRepository)
        {
            _accountHandler = new AccountHandler(userManager, config);
            _accountRepository = accountRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUserDto registerUser)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = registerUser.UserName,
                    Name = registerUser.Name,
                    Email = registerUser.Email,
                    PhoneNumber = registerUser.PhoneNumber,
                    BranchId = registerUser.BranchId,
                    Address = registerUser.Address,
                };

                var result = await _accountRepository.CreateUser(user, registerUser.Password);
                if (result.Succeeded)
                {
                    return Ok("Account Add Success");
                }
                else
                {
                    return BadRequest(string.Join(",", result.Errors.Select(e => e.Description).ToList()));
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto loginUser)
        {
            if (ModelState.IsValid)
            {
                var user = await _accountRepository.GetUser(loginUser.UserName);
                if (user != null)
                {
                    var found = await _accountRepository.GetPassword(user, loginUser.Password);
                    if (found)
                    {
                        var (token, expiration) = await _accountHandler.GenerateJwtTokenAsync(user);
                        return Ok(new
                        {
                            token,
                            expiration,
                        });
                    }
                }
                return Unauthorized();
            }
            return BadRequest(ModelState);
        }
    }
}
