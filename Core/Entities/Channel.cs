using Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    /// <summary>
    /// Channel
    /// </summary>
    public class Channel : BaseEntity, IAuditFields
    {
        /// <summary>
        /// 
        /// </summary>
        public Channel()
        {
            CreatedAt = DateTime.Now;
            Predictions = new HashSet<Prediction>();
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Company <see cref="Company"/> Id
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Created At
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Created By
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Foreign Key Company
        /// </summary>
        public virtual Company Company { get; private set; }

        /// <summary>
        /// Reference Key Prediction
        /// </summary>
        public virtual ICollection<Prediction> Predictions { get; set; }
    }
}
