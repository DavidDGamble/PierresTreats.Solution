using System.ComponentModel.DataAnnotations;

namespace PierresTreats.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    [Required(ErrorMessage = "Flavor name cannot be empty!")]
    public string Name { get; set; }
    public List<TreatFlavor> JoinEntities { get; }
  }
}