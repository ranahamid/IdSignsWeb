using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System;

namespace Core.Entities.Identity
{
    /// <summary>
    /// ApplicationUser
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// 
        /// </summary>
        public ApplicationUser()
        {
            CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// CreatedAt
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Company <see cref="Company"/> Id
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Company Company { get; set; }

        #region Methods
        /// <summary>
        /// GenerateUserIdentityAsync
        /// </summary>
        /// <param name="manager">ApplicationUser instance</param>
        /// <param name="authenticationType">Type of authentication</param>
        /// <returns></returns>
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
        #endregion
    }
}
