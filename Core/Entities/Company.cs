using Core.Entities.Identity;
using Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    /// <summary>
    /// Company
    /// </summary>
    public class Company : BaseEntity, IAuditFields
    {
        /// <summary>
        /// 
        /// </summary>
        public Company()
        {
            CreatedAt = DateTime.Now;
            Channels = new HashSet<Channel>();
            Users = new HashSet<ApplicationUser>();
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Created At
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Crated By
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<Channel> Channels { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<ApplicationUser> Users {get; set;}
    }
}
