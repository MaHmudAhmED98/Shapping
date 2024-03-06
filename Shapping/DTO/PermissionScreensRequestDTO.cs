namespace Shapping.DTO
{
    public class PermissionScreensRequestDTO
    {
        public string RoleId { get; set; }
        public List<PermissionScreenDTO> PermissionScreens { get; set; }
    }
}
