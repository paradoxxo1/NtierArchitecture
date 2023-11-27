using MediatR;

namespace NtierArchitecture.Business.Features.UserRoles.SetUserRole
{
    public sealed record SetUserRoleCommand(
        Guid UserId,
        Guid RoleId): IRequest<Unit>;

}
