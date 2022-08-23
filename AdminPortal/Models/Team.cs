using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdminPortal.Models
{
  public class Team
  {
    public int TeamId { get; set; }
    public string Name { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }

    public static List<Team> GetTeams()
    {
      var apiCallTask = ApiHelper.GetAllTeams();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Team> teamList = JsonConvert.DeserializeObject<List<Team>>(jsonResponse.ToString());

      return teamList;
    }
    public static Team GetDetails(int id)
    {
      var apiCallTask = ApiHelper.GetTeam(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Team team = JsonConvert.DeserializeObject<Team>(jsonResponse.ToString());

      return team;
    }
    public static void Post(Team team)
    {
      string jsonTeam = JsonConvert.SerializeObject(team);
      var apiCallTask = ApiHelper.PostTeam(jsonTeam);
    }
    public static void Put(Team team)
    {
      string jsonTeam = JsonConvert.SerializeObject(team);
      var apiCallTask = ApiHelper.PutTeam(team.TeamId, jsonTeam);
    }
    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.DeleteTeam(id);
    }

    public static AnimalTeam PostAnimalToTeam(int teamId, int animalId)
    {
      var apiCallTask = ApiHelper.PostAnimalToTeam(teamId, animalId);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      AnimalTeam animalTeam = JsonConvert.DeserializeObject<AnimalTeam>(jsonResponse.ToString());

      return animalTeam;
    }
  }
}