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

        public async Task<CameraImage> GetImageFromUrl(string url)
        {
            return 
                new CameraImage(
                    await _httpClient
                        .GetByteArrayAsync(
                            url));
        }
    }

    // Reference: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
}
