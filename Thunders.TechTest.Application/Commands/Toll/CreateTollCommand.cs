using FluentValidation;
using Thunders.TechTest.Domain.Commands;
using Thunders.TechTest.Domain.Enums;

namespace Thunders.TechTest.Application.Commands.Toll
{

    public class CreateTollCommand : ICommand
    {
        public string Place { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal County { get; set; }
        public ETypeCar TypeCar { get; set; }
    }

    public class CreateTollValidator : AbstractValidator<CreateTollCommand>
    {
        public CreateTollValidator()
        {
            RuleFor(p => p.Place).NotEmpty().WithMessage("Praça invalido!");
            RuleFor(p => p.City).NotEmpty().WithMessage("cidade e Obrigatorio");
            RuleFor(p => p.State).NotEmpty().WithMessage("Estado e Obrigatorio");
            RuleFor(p => p.County).NotEmpty().WithMessage("Valor pago e Obrigatorio");
            RuleFor(p => p.TypeCar).NotEmpty().WithMessage("Tipo de carro e Obrigatorio");
        }
    }


}

