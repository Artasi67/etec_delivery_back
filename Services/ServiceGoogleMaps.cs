using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace etec_delivery_back.Services
{
    public interface IServiceGoogleMaps
    {
        Task<(Double? Lat, Double? Lng)> PegarCoordenadasDoEnderecoAsync(string endereco);
    }

    public class ServiceGoogleMaps : IServiceGoogleMaps
    {        
        private readonly HttpClient _httpClient;
        private readonly string _api_key;

    public ServiceGoogleMaps(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _api_key = config["GoogleMaps:ApiKey"];
        }

    public async Task<(double? Lat, double? Lng)> PegarCoordenadasDoEnderecoAsync(string endereco)
        {
            if (string.IsNullOrEmpty(_api_key))
            {
                throw new InvalidOperationException("A chave de API do Google Maps não foi configurada.");
            }
            var uri_requisicao = $"https://maps.google.com/maps/api/geocode/json?adress={Uri.EscapeDataString(_api_key)}";

            try
            {
                var resposta = await _httpClient.GetAsync(uri_requisicao);
                resposta.EnsureSuccessStatusCode();

                var conteudo = await resposta.Content.ReadAsStringAsync();
                var resposta_geocode = JsonSerializer.Deserialize<GeocodeResponse>(conteudo,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

                if(resposta_geocode?.Status == "OK" && resposta_geocode.Results.Any())
                {
                    var localizacao = resposta_geocode.Results.First().Geometry.Location;
                    return (localizacao.Lat, localizacao.Lng);
                }

                return (null, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao comunicar com a API." + ex.Message);
                return (null, null);
            }
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