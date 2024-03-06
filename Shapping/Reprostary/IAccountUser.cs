using Microsoft.AspNetCore.Identity;
using Shapping.Model;

namespace Shapping.Reprostary
{
    public interface IAccountUser
    {
        public Task<IdentityResult> CreateUser(AppUser appUser, string password);
        public Task<AppUser> GetUser(string username);
        public Task<bool> GetPassword(AppUser appUser, string password);

    }
}
