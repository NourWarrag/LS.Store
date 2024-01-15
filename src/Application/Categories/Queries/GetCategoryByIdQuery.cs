using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LS.Store.Application.Common.Interfaces;
using LS.Store.Domain.Entities;

namespace LS.Store.Application.Categories.Queries;
public class GetCategoryByIdQuery: IRequest<CategoryDto>
{
    public int Id { get; init; }
}

public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdQueryValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty();
    }
}

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoryByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FindAsync(request.Id);

        if (category == null)
        {
            throw new NotFoundException(request.Id.ToString(), nameof(Category));
        }

        return _mapper.Map<CategoryDto>(category);
    }
}
