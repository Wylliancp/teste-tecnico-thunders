using FluentValidation;
using Thunders.TechTest.Domain.Commands;

namespace Thunders.TechTest.Application.Commands.Toll;

public class DeleteTollCommand : ICommand
{
    public Guid Id { get; set; }

}

public class DeleteTollValidator : AbstractValidator<DeleteTollCommand>
{
    public DeleteTollValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id e Obrigatorio");
    }
}

