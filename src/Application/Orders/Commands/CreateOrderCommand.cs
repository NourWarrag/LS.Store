using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LS.Store.Application.Common.Interfaces;
using LS.Store.Domain.Entities;

namespace LS.Store.Application.Orders.Commands;
public class CreateOrderCommand: IRequest<OrderDto>
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
    public ICollection<OrderItemDto> OrderItems { get; set; } = null!;
}

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(v => v.CustomerId)
            .NotEmpty();
        RuleFor(v => v.CustomerName)
            .NotEmpty();
        RuleFor(v => v.CustomerEmail)
            .NotEmpty();
        RuleFor(v => v.OrderDate)
            .NotEmpty();
        RuleFor(v => v.Total)
            .NotEmpty();
        RuleFor(v => v.Vat)
            .NotEmpty();
        RuleFor(v => v.Discount)
            .NotEmpty();
        RuleFor(v => v.OrderItems)
            .NotEmpty();
    }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            CustomerId = request.CustomerId,
            CustomerName = request.CustomerName,
            CustomerEmail = request.CustomerEmail,
            CustomerPhone = request.CustomerPhone,
            ShippingAddress = request.ShippingAddress,
            CustomerCity = request.CustomerCity,
            CustomerState = request.CustomerState,
            CustomerCountry = request.CustomerCountry,
            OrderDate = request.OrderDate,
            ShippedDate = request.ShippedDate,
            Total = request.Total,
            Vat = request.Vat,
            Discount = request.Discount,
            OrderItems = _mapper.Map<ICollection<OrderItem>>(request.OrderItems)
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<OrderDto>(order);
    }
}   
