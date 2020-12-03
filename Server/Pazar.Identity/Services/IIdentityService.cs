using Pazar.Core.Services;
using Pazar.Identity.Data.Models;
using Pazar.Identity.Models;
using System.Threading.Tasks;

namespace Pazar.Identity.Services
{
    public interface IIdentityService
    {
        Task<UserVm> Details(string id);
        Task<Result<User>> Register(UserIm input);

        Task<Result<UserAuthVm>> Login(UserIm input);

        Task<Result> ChangePassword(string id, ChangePasswordIm input);

        Task<Result> Delete(string id);

    }
}
