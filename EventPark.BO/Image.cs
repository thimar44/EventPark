using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPark.BO
{
    public class Image : IEntityIdentifiable
    {
        public Guid id { get; set; }

        public String Url { get; set; }

        public Boolean IsDefault { get; set; }

        public Image()
        {
        }

        public Image(Guid id, string url, bool IsDefault)
        {
            this.id = id;
            Url = url;
            this.IsDefault = IsDefault;
        }
    }
}
