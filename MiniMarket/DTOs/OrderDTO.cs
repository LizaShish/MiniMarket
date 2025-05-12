namespace MiniMarket.DTOs;

public class OrderDTO
{
    public int Id { get; set; }                 
    public string? UserEmail { get; set; }
    public DateTime OrderDate { get; set; }  
    public int Quantity { get; set; }    
    public string Status { get; set; } = "В обработке";
    public List<OrderItemDTO> Items { get; set; } = new();
    public int TotalPrice { get; set; }
}