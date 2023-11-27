using MediatR;

namespace NtierArchitecture.Business.Features.Auth.Login
{
    public sealed record LoginCommand(
        string UserNameOrEmail,
        string Password): IRequest<LoginCommandResponse>;
}
