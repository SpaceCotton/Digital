using Abp.Authorization;
using Bug.Authorization.Roles;
using Bug.Authorization.Users;

namespace Bug.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
