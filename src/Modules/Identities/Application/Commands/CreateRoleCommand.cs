using Hababk.BuildingBlocks.Application;

namespace Hababk.Modules.Identities.Application.Commands;

public class CreateRoleCommand : ICommand<bool>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}