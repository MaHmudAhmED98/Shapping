using Shapping.DTO;
using Shapping.Model;
using Shapping.Reprostary;

namespace Shapping.Handler
{
    public class ScreenPermissionHandler
    {

            private readonly IScreenPermisssionReprosatary _repository;

            public ScreenPermissionHandler(IScreenPermisssionReprosatary repository)
            {
                _repository = repository;
            }

            public async Task<List<PermissionScreenDTO>> GetPermissions(string roleName)
            {
                if (!await _repository.RoleExists(roleName))
                    throw new ExceptionLogic("Role Not Exist");

                var screens = await _repository.GetAllScreensWithPermissions();
                var permissionScreens = new List<ScreenPermission>();
                var listResponse = new List<PermissionScreenDTO>();

                foreach (var item in screens)
                {
                    var role = item.ScreenPermission?.FirstOrDefault()?.RoleId;

                    if (role == null || role != roleName)
                    {
                        permissionScreens.Add(new ScreenPermission
                        {
                            RoleId = roleName,
                            ScreenId = item.Id
                        });

                        listResponse.Add(new PermissionScreenDTO
                        {
                            ScreenId = item.Id,
                            ScreenName = item.Name
                        });
                    }
                    else
                    {
                        var permissionScreen = item.ScreenPermission.FirstOrDefault(x => x.RoleId == roleName);
                        listResponse.Add(new PermissionScreenDTO
                        {
                            ScreenId = item.Id,
                            ScreenName = item.Name,
                            Get = permissionScreen.Get,
                            Add = permissionScreen.Add,
                            Delete = permissionScreen.Delete,
                            Update = permissionScreen.Update
                        });
                    }
                }

                await _repository.AddScreenPermissions(permissionScreens);
                return listResponse;
            }

            public async Task UpdatePermission(PermissionScreensRequestDTO permission)
            {
                if (!await _repository.RoleExists(permission.RoleId))
                    throw new ExceptionLogic("Role Not Exist");

                var screenPermissions = await _repository.GetScreenPermissions(permission.RoleId);

                if (screenPermissions.Count != permission.PermissionScreens.Count)
                    throw new ExceptionLogic("");

                foreach (var item in screenPermissions)
                {
                    var curr = permission.PermissionScreens.FirstOrDefault(x => x.ScreenId == item.ScreenId);
                    item.Get = curr.Get;
                    item.Add = curr.Add;
                    item.Update = curr.Update;
                    item.Delete = curr.Delete;
                }

                 _repository.Savechanges();
            }

    }
}
