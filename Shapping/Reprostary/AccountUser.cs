using Microsoft.AspNetCore.Identity;
using Shapping.Model;

namespace Shapping.Reprostary
{
    public class AccountUser : IAccountUser
    {
        private readonly UserManager<AppUser> user;

        public AccountUser(UserManager<AppUser> user)
        {
            this.user = user;
        }
        public async Task <IdentityResult> CreateUser(AppUser appUser, string password)
        {
            return await user.CreateAsync(appUser, password);
        }

        public async Task<bool> GetPassword(AppUser appUser, string password)
        {
            return await user.CheckPasswordAsync(appUser, password);
        }

        public async Task< AppUser> GetUser(string username)
        {
            return await user.FindByNameAsync(username);
        }


    }
}
