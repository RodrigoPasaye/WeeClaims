using FluentValidation;
using WeeClaims.DTO;

namespace WeeClaims.Validators {
  public class CustomerInsertValidator : AbstractValidator<CustomerInsertDto> {
    public CustomerInsertValidator() {
      RuleFor(x => x.Company).Length(2, 100).WithMessage("El nombre de la compañia debe contener de 2 a 100 caracteres");
      RuleFor(x => x.ContactName).Length(2, 100).WithMessage("El nombre del contacto debe contener de 2 a 100 caracteres");
      RuleFor(x => x.Email).EmailAddress().NotEmpty();
      RuleFor(x => x.PhoneNumber).MinimumLength(10).WithMessage("El telefono no puede ser menor a 10 digitos").MaximumLength(10).WithMessage("El telefono no puede ser mayor a 10 digitos");
    }
  }
}
