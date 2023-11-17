using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS.Store.Domain.Entities;
public class ProductInventory: BaseAuditableEntity<long>
{
    public long ProductId { get; set; }
    public int Stock { get; set; }
}
