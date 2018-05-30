using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public interface IEntityIdentifiable
    {
        Guid id { get; set; }
    }
}
