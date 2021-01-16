using System;
using System.Security.Claims;

namespace EstefaniasJeans.Extensions
{
  public static class ClaimsExtension
  {
    public static Guid ObtenerId(this ClaimsPrincipal claimsPrincipal)
    {
      var claim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);
      return claim == null ? new Guid() : new Guid(claim.Value);
    }
  }
}