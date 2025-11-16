using Hababk.BuildingBlocks.Application;
using Hababk.Modules.Identities.Domain.Entities;

namespace Hababk.Modules.Identities.Application.Commands;

public class CreateRoleCommandHandler(IRoleRepository roleRepository) : ICommandHandler<CreateRoleCommand, bool>
{
    private readonly IRoleRepository _roleRepository = roleRepository;

    public async Task<bool> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = Role.Create(request.Name!);
        await _roleRepository.AddAsync(role);
        var result = await _roleRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return result;
    }
}