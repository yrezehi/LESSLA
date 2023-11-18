using Core.Authentication.Authorizations.Models;

namespace Core.Authentication.Authorizations
{
    public class Permissions
    {
        public static IEnumerable<PermissionDTO> ForDisplay() =>
            Enum.GetNames(typeof(Permission)).Select(PermissionDTO.ToDTO);
    }
}
