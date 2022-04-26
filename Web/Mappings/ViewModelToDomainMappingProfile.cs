using AutoMapper;
using Core.Entities;
using Web.ViewModels;

namespace Web.Mappings
{
    /// <summary>
    /// 
    /// </summary>
    public class ViewModelToDomainMappingProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CompanyViewModel, Company>();
        }
    }
}