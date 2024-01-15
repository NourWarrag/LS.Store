using LS.Store.Domain.Entities;

namespace LS.Store.Application.Orders;

public class OrderDto
{
    public long Id { get; init; }
    public string? CustomerName { get; set; }
    public string? CustomerEmail { get; set; }
    public string? CustomerPhone { get; set; }
    public string? ShippingAddress { get; set; }
    public string? CustomerCity { get; set; }
    public string? CustomerState { get; set; }
    public string? CustomerCountry { get; set; }
    public decimal Total { get; set; }
    public decimal Vat { get; set; }
    public decimal Discount { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Order, OrderDto>();
        }
    }
}
