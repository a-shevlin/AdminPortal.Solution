using Microsoft.AspNetCore.Identity;

namespace AdminPortal.Models
{
  public class ApplicationUser : IdentityUser
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
  }
}