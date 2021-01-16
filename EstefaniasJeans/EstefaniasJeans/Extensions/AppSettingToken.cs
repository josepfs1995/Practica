namespace EstefaniasJeans.Extensions
{
  public class AppSettingToken
  {
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int Expires { get; set; }
    public string Secret { get; set; }
  }
}
