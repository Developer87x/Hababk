using FluentValidation;
using Hababk.BuildingBlocks.Application;
using Hababk.Modules.Stores.Application.Commands;

namespace Hababk.Modules.Stores.Application.Validations
{
    public class CreateStoreCommandValidation :CustomAbstractValidator<CreateStoreCommand>
    {
      public CreateStoreCommandValidation()
        {
            RuleFor(s => s.StoreName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(s => s.UserId).NotEmpty().NotNull();
            
        }   
    }
}