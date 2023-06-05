using AutoMapper;
using PlatformService.Models;
using PlatformService.Dtos;

namespace PlatformService.Profiles
{
	public class PlatformsProfile : Profile
	{
		public PlatformsProfile()
		{
			// Source -> Target
			// This automatically creates data relationships between the models and the dtos
			CreateMap<Platform, PlatformReadDto>();
			CreateMap<PlatformCreateDto, Platform>();
		}
	}
}