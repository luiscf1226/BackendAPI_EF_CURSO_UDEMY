using Backend.DTOs;
using FluentValidation;

namespace Backend.Validators
{
    public class BeerUpdateValidator : AbstractValidator<BeerUpdateDto>
    {
        public BeerUpdateValidator()

        {
            //validacion extra que valide el id
            RuleFor(x => x.Id).NotNull().GreaterThan(0).WithMessage("El id es obligatorio");
            //personalizar el mensaje de error
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio");
            //validar rengo de caracteres
            RuleFor(x => x.Name).Length(2, 20).WithMessage("El nombre debe tener entre 2 y 20 caracteres");
            //validar que el brand id no sea null y que sea mayor a 0
            RuleFor(x => x.BrandID).NotNull().GreaterThan(0).WithMessage("El brand id es obligatorio");
            //validar que alcohol no sea null y que sea mayor a 0
            RuleFor(x => x.Alcohol).NotNull().GreaterThan(0).WithMessage("El {propertyname} es obligatorio");
        }
    }
}
