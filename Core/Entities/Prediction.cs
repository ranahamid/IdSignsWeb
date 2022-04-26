using System;

namespace Core.Entities
{
    /// <summary>
    /// Entity for storing Prediction output from YOLO
    /// </summary>
    public class Prediction : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public Prediction()
        {
            CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Channel <see cref="Channel"/> Id
        /// </summary>
        public int ChannelId { get; set; }

        /// <summary>
        /// Accuracy of Prediction
        /// </summary>
        public decimal Accuracy { get; set; }

        /// <summary>
        /// Created At
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Foreign Key Table
        /// </summary>
        public virtual Channel Channel { get; set; }
    }
}
