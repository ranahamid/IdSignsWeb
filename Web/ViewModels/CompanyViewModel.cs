using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    /// <summary>
    /// Company <see cref="Company"/> ViewModel
    /// </summary>
    public class CompanyViewModel
    {
        /// <summary>
        /// Id
        /// </summary>        
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required, MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        [Required, MaxLength(500)]
        public string Address { get; set; }
    }
}