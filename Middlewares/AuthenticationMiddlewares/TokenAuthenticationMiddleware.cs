using Microsoft.AspNetCore.Http;
using Models.DTOs.TokenDTOs;
using Models.Errors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Middlewares.AuthenticationMiddlewares
{
    public class TokenAuthenticationMiddleware(RequestDelegate next, IHttpClientFactory httpClientFactory)
    {
        private readonly RequestDelegate _next = next;
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient();

        public async Task InvokeAsync(HttpContext httpContext)
        {

            var token = ExtractTokenFromHeaders(httpContext);
            var httpResponseMessage = await SendRequestAsync("validate-token", token);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                var isTokensExpirations = await CheckTokensExpirationsAsync(httpContext, httpResponseMessage);
                if (!isTokensExpirations) await ResponseErrorWithStatusCodeAsync(httpContext, httpResponseMessage);
                return;
            }
            await _next(httpContext);
        }

        private async Task<bool> CheckTokensExpirationsAsync(HttpContext httpContext, HttpResponseMessage httpResponseMessage)
        {
            var oldToken = ExtractTokenFromHeaders(httpContext);
            var response = await httpResponseMessage.Content.ReadAsStringAsync(); //Read the error from the request
            var jsonResponse = JObject.Parse(response); //Parse it to json object

            //if the response does not have a type key then this response 
            //contains exception not be error type and must be return false
            if ((string)jsonResponse["type"] == null)
            {
                return false;
            }

            //if response type is a one of the indicated type then send a request to api for generate a new token
            //then extract new token from api response and assign new token to response header for client  
            //if request does not success then responds to client with error
            if (jsonResponse["type"].ToString() == TokenError.AccessTokenExpired.Type)
            {
                var tokenResponse = await SendRequestAsync("generate-access-token", oldToken);
                if (!tokenResponse.IsSuccessStatusCode)
                {
                    await ResponseErrorWithStatusCodeAsync(httpContext, tokenResponse);
                    return true;
                }

                var newToken = await GetNewTokenFromResponseAsync(tokenResponse);
                AssignNewTokenToHeader(httpContext, newToken);
                return true;
            }
            if (jsonResponse["type"].ToString() == TokenError.RefreshTokenExpired.Type)
            {
                var tokenResponse = await SendRequestAsync("generate-refresh-token", oldToken);
                if (!tokenResponse.IsSuccessStatusCode)
                {
                    await ResponseErrorWithStatusCodeAsync(httpContext, tokenResponse);
                    return true;
                }

                var newToken = await GetNewTokenFromResponseAsync(tokenResponse);
                AssignNewTokenToHeader(httpContext, newToken);
                return true;
            }
            return false;
        }

        private static TokenDto ExtractTokenFromHeaders(HttpContext httpContext)
        {
            var accessToken = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var refreshToken = httpContext.Request.Headers["Refresh-Token"].ToString();

            if (accessToken == string.Empty || refreshToken == string.Empty) throw TokenError.MissingToken;
            return new TokenDto(accessToken, refreshToken);
        }

        private static void AssignNewTokenToHeader(HttpContext httpContext, TokenDto tokenDto)
        {
            httpContext.Response.Headers["Authorization"] = "Bearer " + tokenDto.AccessToken;
            httpContext.Response.Headers["Refresh-Token"] = tokenDto.RefreshToken;
        }

        private async Task<HttpResponseMessage> SendRequestAsync(string endpointName, TokenDto oldToken)
        {
            var json = JsonConvert.SerializeObject(oldToken);
            HttpContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var httpResponseMessage = await _httpClient.PostAsync($"http://localhost:5038/api/token/{endpointName}", content) ?? throw ServerError.ServerNotResponding;
            return httpResponseMessage;
        }

        private static async Task<TokenDto> GetNewTokenFromResponseAsync(HttpResponseMessage httpResponseMessage)
        {
            var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
            var newToken = JsonConvert.DeserializeObject<TokenDto>(responseBody) ?? throw TokenError.FailedToGenerateToken;
            return newToken;
        }

        private static async Task ResponseErrorWithStatusCodeAsync(HttpContext httpContext, HttpResponseMessage httpResponseMessage)
        {
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject(content);

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)httpResponseMessage.StatusCode;
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(jsonObject));
        }
    }
}
