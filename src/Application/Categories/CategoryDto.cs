using LS.Store.Domain.Entities;

namespace LS.Store.Application.Categories;

public class CategoryDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
