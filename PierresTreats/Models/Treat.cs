using System.ComponentModel.DataAnnotations;

namespace PierresTreats.Models 
{
  public class Treat
  {
    public int TreatId { get; set; }
    [Required(ErrorMessage = "Treat name cannot be empty!")]
    public string Name { get; set; }
    public List<TreatFlavor> JoinEntities { get; }
  }
}