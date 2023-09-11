using FluentValidation;

namespace ProductService.Application.Product.Commands.Create;

public class CreateCommandValidation : AbstractValidator<CreateCommand>
{
    public CreateCommandValidation()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Category).NotEmpty();
    }
}