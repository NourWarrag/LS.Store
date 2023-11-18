using LS.Store.Application.Common.Interfaces;
using LS.Store.Application.Common.Mappings;
using LS.Store.Application.Common.Models;

namespace LS.Store.Application.Products.Queries.GetProductsWithPagination;
public record GetProductsWithPaginationQuery : IRequest<PaginatedList<ProductDto>>
{
    public int CategoryId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetProductsWithPaginationQueryHandler : IRequestHandler<GetProductsWithPaginationQuery, PaginatedList<ProductDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProductDto>> Handle(GetProductsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products
            .Where(x => x.CategoryId == request.CategoryId)
            .OrderBy(x => x.Created)
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
