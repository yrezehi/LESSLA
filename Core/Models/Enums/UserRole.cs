using System.ComponentModel.DataAnnotations;

namespace Core.Models.Enums
{
    public enum UserRole
    {
        [Display(Name = "Super Admin")]
        SuperAdmin = 1,
        [Display(Name = "Admin")]
        Admin = 2,
        [Display(Name = "User")]
        User = 3,
    }
}
