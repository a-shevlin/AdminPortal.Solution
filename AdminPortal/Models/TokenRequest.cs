using System.ComponentModel.DataAnnotations;

namespace AdminPortal.Models
{
  public class TokenRequest
  {
    [Required]
    public string Token { get; set; }
    [Required]
    public string RefreshToken { get; set; }
    public TokenRequest(string token, string refreshtoken)
    {
      Token = token;
      RefreshToken = refreshtoken;
    }
  }
}
