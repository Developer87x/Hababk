using Hababk.BuildingBlocks.Application;

namespace Hababk.Modules.Stores.Application.Commands;

public class CreateStoreCommand : ICommand<bool>
{
    public string? StoreName { get; set; }
    public string? UserId { get; set; }
}