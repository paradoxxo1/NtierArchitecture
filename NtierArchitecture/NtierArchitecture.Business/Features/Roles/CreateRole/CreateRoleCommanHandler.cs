using MediatR;
using NtierArchitecture.Business.Features.Roles.CreateRole;
using NtierArchitecture.Entities.Models;
using NtierArchitecture.Entities.Repositories;

internal sealed class CreateRoleCommanHandler : IRequestHandler<CreateRoleCommand, Unit>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRoleCommanHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var checkRoleIsExists = await _roleRepository.AnyAsync(p=> p.Name == request.Name,cancellationToken);
        if (checkRoleIsExists)
        {
            throw new ArgumentException("Bu rol daha önce oluşturulmuştur");
        }

        AppRole appRole = new()
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };

        await _roleRepository.AddAsync(appRole,cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
