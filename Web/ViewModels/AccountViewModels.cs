using System.Collections.Generic;

namespace Web.ViewModels
{
    /// <summary>
    /// ExternalLoginViewModel
    /// </summary>
    public class ExternalLoginViewModel
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }
    }

    /// <summary>
    /// ManageInfoViewModel
    /// </summary>
    public class ManageInfoViewModel
    {
        /// <summary>
        /// LocalLoginProvider
        /// </summary>
        public string LocalLoginProvider { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Logins
        /// </summary>
        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        /// <summary>
        /// ExternalLoginProviders
        /// </summary>
        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }

    /// <summary>
    /// UserInfoViewModel
    /// </summary>
    public class UserInfoViewModel
    {
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// ProfileImageUrl
        /// </summary>
        public string ProfileImageUrl { get; set; }
    }

    /// <summary>
    /// UpdateUserViewModel
    /// </summary>
    public class UpdateUserViewModel
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// ProfilePic
        /// </summary>
        public string ProfilePic { get; set; }

        /// <summary>
        /// ProfilePicS3Url
        /// </summary>
        public string ProfilePicS3Url { get; set; }
    }

    /// <summary>
    /// UserLoginInfoViewModel
    /// </summary>
    public class UserLoginInfoViewModel
    {
        /// <summary>
        /// LoginProvider
        /// </summary>
        public string LoginProvider { get; set; }

        /// <summary>
        /// ProviderKey
        /// </summary>
        public string ProviderKey { get; set; }
    }
}