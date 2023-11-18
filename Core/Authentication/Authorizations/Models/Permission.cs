using System.ComponentModel.DataAnnotations;

namespace Core.Authentication.Authorizations.Models
{
    public enum Permission
    {
        [Display(GroupName = "Users", Name = "Disable", Description = "Can disables/enables user accounts")]
        DISABLE_USERS,
        [Display(GroupName = "Users", Name = "Invite", Description = "Can send invitation to register new accounts")]
        INVITE_USERS,
        [Display(GroupName = "Users", Name = "Invite", Description = "Can view accounts list")]
        VIEW_USERS,
        [Display(GroupName = "Users", Name = "Invite", Description = "Can manually add new accounts")]
        ADD_USERS,

    }
}
