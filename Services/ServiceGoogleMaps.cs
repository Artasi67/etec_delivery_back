using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace etec_delivery_back.Services
{
    public interface IServiceGoogleMaps
    {
        Task<(Double? Lat, Double? Lng)> PegarCoordenadasDoEnderecoAsync(string endereco);
    }
    public class ServiceGoogleMaps : IServiceGoogleMaps
    {
        public Task<(double? Lat, double? Lng)> PegarCoordenadasDoEnderecoAsync(string endereco)
        {
            throw new NotImplementedException();
        }
    }

    public class GeocodeResponse
    {
        public Result[] Results { get; set; } = Array.Empty<Result>();
        public string Status { get; set; } = string.Empty;
    }

    public class Result
    {
        public Geometry Geometry { get; set; } = new();
    }

    public class Geometry
    {
        public Location Location { get; set; } = new();
    }

    public class Location
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }