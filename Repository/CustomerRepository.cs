using Microsoft.EntityFrameworkCore;
using WeeClaims.Context;
using WeeClaims.Models;

namespace WeeClaims.Repository {
  public class CustomerRepository : IRepository<Customer> {

    private readonly WeeClaimsContext _context;

    public CustomerRepository(WeeClaimsContext context) {
      _context = context;
    }

    public async Task<IEnumerable<Customer>> Get() => await _context.Customers.ToListAsync();

    public async Task Add(Customer customer) => await _context.Customers.AddAsync(customer);

    public async Task Save() => await _context.SaveChangesAsync();

    public IEnumerable<Customer> Search(Func<Customer, bool> filter) => _context.Customers.Where(filter).ToList();
  }
}
