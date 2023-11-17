using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS.Store.Domain.Events;
public class ProductCreatedEvent : BaseEvent
{
    public ProductCreatedEvent(Product entity)
    {
        Entity = entity;
    }

    public Product Entity { get; }
}
