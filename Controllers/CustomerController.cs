using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WeeClaims.DTO;
using WeeClaims.Services;

namespace WeeClaims.Controllers {
  [Route("api/v1/[controller]")]
  [ApiController]
  public class CustomerController : ControllerBase {

    private readonly IValidator<CustomerInsertDto> _customerInsertValidator;
    private readonly ICommonService<CustomerDto, CustomerInsertDto> _customerService;

    public CustomerController(IValidator<CustomerInsertDto> customerInsertValidator, [FromKeyedServices("customerService")] ICommonService<CustomerDto, CustomerInsertDto> customerService) {
      _customerInsertValidator = customerInsertValidator;
      _customerService = customerService;
    }

    [HttpGet]
    public async Task<IEnumerable<CustomerDto>> Get() => await _customerService.Get();


    [HttpPost("Register")]
    public async Task<ActionResult<CustomerInsertDto>> Add(CustomerInsertDto customerInsertDto) {

      var validationResult = await _customerInsertValidator.ValidateAsync(customerInsertDto);

      if (!validationResult.IsValid) {
        return BadRequest(validationResult.Errors);
      }

      // Validaciones de reglas de negocio. Ejemplo:
      // Si no se permite insertar registros con el mismo nombre de la compañia
      // En la prueba como no se indica esta regla, se comenta la validacion

      //if (!_customerService.Validate(customerInsertDto)) {
      //  return BadRequest(_customerService.Errors);
      //}

      var customerDto = await _customerService.Add(customerInsertDto);

      return Ok(customerDto);
    }
  }
}
