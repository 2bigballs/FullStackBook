namespace BookApi.Extension
{
    public static class IFormFileExtension
    {
        public static async Task<string> ConvertToBase64String(this IFormFile file)
        {
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);

            var bytes = stream.ToArray();
            var base64 = Convert.ToBase64String(bytes);

            return base64;
        }
    }
}
