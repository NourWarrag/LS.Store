using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LS.Store.Application.Common.Interfaces;
using LS.Store.Domain.Entities;

namespace LS.Store.Application.Orders.Queries;
public class GetOrderByIdQuery: IRequest<OrderDto>
{
    public long Id { get; init; }
}   

public class GetOrderByIdQueryValidator : AbstractValidator<GetOrderByIdQuery>
{
    public GetOrderByIdQueryValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty();
    }
}

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOrderByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FindAsync(request.Id);
        if (order == null)
        {
             throw new NotFoundException(request.Id.ToString(), nameof(Order));
        }
        return _mapper.Map<OrderDto>(order);
    }
}
