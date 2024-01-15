using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Validators;
using LS.Store.Application.Common.Interfaces;
using LS.Store.Application.Common.Mappings;
using LS.Store.Application.Common.Models;

namespace LS.Store.Application.Orders.Queries;
public class GetOrdersQuery: IRequest<PaginatedList<OrderDto>>
{
    public int? OrderId { get; init; }
    public string? CustomerEmail { get; init; }
    public long? CustomerId { get; set; }
    public string? CustomerName { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
public class GetOrdersQueryValidator : AbstractValidator<GetOrdersQuery>
{
    public GetOrdersQueryValidator()
    {
        RuleFor(v => v.OrderId)
            .Must(x => x == null || x > 0);
        RuleFor(v => v.CustomerEmail).ChildRules(email =>
        {
            email.RuleFor(x => x)
                .Must(x => x == null || x.Length <= 200)
                .WithMessage("Email must be less than 200 characters");
            email.RuleFor(x => x)
                .Must(x => x == null || x.Length >= 5)
                .WithMessage("Email must be more than 5 characters");
            email.RuleFor(x => x)
                .Must(x => x == null || x.Contains("@"))
                .WithMessage("Email must contain @");
        }); 
        RuleFor(v => v.CustomerId)
            .Must(x => x == null || x > 0);
        RuleFor(v => v.CustomerName)
            .Must(x => x == null || x.Length <= 200);
        RuleFor(v => v)
            .NotEmpty();
        RuleFor(v => v.PageSize)
            .NotEmpty();
    }
}

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, PaginatedList<OrderDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOrdersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<PaginatedList<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
       var query = _context.Orders
            .Include(x => x.OrderItems)
            .ThenInclude(x=>x.Product)
            .AsQueryable();

        if (request.OrderId is not null)
        {
            query = query.Where(x => x.Id == request.OrderId);
        }
        if (request.CustomerId is not null)
        {
            query = query.Where(x => x.CustomerId == request.CustomerId);
        }
        if (request.CustomerEmail is not null)
        {
            query = query.Where(x => x.CustomerEmail == request.CustomerEmail);
        }
        if (request.CustomerName is not null)
        {
            query = query.Where(x => x.CustomerName == request.CustomerName);
        }

        return query.OrderBy(x => x.Created)
            .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);  
    }
}

