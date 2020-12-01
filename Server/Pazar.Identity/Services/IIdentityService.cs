using Pazar.Core.Services;
using Pazar.Identity.Data.Models;
using Pazar.Identity.Models;
using System.Threading.Tasks;

namespace Pazar.Identity.Services
{
    public interface IIdentityService
    {
        Task<Result<User>> Register(UserIm userInput);

        Task<Result<UserVm>> Login(UserIm userInput);

        Task<Result> ChangePassword(string userId, ChangePasswordIm changePasswordInput);

        Task<Result> DeleteUser(string userId);

        Task<string> GetId();
    }
}
