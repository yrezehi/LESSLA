using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Enums
{
    public enum UserPermission
    {
        [Display(Name = "Add")]
        Create = 1,
        [Display(Name = "Edit")]
        Edit = 2,
    }
}
