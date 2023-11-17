using LS.Store.Domain.Entities;

namespace LS.Store.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Category> Categories { get; }

    DbSet<Product> Products { get; }

    DbSet<ProductInventory> ProductInventories { get; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
