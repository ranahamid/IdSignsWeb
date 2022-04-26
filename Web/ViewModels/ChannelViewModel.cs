using Core.DTOs;
using Core.Entities;
using System.Collections.Generic;

namespace Web.ViewModels
{
    /// <summary>
    /// ChannelViewModel
    /// </summary>
    public class ChannelViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Company <see cref="Company"/> Id
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<SelectOptionModel> Companies { get; set; }
    }
}