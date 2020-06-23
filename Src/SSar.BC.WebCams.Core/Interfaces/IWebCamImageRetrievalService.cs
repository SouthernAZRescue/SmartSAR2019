using System.Threading.Tasks;
using SSar.BC.WebCams.Core.ValueTypes;

namespace SSar.BC.WebCams.Core.Interfaces
{
    public interface IWebCamImageRetrievalService
    {
        Task<CamImage> GetImageFromUrl(string url);
    }
}