using LS.Store.Domain.Entities;

namespace LS.Store.Application.Products.Queries;
public class ProductDto
{
    public long Id { get; init; }

    public string? SKU { get; set; }
    public string? Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public int Stock { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductDto>().ForMember(dest=> dest.Stock, opt=> opt.MapFrom(src => src.ProductInventory.Stock));
        }
    }
}
