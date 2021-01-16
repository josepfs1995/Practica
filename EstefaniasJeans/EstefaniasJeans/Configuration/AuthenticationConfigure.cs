using System.Text;
using EstefaniasJeans.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace EstefaniasJeans.Configuration{
  public static class AuthenticationConfigure{
    public static void AddAuthenticationConfigure(this IServiceCollection services, IConfiguration configuration){
      var appSettingsSection = configuration.GetSection("Token");
      services.Configure<AppSettingToken>(appSettingsSection);

      var appSettings = appSettingsSection.Get<AppSettingToken>();
      var key = Encoding.ASCII.GetBytes(appSettings.Secret);

      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(x =>
      {
        x.RequireHttpsMetadata = true;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidAudience = appSettings.Audience,
          ValidIssuer = appSettings.Issuer
        };
      });
    }
    public static void UseAuthenticationConfigure(this IApplicationBuilder app){
      app.UseAuthentication();
      app.UseAuthorization();
    }
  }
}