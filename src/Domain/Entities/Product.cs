using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS.Store.Domain.Entities;
public class Product : BaseAuditableEntity<long>
{
    public string? SKU { get; set; }
    public string? Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public string? CoverImageUrl { get; set; }

    public string? Image1Url { get; set; }
    public string? Image2Url { get; set; }
    public string? Image3Url { get; set; }
    public string? Image4Url { get; set; }


    public int CategoryId { get; set; }
    public Category Category { get; set; } = new Category();

    public long ProductInventoryId { get; set; }
    public ProductInventory ProductInventory { get; set; } = new ProductInventory();


    public static Product ProductBuilder(string? sku, string? name, string description, decimal price, int categoryId, int stock)
    {
        return new Product
        {
            SKU = sku,
            Name = name,
            Description = description,
            Price = price,
            CategoryId = categoryId,
            ProductInventory = new ProductInventory
            {
                Stock = stock
            }
        };
    }
}
