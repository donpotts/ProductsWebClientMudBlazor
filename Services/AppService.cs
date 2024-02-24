using ProductsWebClientMudBlazor.Authentication;
using ProductsWebClientMudBlazor.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net;
using System.Net.Http.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductsWebClientMudBlazor.Services;

public class AppService
{
    private readonly HttpClient httpClient;
    private readonly JwtAuthenticationStateProvider authenticationStateProvider;

    public AppService(
        HttpClient httpClient,
        AuthenticationStateProvider authenticationStateProvider)
    {
        this.httpClient = httpClient;
        this.authenticationStateProvider
            = authenticationStateProvider as JwtAuthenticationStateProvider
                ?? throw new InvalidOperationException();
    }

    private static async Task HandleResponseErrorsAsync(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode
            && response.StatusCode != HttpStatusCode.Unauthorized
            && response.StatusCode != HttpStatusCode.NotFound)
        {
            string? message = await response.Content.ReadFromJsonAsync<string>();
            throw new Exception(message);
        }

        response.EnsureSuccessStatusCode();
    }

    public async Task RegisterUserAsync(UserModel registerModel)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Post, "/api/Users");
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(registerModel);

        HttpResponseMessage response = await httpClient.SendAsync(request);// ("/api/Users", registerModel);

        await HandleResponseErrorsAsync(response);
    }

    public async Task<UserModel[]?> ListUsersAsync()
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Get, "/api/users");
        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<UserModel[]>();
    }

    public async Task<UserModel?> GetUserByIdAsync(long id)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Get, $"/api/users/{id}");
        request.Headers.Add("Authorization", $"Bearer {token}");
        
        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<UserModel>();
    }

    public async Task UpdateUserAsync(long id, UserModel data)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Put, $"/api/users/{id}");
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(data);

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);
    }

    public async Task DeleteUserAsync(long id)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Delete, $"/api/users/{id}");
        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);
    }
    
    public async Task<Products[]?> ListProductsAsync()
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Get, "/api/products");
        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<Products[]>();
    }

    public async Task<Products?> GetProductsByIdAsync(long id)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Get, $"/api/products/{id}");
        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<Products>();
    }

    public async Task UpdateProductsAsync(long id, Products data)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Put, $"/api/products/{id}");
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(data);

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);
    }

    public async Task<Products?> InsertProductsAsync(Products data)
    {
        data.Id = 0;
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Post, "/api/products");
        request.Headers.Add("Authorization", $"Bearer {token}");
        request.Content = JsonContent.Create(data);

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);

        return await response.Content.ReadFromJsonAsync<Products>();
    }

    public async Task DeleteProductsAsync(long id)
    {
        string token = authenticationStateProvider.Token
            ?? throw new Exception("Not authorized");

        HttpRequestMessage request = new(HttpMethod.Delete, $"/api/products/{id}");
        request.Headers.Add("Authorization", $"Bearer {token}");

        HttpResponseMessage response = await httpClient.SendAsync(request);

        await HandleResponseErrorsAsync(response);
    }
}
