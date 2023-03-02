using Microsoft.AspNetCore.Http;

namespace Application.Helpers.Url
{
    public class UrlManager
    {
        public string CreateUrl(string fileName)
        {
            
            string urlToImg = $"images/{fileName}";

            return urlToImg;
        }
        public string? GetFileName(string url)
        {
            return url.Split("/").LastOrDefault();
        }
    }
}
