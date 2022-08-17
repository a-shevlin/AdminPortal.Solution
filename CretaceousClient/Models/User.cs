using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdminPortal.Models
{
  public class User 
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    private string Token { get; set; }
  }

}