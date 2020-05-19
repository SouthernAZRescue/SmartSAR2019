using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SSar.Presentation.BlazorSpaUI.Exceptions;

namespace SSar.Presentation.BlazorSpaUI.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        /// <summary>
        /// The standard HttpRequestException created by EnsureSuccessStatusCode does not
        /// contain enough information for some use cases, so this method inserts additional
        /// data as needed for specific types of request errors, or otherwise returns a
        /// default HttpRequestException.
        /// </summary>
        /// <param name="httpResponse"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> ThrowIfErrorResponse(this HttpResponseMessage httpResponse)
        {
            switch (httpResponse.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                {
                    throw new ServerValidationException(
                        JsonConvert.DeserializeObject<ValidationProblemDetails>(
                                await httpResponse.Content.ReadAsStringAsync())
                            .Errors);
                }

                default:
                    // Handle any other type of error by throwing generic HttpResponseException
                    httpResponse.EnsureSuccessStatusCode();
                    break;
            }

            return httpResponse;
        }
    }
}
