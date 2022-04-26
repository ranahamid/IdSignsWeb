using Core;
using Core.Entities.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Web.Extends.Filters;
using Web.ViewModels;

namespace Web.Controllers
{
    /// <summary>
    /// AccountController
    /// </summary>
    [Authorize]
    public class AccountController : BaseApiController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AccountController()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessTokenFormat"></param>
        public AccountController(ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            AccessTokenFormat = accessTokenFormat;
        }

        /// <summary>
        /// AccessTokenFormat
        /// </summary>
        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }
        
        /// <summary>
        /// Get User
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get()
        {
            var user = await UserManager.FindByIdAsync(UserId);

            var responseData = new UserInfoViewModel
            {
                Username = UserName,
                Email = user.Email,
                ProfileImageUrl = AppConstants.NoUserImageUrl
            };

            return Ok(responseData);
        }

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ValidateModel]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            var user = new ApplicationUser { UserName = model.Username, Email = model.Email };

            IdentityResult result = await UserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join("<br>", result.Errors);
                return BadRequest(errors);
            }

            // Will be activated again
            //await UserManager.SendEmailAsync(user.Id, BaseResource.ConfirmTitle, GetConfirmEmailBody(user.Id, user.UserName, user.FirstName));

            return Ok();
        }
    }
}
