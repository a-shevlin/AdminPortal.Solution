using System.Threading.Tasks;
using AdminPortal.Models;
using RestSharp;
using AdminPortal.ViewModels;
using Newtonsoft.Json;
using System.Net;

namespace AdminPortal.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAllAnimals()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"animals", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    public static async Task<string> GetAnimal(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"animals/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    public static async Task PostAnimal(string newAnimal)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"animals", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", "Bearer " + TokenC.Token);
      request.AddJsonBody(newAnimal);
      var response = await client.ExecuteTaskAsync(request);
      if (response.StatusCode == HttpStatusCode.Unauthorized)
      {
        if (await RefreshToken())
        {
          await PostAnimal(newAnimal);
        }
        // can put else here if refreshtoken returns fail
      }
    }
    public static async Task PutAnimal(int id, string newAnimal)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"animals/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", "Bearer " + TokenC.Token);
      request.AddJsonBody(newAnimal);
      var response = await client.ExecuteTaskAsync(request);
      if (response.StatusCode == HttpStatusCode.Unauthorized)
      {
        if (await RefreshToken())
        {
          await PutAnimal(id, newAnimal);
        }
        // can put else here if refreshtoken returns fail
      }
    }
    public static async Task DeleteAnimal(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"animals/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", "Bearer " + TokenC.Token);
      request.AddJsonBody(id);
      var response = await client.ExecuteTaskAsync(request);
      if (response.StatusCode == HttpStatusCode.Unauthorized)
      {
        if (await RefreshToken())
        {
          await DeleteAnimal(id);
        }
        // can put else here if refreshtoken returns fail
      }
    }
    public static async Task<string> GetAllTeams()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"teams", Method.GET);
      request.AddHeader("Authorization", "Bearer " + TokenC.Token);
      var response = await client.ExecuteTaskAsync(request);
      if (response.StatusCode == HttpStatusCode.Unauthorized)
      {
        if (await RefreshToken())
        {
          return await GetAllTeams();
        }
        // can put else here if refreshtoken returns fail
      }
      return response.Content;
    }

    public static async Task<string> GetTeam(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"teams/{id}", Method.GET);
      request.AddHeader("Authorization", "Bearer " + TokenC.Token);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
    public static async Task PostTeam(string newAnimal)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"teams", Method.POST);
      request.AddHeader("Authorization", "Bearer " + TokenC.Token);
      request.AddJsonBody(newAnimal);
      var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task PutTeam(int id, string newTeam)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"teams/{id}", Method.PUT);
      request.AddHeader("Authorization", "Bearer " + TokenC.Token);
      request.AddJsonBody(newTeam);
      var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task DeleteTeam(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"teams/{id}", Method.DELETE);
      request.AddHeader("Authorization", "Bearer " + TokenC.Token);
      var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task<string> LogIn(LoginViewModel user)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest("authmanagement/login", Method.POST);
      request.AddJsonBody(user);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    private static async Task<bool> RefreshToken()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest("authmanagement/refreshtoken", Method.POST);
      TokenRequest tr = new TokenRequest(TokenC.Token, TokenC.RefreshToken);
      var serializedTR = JsonConvert.SerializeObject(tr);
      request.AddJsonBody(serializedTR);
      var response = await client.ExecuteTaskAsync(request);
      TokenResponse tResponse = JsonConvert.DeserializeObject<TokenResponse>(response.Content);
      TokenC.Token = tResponse.Token;
      TokenC.RefreshToken = tResponse.RefreshToken;
      return response.IsSuccessful;
    }
  }
}