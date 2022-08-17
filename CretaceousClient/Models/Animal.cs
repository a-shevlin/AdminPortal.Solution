using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdminPortal.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    public string Image { get; set; }
    public string Name { get; set; }
    public int HP { get; set; }
    public int Attack { get; set; }

    public static List<Animal> GetAnimals()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Animal> animalList = JsonConvert.DeserializeObject<List<Animal>>(jsonResponse.ToString());

      return animalList;
    }
    public static Animal GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Animal animal = JsonConvert.DeserializeObject<Animal>(jsonResponse.ToString());

      return animal;
    }
    public static void Post(Animal animal)
    {
      string jsonAnimal = JsonConvert.SerializeObject(animal);
      var apiCallTask = ApiHelper.Post(jsonAnimal);
    }
    public static void Put(Animal animal)
    {
      string jsonAnimal = JsonConvert.SerializeObject(animal);
      var apiCallTask = ApiHelper.Put(animal.AnimalId, jsonAnimal);
    }
    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}