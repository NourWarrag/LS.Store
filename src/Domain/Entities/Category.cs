using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS.Store.Domain.Entities;
public class Category : BaseAuditableEntity<int>
{
    public string? Name { get; set; }
}

