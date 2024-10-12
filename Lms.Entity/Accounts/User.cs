using Lms.Entity.Commons;

namespace Lms.Entity.Accounts
{
    public class User : BaseEntity
    {

        public User() => UserRoles = [];
        public string Email { get; set; }
        public string PassworHash { get; set; }
        public string PasswordSalt { get; set; }
        public UserDetail? UserDetail { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UploadedFile> UploadedFiles { get; set; }

    }
}
