using MediatR;

namespace NtierArchitecture.Business.Features.Roles.CreateRole
{
    public sealed record CreateRoleCommand (
        string Name) : IRequest<Unit>;
}
