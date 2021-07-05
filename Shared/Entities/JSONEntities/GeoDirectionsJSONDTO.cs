using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities.JSONEntities
{
    public class Location
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }

    public class Place
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Departure
    {
        [JsonProperty("time")]
        public DateTime Time { get; set; }

        [JsonProperty("place")]
        public Place Place { get; set; }
    }

    public class Arrival
    {
        [JsonProperty("time")]
        public DateTime Time { get; set; }

        [JsonProperty("place")]
        public Place Place { get; set; }
    }

    public class Transport
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("textColor")]
        public string TextColor { get; set; }

        [JsonProperty("headsign")]
        public string Headsign { get; set; }
    }

    public class Agency
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }
    }

    public class Attribution
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Section
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("departure")]
        public Departure Departure { get; set; }

        [JsonProperty("arrival")]
        public Arrival Arrival { get; set; }

        [JsonProperty("transport")]
        public Transport Transport { get; set; }

        [JsonProperty("agency")]
        public Agency Agency { get; set; }

        [JsonProperty("attributions")]
        public List<Attribution> Attributions { get; set; }
    }

    public class Route
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("sections")]
        public List<Section> Sections { get; set; }
    }

    public class GeoDirectionsJSONDTO
    {
        [JsonProperty("routes")]
        public List<Route> Routes { get; set; }
    }
}
