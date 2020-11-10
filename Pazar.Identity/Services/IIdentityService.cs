using Pazar.Core.Common;
using Pazar.Identity.Data.Models;
using Pazar.Identity.Models;
using System.Threading.Tasks;

namespace Pazar.Identity.Services
{
    public interface IIdentityService
    {
        Task<Result<User>> Register(UserInputModel userInput);

        Task<Result<UserOutputModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(string userId, ChangePasswordInputModel changePasswordInput);

        Task<Result> DeleteUserAsync(string userId);
    }
}
