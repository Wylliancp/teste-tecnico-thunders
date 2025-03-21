using FluentValidation;
using Thunders.TechTest.Application.Commands;
using Thunders.TechTest.Application.Commands.Toll;
using Thunders.TechTest.Domain.Commands;
using Thunders.TechTest.Domain.Enums;
using Thunders.TechTest.Domain.Handlers;
using Thunders.TechTest.Domain.Repositories;

namespace Thunders.TechTest.Application.Handlers.Toll
{

    public class TollCommandHandler(
        ITollRepository tollRepository,
        IValidator<CreateTollCommand> validatorCreate,
        IValidator<UpdateTollCommand> validatorUpdateRoles,
        IValidator<DeleteTollCommand> validatorDelete)
        : ICommandHandler<CreateTollCommand>,
            ICommandHandler<UpdateTollCommand>,
            ICommandHandler<DeleteTollCommand>
    {
        public async Task<ICommandResult> Handle(CreateTollCommand command)
        {

            var result = await validatorCreate.ValidateAsync(command);

            if (result.IsValid)
            {

                if (command is null) return new GenericResultCommand(false, "Dados Invalidos!");

                var toll = new Domain.Entities.Toll(command.Place,  command.City, command.State, command.County, command.TypeCar);

                await tollRepository.CreateAsync(toll);

                return new GenericResultCommand(true, "Criado com Sucesso!");

            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);
        }

        public async Task<ICommandResult> Handle(UpdateTollCommand command)
        {

            var result = await validatorUpdateRoles.ValidateAsync(command);

            if (result.IsValid)
            {

                var toll = await tollRepository.GetByIdAsync(Guid.Empty);

                toll?.Update(command.Place,  command.City, command.State, command.County, command.TypeCar);

                await tollRepository.UpdateAsync(toll);

                return new GenericResultCommand(true, "Atualizado com Sucesso!");
            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);
        }

        public async Task<ICommandResult> Handle(DeleteTollCommand command)
        {

            var result = await validatorDelete.ValidateAsync(command);

            if (result.IsValid)
            {

                await tollRepository.DeleteAsync(command.Id);

                return new GenericResultCommand(true, "Deletado com Sucesso!");
            }

            return new GenericResultCommand(false, "Dados Invalidos!", result.Errors);
        }

    }
}