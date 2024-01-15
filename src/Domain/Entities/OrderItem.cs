using System.Text;

namespace LS.Store.Domain.Entities;

public class OrderItem: BaseAuditableEntity<long>
{
    public long OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public long ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public string? ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTimeOffset RentStartDate { get; set; }
    public DateTimeOffset RentEndDate { get; set; }
    public decimal Discount { get; set; }
    public decimal Total { get; set; }




}
