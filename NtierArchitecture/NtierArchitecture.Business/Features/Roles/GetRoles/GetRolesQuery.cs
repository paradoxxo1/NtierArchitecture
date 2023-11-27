using MediatR;

namespace NtierArchitecture.Business.Features.Roles.GetRoles
{
    public sealed record GetRolesQuery(): IRequest<List<GetRolesQueryResponse>>;
   
}
