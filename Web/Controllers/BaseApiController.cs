using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Net.Http;
using System.Web.Http;

namespace Web.Controllers
{
    /// <summary>
    /// BaseApiController
    /// </summary>
    public class BaseApiController : ApiController
    {
        private ApplicationUserManager _userManager;
        private string _baseUrl;
        private string _userId;
        private string _userName;

        /// <summary>
        /// UserId
        /// </summary>
        protected string UserId
        {
            get
            {

                return _userId ?? User.Identity.GetUserId();
            }
            set
            {
                _userId = value;
            }
        }

        /// <summary>
        /// UserName
        /// </summary>
        protected string UserName
        {
            get
            {
                return _userName ?? User.Identity.Name;
            }
            set
            {
                _userName = value;
            }
        }

        /// <summary>
        /// BaseUrl
        /// </summary>
        protected string BaseUrl
        {
            get
            {
                return _baseUrl ?? Request.RequestUri.GetLeftPart(UriPartial.Authority);
            }
            private set
            {
                _baseUrl = value;
            }
        }

        /// <summary>
        /// UserManager
        /// </summary>
        protected ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }
    }
}
