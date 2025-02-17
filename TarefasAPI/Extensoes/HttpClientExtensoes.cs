using System.Net.Http.Headers;
using System.Text.Json;

namespace TarefasAPI.Extensoes;

public static class HttpClientExtensoes
{
    private static MediaTypeHeaderValue contentType
    = new("application/json");
    public static async Task<T?> ReadContentAs<T>(
        this HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode) throw
                 new ApplicationException(
                     $"Ocorreu um erro ao tentar consultar a API: " +
                     $"{response.ReasonPhrase}");
        var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        return JsonSerializer.Deserialize<T>(dataAsString, options: new() { PropertyNameCaseInsensitive = true });
    }

    public static Task<HttpResponseMessage> PostAsJson<T>(
        this HttpClient httpClient,
        string url,
        T data)
    {
        var dataAsString = JsonSerializer.Serialize(data);
        var content = new StringContent(dataAsString);
        content.Headers.ContentType = contentType;
        return httpClient.PostAsync(url, content);
    }

    public static Task<HttpResponseMessage> PutAsJson<T>(
        this HttpClient httpClient,
        string url,
        T data)
    {
        var dataAsString = JsonSerializer.Serialize(data);
        var content = new StringContent(dataAsString);
        content.Headers.ContentType = contentType;
        return httpClient.PutAsync(url, content);
    }
}
