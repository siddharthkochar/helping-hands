using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodPlus.Services.Model;
using RestSharp;

namespace BloodPlus.Services
{
    public class GeoDB
    {
        private const string BaseUrl = "https://wft-geo-db.p.rapidapi.com";
        private const string Host = "wft-geo-db.p.rapidapi.com";
        private const string Key = "b7b2e3246bmsh5d466621aff41dfp13404bjsn795b1143f3a6";
        private readonly RestClient _client;

        public GeoDB()
        {
            _client = new RestClient(BaseUrl);
        }

        public IRestResponse<Region> GetRegions(string countryCode, string next = "")
        {
            var request = string.IsNullOrEmpty(next)
                ? CreateRequest($"/v1/geo/countries/{countryCode}/regions", Method.GET)
                : CreateRequest(next, Method.GET);

            return _client.Execute<Region>(request);
        }

        public async IAsyncEnumerable<Data> GetCities()
        {
            var nextUrl = "/v1/geo/cities?offset=1210&limit=10&countryIds=IN";
            while (nextUrl != null)
            {
                IRestRequest request = CreateRequest(nextUrl, Method.GET);

                await Task.Delay(TimeSpan.FromSeconds(5));
                var regions = await _client.ExecuteGetTaskAsync<Region>(request);

                foreach (var data in regions.Data.Data)
                {
                    yield return data;
                }

                nextUrl = regions.Data.Links.FirstOrDefault(x => x.Rel == "next")?.Href;
            }
        }

        private static IRestRequest CreateRequest(string url, Method method)
        {
            var request = new RestRequest(url, method);
            request.AddHeader("x-rapidapi-host", Host);
            request.AddHeader("x-rapidapi-key", Key);
            return request;
        }
    }

}
