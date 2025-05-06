namespace MiniMarket.DTOs;

public class OrderDTO
{
    public int Id { get; set; }                 
    public int UserId { get; set; }            
    public DateTime OrderDate { get; set; }  
    public int Quantity { get; set; }    
    public decimal TotalPrice { get; set; }    
    public List<OrderItemDTO> Items { get; set; } = new();
}