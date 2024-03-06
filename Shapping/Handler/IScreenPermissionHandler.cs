using Shapping.DTO;

namespace Shapping.Handler
{
    public interface IScreenPermissionHandler
    {
        Task<List<PermissionScreenDTO>> GetPermissions(string roleName);
        Task UpdatePermission(PermissionScreensRequestDTO permission);
    }
}
