using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shapping.Model;

namespace Shapping.Reprostary
{
    public interface IScreenPermisssionReprosatary
    {
        public  Task<bool> RoleExists(string roleName);

        public  Task<List<Screen>> GetAllScreensWithPermissions();

        public  Task<List<ScreenPermission>> GetScreenPermissions(string roleId);

        public  Task AddScreenPermissions(IEnumerable<ScreenPermission> screenPermissions);
        public void Savechanges();

    }
}
