using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPark.BO
{
    public class CoordonneesGPS
    {
        public CoordonneesGPS()
        {

        }

        public CoordonneesGPS(double lat, double lng)
        {
            this.lat = lat;
            this.lng = lng;
        }

        public double lat { get; set; }

        public double lng { get; set; }
    }
}
