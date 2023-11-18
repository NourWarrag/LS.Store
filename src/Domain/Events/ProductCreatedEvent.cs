using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS.Store.Domain.Events;
public class ProductCreatedEvent(Product entity) : BaseEvent
{
    public Product Entity { get; } = entity;
}
