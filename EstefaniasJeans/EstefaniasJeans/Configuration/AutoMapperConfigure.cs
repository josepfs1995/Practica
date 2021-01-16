using AutoMapper;
using EstefaniasJeans.Application.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace EstefaniasJeans.Configuration
{
  public static class AutoMapperConfigure
  {
    public static void AddAutoMapperConfigure(this IServiceCollection services)
    {
      services.AddAutoMapper(typeof(DataToViewModelMapper), typeof(DataToViewModelMapper));
    }
  }
}
