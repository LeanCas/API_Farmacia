using FluentValidation;

namespace Farmacia.Application.UseCase.UseCases.Patient.Commands.CreateCommand
{
    public class CreatePatientValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientValidator() 
        {
            RuleFor(X => X.Names)
                .NotNull().WithMessage("El campo Nombres no puede ser nulo")
                .NotEmpty().WithMessage("El campo Nombres no puede ser vacio");

            RuleFor(X => X.LastName)
                .NotNull().WithMessage("El campo Apellido Paterno no puede ser nulo")
                .NotEmpty().WithMessage("El campo Apellido Paterno no puede ser vacio");

            RuleFor(X => X.MotherMaidenName)
                .NotNull().WithMessage("El campo Apellido Materno no puede ser nulo")
                .NotEmpty().WithMessage("El campo Apellido Materno no puede ser vacio");

            RuleFor(X => X.DocumentNumber)
                .NotNull().WithMessage("El campo Documento no puede ser nulo")
                .NotEmpty().WithMessage("El campo Documento no puede ser vacio")
                .Must(BeNumeric!).WithMessage("El campo Documento debe contener solo numeros");

            RuleFor(X => X.Phone)
                .NotNull().WithMessage("El campo Telefono no puede ser nulo")
                .NotEmpty().WithMessage("El campo Telefono no puede ser vacio")
                 .Must(BeNumeric!).WithMessage("El campo Telefono debe contener solo numeros");

        }

        private bool BeNumeric(string input)
        {
            return int.TryParse(input, out _);
        }

    }
}
