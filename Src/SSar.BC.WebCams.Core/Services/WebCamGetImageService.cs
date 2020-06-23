using System.Net.Http;
using System.Threading.Tasks;
using SSar.BC.WebCams.Core.Interfaces;
using SSar.BC.WebCams.Core.ValueTypes;

namespace SSar.BC.WebCams.Core.Services
{
    public class WebCamImageRetrievalService : IWebCamImageRetrievalService
    {
        private readonly HttpClient _httpClient;
        private readonly string imageUrl;

        public WebCamImageRetrievalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CamImage> GetFromUrl(string url)
        {
            return 
                new CamImage(
                    await _httpClient
                        .GetByteArrayAsync(
                            @"http://remote.sarci.org:19204/snap.jpeg"));
        }
    }

    // Reference: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
}
