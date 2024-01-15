using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS.Store.Domain.Entities;
public class Order: BaseAuditableEntity<long>
{
    public long CustomerId { get; set; }
    public string CustomerName { get; set; } = null!;
    public string CustomerEmail { get; set; } = null!;
    public string? CustomerPhone { get; set; }
    public string? ShippingAddress { get; set; }
    public string? CustomerCity { get; set; }
    public string? CustomerState { get; set; }
    public string? CustomerCountry { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public decimal Total { get; set; }
    public decimal Vat { get; set; }
    public decimal Discount { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; } = null!;

}
