using AutoMapper;
using Core.Entities;
using Web.ViewModels;

namespace Web.Mappings
{
    /// <summary>
    /// 
    /// </summary>
    public class DomainToViewModelMappingProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Company, CompanyViewModel>();
        }
    }
}