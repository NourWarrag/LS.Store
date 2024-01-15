using LS.Store.Domain.Entities;

namespace LS.Store.Application.Orders;

public class OrderItemDto
{
    public long Id { get; init; }
    public long OrderId { get; set; }
    public long ProductId { get; set; }
    public string? ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTimeOffset RentStartDate { get; set; }
    public DateTimeOffset RentEndDate { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
