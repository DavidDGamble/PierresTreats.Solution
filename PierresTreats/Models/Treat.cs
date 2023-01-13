using System.ComponentModel.DataAnnotations;

namespace PierresTreats.Models 
{
  public class Treat
  {
    public int TreatId { get; set; }
    [Required(ErrorMessage = "Treat name cannot be empty!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Treat needs a price!")]
    public decimal Price { get; set; }
    public List<TreatFlavor> JoinEntities { get; }
    public List<Order> Orders { get; }
  }
}