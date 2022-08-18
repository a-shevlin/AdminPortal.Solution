using System.Threading.Tasks;
using AdminPortal.Models;
using RestSharp;
using AdminPortal.ViewModels;

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
      request.AddJsonBody(newAnimal);
      var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task PutAnimal(int id, string newAnimal)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"animals/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newAnimal);
      var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task DeleteAnimal(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"animals/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
    public static async Task<string> GetAllTeams()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"teams", Method.GET);
      request.AddHeader("Authorization", "Bearer " + TokenC.Token);
      var response = await client.ExecuteTaskAsync(request);
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
  }
}