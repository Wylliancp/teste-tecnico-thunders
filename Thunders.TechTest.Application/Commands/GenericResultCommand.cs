using FluentValidation.Results;
using Thunders.TechTest.Domain.Commands;

namespace Thunders.TechTest.Application.Commands;

public class GenericResultCommand(
    bool success,
    string message,
    List<ValidationFailure> errors = default!,
    object? data = default)
    : ICommandResult

{
    public bool Success { get; private set; } = success;
    public string Message { get; private set; } = message;
    public List<ValidationFailure>? Errors { get; private set; } = errors;
    public object? Data { get; private set; } = data;
}
