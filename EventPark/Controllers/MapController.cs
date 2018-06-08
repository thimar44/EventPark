using EventPark.BO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace EventPark.Controllers
{
    public class MapController : Controller
    {

        
        // GET: Map
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoadParking(string latUser, string lngUser, string latEvent, string lngEvent)
        {
            
            string json;
            List<Parking> lstPark = new List<Parking>();
            List<Parking> lstSelectedPark; 
            

            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("http://data.citedia.com/r1/parks?crs=EPSG:4326");
                dynamic jsonApi = JsonConvert.DeserializeObject(json);
                var adressess = jsonApi.features;
                var adresses = adressess.features;
                Dictionary<string, CoordonneesGPS> listCoords = new Dictionary<string, CoordonneesGPS>();
                foreach (var feature in adresses)
                {
                    string id = feature.id;
                    CoordonneesGPS newAdresse = new CoordonneesGPS();
                    var geometry = feature.geometry;
                    Newtonsoft.Json.Linq.JArray coordinate = geometry.coordinates;
                    int indice = 0;

                   foreach (var item in coordinate.Children())
                    {
                        if (indice == 0)
                        {
                            string sdf = (string)item;

                            newAdresse.lat = double.Parse(sdf.Replace(".", ","));
                        } 
                        if (indice == 1)
                        {
                            string sdf = (string)item;
                            newAdresse.lng = double.Parse(sdf.Replace(".", ","));
                        }
                        indice++;
                    }
                    listCoords.Add(id, newAdresse);
                }

                var parks = jsonApi.parks;
                
                foreach (var park in parks)
                {
                    Parking newPark = new Parking();
                    
                    var parkInformations = park.parkInformation;
                    newPark.nom = parkInformations.name;
                    newPark.idAPI = park.id;

                    CoordonneesGPS newParkCoords = listCoords[newPark.idAPI];
                    newPark.nbPlacesLibres = parkInformations.free;

                    newPark.lat = newParkCoords.lat;
                    newPark.lng = newParkCoords.lng;
                    newPark.indiceDistance = calculIndiceDistance(float.Parse(latEvent.Replace(".", ",")), float.Parse(lngEvent.Replace(".", ",")), float.Parse(latUser.Replace(".", ",")), float.Parse(lngUser.Replace(".", ",")), newPark.lat, newPark.lng);
                    
                    if (newPark.nbPlacesLibres > 10)
                    {
                        lstPark.Add(newPark);
                    }
                    
                }

                lstSelectedPark = lstPark.OrderBy(p => p.indiceDistance).Take(3).ToList();


            }
          
            return Content(JsonConvert.SerializeObject(lstSelectedPark), "application/json");
        }


        public float calculIndiceDistance(float latEvent, float lngEvent, float latUser, float lngUser, double latPark, double lngPark)
        {
            double distanceUserPark = DistanceTo(latUser, lngUser, latPark, lngPark);
            double distanceParkEvent = DistanceTo(latPark, lngPark, latEvent, lngEvent);
            return (float)(distanceUserPark + distanceParkEvent);
        }


        public double DistanceTo(double lat1, double lon1, double lat2, double lon2)
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;
            return dist * 1.609344;
        }
    }
}