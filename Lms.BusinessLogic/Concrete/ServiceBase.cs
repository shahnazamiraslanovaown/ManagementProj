using Lms.BusinessLogic.Abstract;
using Lms.DataAccessLayer.Abstract;

namespace Lms.BusinessLogic.Concrete
{
    public class ServiceBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public ServiceBase(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }



        public async Task SaveChangesAsync()
        {
            await _userRepository.SaveChangesAsync(_userService.GetRegisterUserDto().Id);
        }
    }
}
