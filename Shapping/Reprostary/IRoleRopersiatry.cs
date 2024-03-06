using Microsoft.AspNetCore.Identity;
using Shapping.DTO;

namespace Shapping.Reprostary
{
    public interface IRoleRopersiatry
    {
        Task<IdentityResult> AddRoleAsync(RoleBaseDTO role);
        Task<IdentityResult> EditRoleAsync(UpdateRole role);
        Task<IdentityResult> DeleteRoleAsync(string id);
        Task<List<IdentityRole>> GetallRoll();
    }
}
