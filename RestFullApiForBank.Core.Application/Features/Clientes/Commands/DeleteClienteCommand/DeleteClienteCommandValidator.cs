using FluentValidation;

namespace RestFullApiForBank.Core.Application.Features.Clientes.Commands.DeleteClienteCommand
{
    public class DeleteClienteCommandValidator : AbstractValidator<DeleteClienteCommand>
    {
        public DeleteClienteCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} no puede ser vacio.");
        }
    }
}
