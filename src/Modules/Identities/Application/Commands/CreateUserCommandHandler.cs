using Hababk.BuildingBlocks.Application;
using Hababk.Modules.Identities.Domain.Entities;

namespace Hababk.Modules.Identities.Application.Commands;

public class CreateUserCommandHandler(IUserRepository userRepository,IPasswordHash passwordHash) : ICommandHandler<CreateUserCommand, bool>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordHash _passwordHash= passwordHash;
    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Implementation for creating a user goes here.
        request.Password = _passwordHash.HashPassword(request.Password!);
        var user = User.Create(request.Username!,  request.Password! ,request.Email!);
        await _userRepository.AddAsync(user);
        var result = await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return result;
    }
}
