﻿using Pazar.Core.Common;
using Pazar.Identity.Data.Models;
using Pazar.Identity.Models;
using System.Threading.Tasks;

namespace Pazar.Identity.Services
{
    public interface IIdentityService
    {
        Task<Result<User>> Register(UserIm userInput);

        Task<Result<UserOm>> Login(UserIm userInput);

        Task<Result> ChangePassword(string userId, ChangePasswordIm changePasswordInput);

        Task<Result> DeleteUserAsync(string userId);
    }
}
