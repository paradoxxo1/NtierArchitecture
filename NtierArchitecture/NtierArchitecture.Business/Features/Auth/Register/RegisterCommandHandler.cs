using MediatR;
using Microsoft.AspNetCore.Identity;
using NtierArchitecture.Business.Features.Auth.Register;
using NtierArchitecture.Entities.Models;

internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var checkUserameExists = await _userManager.FindByNameAsync(request.UserName);
        if(checkUserameExists is not null) 
        {
            throw new ArgumentException("Bu kullanıcı adı daha önce kullanılmış");
        }

        var checkEmailExists = await _userManager.FindByNameAsync(request.UserName);
        if (checkEmailExists is not null)
        {
            throw new ArgumentException("Bu E-mail daha önce kullanılmış");
        }

        AppUser appUser = new()
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            Name = request.Name,
            Lastname = request.Lastname,
            UserName = request.UserName,
        };

        await _userManager.CreateAsync(appUser, request.Password);

        return Unit.Value;

    }
}
