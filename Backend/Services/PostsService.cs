using Backend.DTOs;
using System.Text.Json;

namespace Backend.Services
{
    public class PostsService : IPostsService
    {
        private HttpClient _httpClient;
        public PostsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<PostDto>> Get()
        {
            // Get the URL from the base address
            string url = _httpClient.BaseAddress.ToString();

            // Make the HTTP request
            var result = await _httpClient.GetAsync(url);

            // Ensure the response is successful
            result.EnsureSuccessStatusCode();

            // Read the response content as a string
            var body = await result.Content.ReadAsStringAsync();

            // Log the response content (for debugging purposes)
            Console.WriteLine("Response Body: " + body);


            // Check if the response content is JSON
            if (body.StartsWith("<"))
            {
                throw new Exception("The response is not JSON. It appears to be HTML.");
            }

            // Deserialize the JSON response
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var post = JsonSerializer.Deserialize<IEnumerable<PostDto>>(body, options);

            return post;
        }


    }
}
