using LMS.API.DTOs.ResponseDTOs;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using static LMS.Portal.Helper.Constants;

namespace LMS.Portal.Helper
{
    public class HttpClientHelper
    {
        public async Task<HttpResponseMessage> Post(string endpoint, object body, bool isAuthNeeded = false)
        {
            try
            {
                using (var _httpClient = new HttpClient())
                {
                    if (isAuthNeeded)
                        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAuthToken());

                    var response = await _httpClient.PostAsJsonAsync(BASE_URL + endpoint, body);

                    return response;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private async Task<string> GetAuthToken()
        {
            try 
            {
                using (var _httpClient = new HttpClient())
                {
                    HttpResponseMessage responseToken = await _httpClient.PostAsJsonAsync(BASE_URL + APIEndpoints.AUTHENTICATE, user);
                    responseToken.EnsureSuccessStatusCode();
                    var result = responseToken.Content.ReadAsStringAsync().Result;
                    TokenResDTO token = JsonConvert.DeserializeObject<TokenResDTO>(result);

                    return token.Token;
                }
            }
            catch(Exception e) 
            {
                return "";
            }
        }
    }
}
