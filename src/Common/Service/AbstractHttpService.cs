using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using XClaim.Common.Helpers;

namespace XClaim.Common.Service;

public abstract class AbstractHttpService : IHttpService {
        private readonly HttpClient _http;

        protected AbstractHttpService(HttpClient http) {
            _http = http;
        }

        public async Task<T> Get<T>(string uri) {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            return await SendRequest<T>(request);
        }

        public async Task Post(string uri, object? value) {
            var request = CreateRequest(HttpMethod.Post, uri, value);
            await SendRequest(request);
        }

        public async Task<T> Post<T>(string uri, object? value) {
            var request = CreateRequest(HttpMethod.Post, uri, value);
            return await SendRequest<T>(request);
        }

        public async Task Put(string uri, object? value) {
            var request = CreateRequest(HttpMethod.Put, uri, value);
            await SendRequest(request);
        }

        public async Task<T> Put<T>(string uri, object? value) {
            var request = CreateRequest(HttpMethod.Put, uri, value);
            return await SendRequest<T>(request);
        }

        public async Task Delete(string uri) {
            var request = CreateRequest(HttpMethod.Delete, uri);
            await SendRequest(request);
        }

        public async Task<T> Delete<T>(string uri) {
            var request = CreateRequest(HttpMethod.Delete, uri);
            return await SendRequest<T>(request);
        }

        private HttpRequestMessage CreateRequest(HttpMethod method, string uri, object? value = null) {
            var request = new HttpRequestMessage(method, uri);
            if (value != null)
                request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return request;
        }

        private async Task SendRequest(HttpRequestMessage request) {
            await AddJwtHeader(request);
            using var response = await _http.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.Unauthorized) {
                await SignOut();
                return;
            }

            await HandleErrors(response);
        }

        private async Task<T> SendRequest<T>(HttpRequestMessage request) {
            await AddJwtHeader(request);
            using var response = await _http.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.Unauthorized) {
                await SignOut();
                return default!;
            }

            await HandleErrors(response);
            var options = new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new StringConverter());
            
            return (await response.Content.ReadFromJsonAsync<T>(options))!;
        }

        protected abstract Task AddJwtHeader(HttpRequestMessage request);
        
        protected abstract Task SignOut();

        private async Task HandleErrors(HttpResponseMessage response) {
            if (!response.IsSuccessStatusCode) {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                if(error != null) throw new Exception(error["message"]);
            }
        }
}
