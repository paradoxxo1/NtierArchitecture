using MediatR;
using NtierArchitecture.Business.Features.UserRoles.SetUserRole;
using NtierArchitecture.Entities.Models;
using NtierArchitecture.Entities.Repositories;

internal sealed class SetUserRoleCommandHandler : IRequestHandler<SetUserRoleCommand, Unit>
{
    private readonly IUserRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SetUserRoleCommandHandler(IUserRoleRepository roleRepository, IUnitOfWork unitOfWork)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(SetUserRoleCommand request, CancellationToken cancellationToken)
    {
        var checkIsRoleSetExists = 
            await _roleRepository
            .AnyAsync(p => p.AppUserId == request.UserId && p.AppRoleId == request.RoleId, cancellationToken);

        if (checkIsRoleSetExists)
        {
            throw new ArgumentException("Kullanıcı bu role zaten sahip");
        }

        UserRole userRole = new()
        {
            AppUserId = request.UserId,
            AppRoleId = request.RoleId,
        };

        await _roleRepository.AddAsync(userRole, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;

    }
}
