using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WeeClaims.Models {
  public class Customer {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CustomerId { get; set; }
    public string Company { get; set; }
    public string ContactName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
  }
}
