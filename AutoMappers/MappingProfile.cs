using AutoMapper;
using WeeClaims.DTO;
using WeeClaims.Models;

namespace WeeClaims.AutoMappers {
  public class MappingProfile : Profile {
    public MappingProfile() {
      CreateMap<CustomerInsertDto, Customer>();
      CreateMap<Customer, CustomerDto>();
    }
  }
}
