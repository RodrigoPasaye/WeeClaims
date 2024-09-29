using AutoMapper;
using WeeClaims.DTO;
using WeeClaims.Models;
using WeeClaims.Repository;

namespace WeeClaims.Services {
  public class CustomerService : ICommonService<CustomerDto, CustomerInsertDto> {

    private readonly IRepository<Customer> _customerRepository;
    private readonly IMapper _mapper;
    public List<string> Errors { get; }

    public CustomerService(IRepository<Customer> customerRepository, IMapper mapper) {
      _customerRepository = customerRepository;
      _mapper = mapper;
      Errors = new List<string>();
    }

    public async Task<IEnumerable<CustomerDto>> Get() {

      var customers = await _customerRepository.Get();

      return customers.Select(c => _mapper.Map<CustomerDto>(c));
    }

    public async Task<CustomerDto> Add(CustomerInsertDto customerInsertDto) {

      var customer = _mapper.Map<Customer>(customerInsertDto);

      await _customerRepository.Add(customer);
      await _customerRepository.Save();

      var customerDto = _mapper.Map<CustomerDto>(customer);

      return customerDto;
    }

    public bool Validate(CustomerInsertDto customerInsertDto) {

      if (_customerRepository.Search(c => c.Company == customerInsertDto.Company).Count() > 0) {
        Errors.Add("El nombre de la compañia ya existe");
        return false;
      }

      return true;
    }
  }
}
