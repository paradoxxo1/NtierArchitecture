using NtierArchitecture.Entities.Models;

namespace NtierArchitecture.Entities.Abstractions
{
    public interface IJwtProvider
    {
        Task<string> CreateTokenAsync(AppUser user);
    }
}
