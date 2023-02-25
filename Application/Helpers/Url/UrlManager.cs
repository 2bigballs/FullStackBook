using Microsoft.AspNetCore.Http;

namespace Application.Helpers.Url
{
    public class UrlManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UrlManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string CreateUrl(string fileName)
        {
            var appRequest = _httpContextAccessor.HttpContext.Request;

            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = appRequest.Scheme;
            uriBuilder.Host = appRequest.Host.Host;
            uriBuilder.Port = appRequest.Host.Port.Value;
            uriBuilder.Path = $"/images/{fileName}";

            return uriBuilder.Uri.ToString();
        }
        public string? GetFileName(string url)
        {
            return url.Split("/").LastOrDefault();
        }
    }
}
