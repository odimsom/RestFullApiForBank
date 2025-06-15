using FluentValidation;

namespace RestFullApiForBank.Core.Application.Features.Clientes.Commands.UpdateClienteCommand
{
    public class UpdateClienteCommandValidator : AbstractValidator<UpdateClienteCommand>
    {
        public UpdateClienteCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(c => c.Nombre)
                .NotEmpty()
                .WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(80)
                .WithMessage("{PropertyName} no puede exeder {MaxLength} caracteres.");

            RuleFor(c => c.LastName)
                .NotEmpty()
                .WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(80)
                .WithMessage("{PropertyName} no puede exeder {MaxLength} caracteres.");

            RuleFor(c => c.FechaDeNacimineto)
                .NotEmpty()
                .WithMessage("Fecha de nacimiento no puede ser vacio.");

            RuleFor(c => c.Telefono)
                .NotEmpty()
                .WithMessage("{PropertyName} no puede ser vacio.")
                .Matches("^(?:\\+1[-\\s]?|1[-\\s]?)?(809|829|849)[-\\s]?\\d{3}[-\\s]?\\d{4}$")
                .WithMessage("{PropertyName} deve tener este formato (809|829|849)-000-0000")
                .MaximumLength(12)
                .WithMessage("{PropertyName} no puede exeder {MaxLength} caracteres.");

            RuleFor(c => c.Email)
                .EmailAddress()
                .WithMessage("{PropertyName} Deve ser una Direccion de Email valida")
                .MaximumLength(100)
                .WithMessage("{PropertyName} no puede exeder {MaxLength} caracteres.");

            RuleFor(c => c.Direccion)
                .NotEmpty()
                .WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(120)
                .WithMessage("{PropertyName} no puede exeder {MaxLength} caracteres.");
        }
    }
}
