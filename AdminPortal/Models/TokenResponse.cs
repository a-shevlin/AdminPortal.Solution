namespace AdminPortal.Models
{
  public class TokenResponse
  {
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public string Success { get; set; }
    public string Errors { get; set; }
  }
}