using LS.Store.Application.Common.Interfaces;
using LS.Store.Domain.Entities;
using LS.Store.Domain.Events;

namespace LS.Store.Application.Products.Commands.CreateProduct;

public record CreateProductCommand : IRequest<long>
{ 
    public string? SKU { get; set; }
    public string? Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public int Stock { get; set; }
}

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(v => v.SKU)
            .NotEmpty();

        RuleFor(v => v.Name)
            .NotEmpty()
            .MaximumLength(200);
        RuleFor(v => v.Description)
            .MaximumLength(500);
        RuleFor(v => v.Price)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(v => v.CategoryId)
            .NotEmpty();
        RuleFor(v => v.Stock)
            .NotEmpty()
            .GreaterThan(0);
    }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = Product.ProductBuilder(request.SKU, request.Name, request.Description, request.Price, request.CategoryId, request.Stock);

        entity.AddDomainEvent(new ProductCreatedEvent(entity));

        _context.Products.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
