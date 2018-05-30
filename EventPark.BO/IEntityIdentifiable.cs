using System;
using System.Collections.Generic;
using System.Text;

namespace EventPark.BO
{
    public interface IEntityIdentifiable
    {
        Guid id { get; set; }
    }
}
