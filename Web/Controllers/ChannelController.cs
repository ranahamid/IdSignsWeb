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
    /// Channel Apis
    /// </summary>

    [Authorize]
    public class ChannelController : BaseApiController
    {
        private readonly IChannelRepository _channelRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelRepository"></param>
        /// <param name="mapper"></param>
        public ChannelController(IChannelRepository channelRepository, IMapper mapper)
        {
            _channelRepository = channelRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns Channel List <see cref="ChannelViewModel"/> List
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get()
        {
            var list = await GetListAsync();
            return Ok(list);
        }

        /// <summary>
        /// Get Single Channel <see cref="ChannelViewModel"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            ChannelViewModel channel;

            if (id == AppConstants.NewId)
            {
                channel = new ChannelViewModel();
                return Ok(channel);
            }

            if (!_channelRepository.Exists(id))
                return BadRequest(MessageConstants.ItemDoesNotExists);

            var entity = _channelRepository.GetById(id);
            channel = _mapper.Map<Channel, ChannelViewModel>(entity);

            return Ok(channel);
        }

        /// <summary>
        /// Add/Update Channel <see cref="Channel"/>.
        /// Add if new and update if existing entity.
        /// </summary>
        /// <param name="model">Channel ViewModel <see cref="ChannelViewModel"/></param>
        /// <returns></returns>
        [ValidateModel]
        public async Task<IHttpActionResult> Post([FromBody]ChannelViewModel model)
        {
            Channel entity;

            // Update if existing
            if (_channelRepository.Exists(model.Id))
            {
                entity = _channelRepository.GetById(model.Id);
                entity.Name = model.Name;
                entity.CompanyId = model.CompanyId;
                
                await _channelRepository.UpdateAsync(entity);

                return Ok(entity);
            }

            entity = _mapper.Map<ChannelViewModel, Channel>(model);
            entity.CreatedBy = UserId;

            await _channelRepository.AddAsync(entity);

            return Ok(entity);
        }

        /// <summary>
        /// Delete Channel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Delete(int id)
        {
            var entity = _channelRepository.GetById(id);
            await _channelRepository.DeleteAsync(entity);

            var list = await GetListAsync();

            return Ok(list);
        }

        private async Task<List<ChannelViewModel>> GetListAsync()
        {
            var records = await _channelRepository.ListAllAsync();
            var list = _mapper.Map<List<Channel>, List<ChannelViewModel>>(records);
            return list;
        }
    }
}