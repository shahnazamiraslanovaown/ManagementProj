using Lms.Entity.Commons;

namespace Lms.Entity.Accounts
{
    public class UserDetail:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StatusId { get; set; }
        public RegisterStatus Status { get; set; }
        public bool IsConfirmPassword { get; set; }
        public int? ConfirmCode { get; set; }
        public string FullName { get => $"{FirstName} {LastName}"; }
        public DateTime? DateOfBirth { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
