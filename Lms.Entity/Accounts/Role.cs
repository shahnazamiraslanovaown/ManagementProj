using Lms.Entity.Commons;

namespace Lms.Entity.Accounts
{
    public class Role : EditedBaseEntity
    {

        public Role() => UserRoles = [];
        public string Value { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
