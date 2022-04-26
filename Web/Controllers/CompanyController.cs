using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Web.Extends.Filters;
using Web.ViewModels;

namespace Web.Controllers
{
    /// <summary>
    /// Company Apis
    /// </summary>
    [Authorize]
    public class CompanyController : BaseApiController
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="companyRepository"></param>
        /// <param name="mapper"></param>
        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Returns Company List <see cref="CompanyViewModel"/> List
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get()
        {
            var list = await GetListAsync();
            return Ok(list);
        }
        
        /// <summary>
        /// Get Single Company <see cref="CompanyViewModel"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            CompanyViewModel company;

            if (id == AppConstants.NewId)
            {
                company = new CompanyViewModel();
                return Ok(company);
            }

            if (!_companyRepository.Exists(id))
                return BadRequest(MessageConstants.ItemDoesNotExists);

            var entity = _companyRepository.GetById(id);
            company = _mapper.Map<Company, CompanyViewModel>(entity);

            return Ok(company);
        }

        /// <summary>
        /// Add/Update Company <see cref="Company"/>.
        /// Add if new and update if existing entity.
        /// </summary>
        /// <param name="model">Company ViewModel <see cref="CompanyViewModel"/></param>
        /// <returns></returns>
        [ValidateModel]
        public async Task<IHttpActionResult> Post([FromBody]CompanyViewModel model)
        {
            Company entity;

            // Update if existing
            if (_companyRepository.Exists(model.Id))
            {
                entity = _companyRepository.GetById(model.Id);
                entity.Name = model.Name;
                entity.Address = model.Address;

                await _companyRepository.UpdateAsync(entity);

                return Ok(entity);
            }

            entity = _mapper.Map<CompanyViewModel, Company>(model);
            entity.CreatedBy = UserId;

            await _companyRepository.AddAsync(entity);
            
            return Ok(entity);
        }
        
        /// <summary>
        /// Delete Company
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Delete(int id)
        {
            var entity = _companyRepository.GetById(id);
            await _companyRepository.DeleteAsync(entity);

            var list = await GetListAsync();

            return Ok(list);
        }

        private async Task<List<CompanyViewModel>> GetListAsync()
        {
            var records = await _companyRepository.ListAllAsync();
            var list = _mapper.Map<List<Company>, List<CompanyViewModel>>(records);
            return list;
        }
    }
}
