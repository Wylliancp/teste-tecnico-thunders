using FluentValidation;
using Moq;
using Thunders.TechTest.Application.Commands;
using Thunders.TechTest.Application.Commands.Toll;
using Thunders.TechTest.Application.Handlers.Toll;
using Thunders.TechTest.Domain.Enums;
using Thunders.TechTest.Domain.Repositories;

namespace Thunders.TechTest.Tests.Handlers
{
    public class TollCommandHandlerTests
    {
        private readonly Mock<ITollRepository> _tollRepositoryMock;
        private readonly Mock<IValidator<CreateTollCommand>> _validatorCreateMock;
        private readonly Mock<IValidator<UpdateTollCommand>> _validatorUpdateMock;
        private readonly Mock<IValidator<DeleteTollCommand>> _validatorDeleteMock;
        private readonly TollCommandHandler _handler;

        public TollCommandHandlerTests()
        {
            _tollRepositoryMock = new Mock<ITollRepository>();
            _validatorCreateMock = new Mock<IValidator<CreateTollCommand>>();
            _validatorUpdateMock = new Mock<IValidator<UpdateTollCommand>>();
            _validatorDeleteMock = new Mock<IValidator<DeleteTollCommand>>();

            _handler = new TollCommandHandler(
                _tollRepositoryMock.Object,
                _validatorCreateMock.Object,
                _validatorUpdateMock.Object,
                _validatorDeleteMock.Object
            );
        }

        [Fact]
        public async Task Handle_CreateTollCommand_ShouldReturnSuccess()
        {
            // Arrange
            var command = new CreateTollCommand
            {
                Place = "Place",
                City = "City",
                State = "State",
                County = 33,
                TypeCar = ETypeCar.CARRO
            };

            _validatorCreateMock.Setup(v => v.ValidateAsync(command, default))
                .ReturnsAsync(new FluentValidation.Results.ValidationResult());

            // Act
            var result = (GenericResultCommand)await _handler.Handle(command);

            // Assert
            Assert.True(result.Success);

            _tollRepositoryMock.Verify(r => r.CreateAsync(It.IsAny<Domain.Entities.Toll>(), new CancellationToken()), Times.Once);            
        }
        
        [Fact]
        public async Task Handle_UpdateTollCommand_ShouldReturnSuccess()
        {
            // Arrange
            var command = new UpdateTollCommand
            {
                Id = Guid.NewGuid(),
                Place = "Updated Place",
                City = "Updated City",
                State = "Updated State",
                County = 33,
                TypeCar = ETypeCar.MOTO
            };

            _validatorUpdateMock.Setup(v => v.ValidateAsync(command, default))
                .ReturnsAsync(new FluentValidation.Results.ValidationResult());

            _tollRepositoryMock.Setup(r => r.GetByIdAsync(command.Id, default))
                .ReturnsAsync(new Domain.Entities.Toll("Place", "City", "State", 44, ETypeCar.ONIBUS));

            // Act
            var result = (GenericResultCommand)await _handler.Handle(command);

            // Assert
            Assert.True(result.Success);
            _tollRepositoryMock.Verify(r => r.UpdateAsync(It.IsAny<Domain.Entities.Toll>(), new CancellationToken()), Times.Once);
        }

        [Fact]
        public async Task Handle_DeleteTollCommand_ShouldReturnSuccess()
        {
            // Arrange
            var command = new DeleteTollCommand
            {
                Id = Guid.NewGuid()
            };

            _validatorDeleteMock.Setup(v => v.ValidateAsync(command, default))
                .ReturnsAsync(new FluentValidation.Results.ValidationResult());
            
            _tollRepositoryMock.Setup(r => r.GetByIdAsync(It.IsAny<Guid>(), CancellationToken.None))
                .ReturnsAsync(new Domain.Entities.Toll("Place", "City", "State", 99, ETypeCar.CAMINHAO));


            // Act
            var result = (GenericResultCommand)await _handler.Handle(command);

            // Assert
            Assert.True(result.Success);
            _tollRepositoryMock.Verify(r => r.DeleteAsync(It.IsAny<Guid>(), CancellationToken.None), Times.Once);
        }

    }
}