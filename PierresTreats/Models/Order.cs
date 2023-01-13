namespace PierresTreats.Models
{
  public class Order
  {
    public int OrderId { get; set; }
    public int Quantity { get; set; } 
    public int TreatId { get; set; }
    public Treat Treat { get; set; }
    public int UserId { get; set; }
    public ApplicationUser UserName { get; set; }
  }
}