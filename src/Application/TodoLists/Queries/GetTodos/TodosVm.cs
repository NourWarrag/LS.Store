using LS.Store.Application.Common.Models;

namespace LS.Store.Application.TodoLists.Queries.GetTodos;
public class TodosVm
{
    public IReadOnlyCollection<LookupDto> PriorityLevels { get; init; } = Array.Empty<LookupDto>();

    public IReadOnlyCollection<TodoListDto> Lists { get; init; } = Array.Empty<TodoListDto>();
}
