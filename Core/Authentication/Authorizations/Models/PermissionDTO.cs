
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Core.Authentication.Authorizations.Models
{
    public class PermissionDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        private PermissionDTO(string name, string description) =>
            (Name, Description) = (name, description);

        public static PermissionDTO ToDTO(string enumKey)
        {
            var permissionMembers = typeof(Permission).GetMember(enumKey);

            if(permissionMembers.Length == 0)
            {
                throw new ArgumentException("Enum key is corrupted!");
            }

            var permissionMember = permissionMembers[0];

            if (permissionMembers.Length == 0)
            {
                throw new ArgumentException("Enum entity is missing display attribute!");
            }

            var displayAttribute = permissionMember.GetCustomAttributes<DisplayAttribute>().SingleOrDefault();

            if(displayAttribute == null || displayAttribute.Name == null || displayAttribute.Description == null)
            {
                throw new ArgumentException("Corrupted display attribute or missing name or description!");
            }

            return new PermissionDTO(displayAttribute.Name, displayAttribute.Description);
        }
    }
}
