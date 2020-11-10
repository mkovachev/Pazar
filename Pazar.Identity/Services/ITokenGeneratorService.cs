using Pazar.Identity.Data.Models;
using System.Collections.Generic;

namespace Pazar.Identity.Services
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(User user, IEnumerable<string> roles = null);
    }
}
