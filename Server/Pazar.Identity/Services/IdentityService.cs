using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pazar.Core.Services;
using Pazar.Core.Services.Identity;
using Pazar.Identity.Data.Models;
using Pazar.Identity.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Pazar.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private const string InvalidErrorMessage = "Invalid credentials";
        private const string InvalidUserId = "Invalid user id";
        private const string AuthenticatedError = "Please login first";

        private readonly UserManager<User> userManager;
        private readonly ITokenGeneratorService jwtTokenGenerator;
        private readonly ILoggedUserService user;
        private readonly IMapper mapper;

        public IdentityService(
            UserManager<User> userManager,
            ITokenGeneratorService jwtTokenGenerator,
            ILoggedUserService user, IMapper mapper)
        {
            this.userManager = userManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.user = user;
            this.mapper = mapper;
        }

        public async Task<UserVm> Details(string id)
        {
            var user = await this.userManager.Users.SingleOrDefaultAsync(u => u.Id == id);

            return this.mapper.Map<UserVm>(user);
        }

        public async Task<Result<User>> Register(UserIm input)
        {
            var user = new User
            {
                Email = input.Email,
                UserName = input.Email
            };

            var result = await this.userManager.CreateAsync(user, input.Password);

            var errors = result.Errors.Select(e => e.Description);

            return result.Succeeded
                ? Result<User>.SuccessWith(user)
                : Result<User>.Failure(errors);
        }

        public async Task<Result<UserAuthVm>> Login(UserIm input)
        {
            var user = await this.userManager.FindByEmailAsync(input.Email);

            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, input.Password);

            if (!passwordValid)
            {
                return InvalidErrorMessage;
            }

            var roles = await this.userManager.GetRolesAsync(user);

            var token = this.jwtTokenGenerator.GenerateToken(user, roles);

            return new UserAuthVm(user.Id, token);
        }

        public async Task<Result> ChangePassword(string id, ChangePasswordIm changePasswordInput)
        {
            var user = await this.userManager.FindByIdAsync(id);

            if (user == null)
            {
                return InvalidUserId;
            }

            var result = await this.userManager.ChangePasswordAsync(
                            user,
                            changePasswordInput.CurrentPassword,
                            changePasswordInput.NewPassword);

            var errors = result.Errors.Select(e => e.Description);

            return result.Succeeded
                ? Result.Success
                : Result.Failure(errors);
        }

        public async Task<Result> Delete(string id)
        {
            var user = await this.userManager.Users.SingleOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return InvalidUserId;
            }

            await this.userManager.DeleteAsync(user);

            return Result.Success;
        }
    }
}
