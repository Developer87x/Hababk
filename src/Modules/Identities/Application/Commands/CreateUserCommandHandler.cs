using Hababk.BuildingBlocks.Application;
using Hababk.Modules.Identities.Domain.Entities;

namespace Hababk.Modules.Identities.Application.Commands;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, bool>
{
    private readonly IUserRepository _userRepository;
    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Implementation for creating a user goes here.
       var user = User.Create(request.Username!, request.Email!, request.Password!);
        await _userRepository.AddAsync(user);
       var result = await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return result;
    }
}