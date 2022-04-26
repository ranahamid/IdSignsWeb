using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    /// <summary>
    /// External login with AccessToken
    /// </summary>
    public class AddExternalLoginTokenBindingModel
    {
        /// <summary>
        /// ExternalAccessToken
        /// </summary>
        public string ExternalAccessToken { get; set; }
    }

    /// <summary>
    /// External login with AuthorizationCode
    /// </summary>
    public class AddExternalLoginCodeBindingModel
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }
    }

    /// <summary>
    /// AddExternalLoginModel
    /// </summary>
    public class AddExternalLoginModel
    {
        /// <summary>
        /// LoginProvider
        /// </summary>
        public string LoginProvider { get; set; }

        /// <summary>
        /// ProviderKey
        /// </summary>
        public string ProviderKey { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
    }

    /// <summary>
    /// ChangePasswordBindingModel
    /// </summary>
    public class ChangePasswordBindingModel
    {
        /// <summary>
        /// OldPassword
        /// </summary>
        public string OldPassword { get; set; }

        /// <summary>
        /// NewPassword
        /// </summary>
        public string NewPassword { get; set; }

        /// <summary>
        /// ConfirmPassword
        /// </summary>
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// RegisterBindingModel
    /// </summary>
    public class RegisterBindingModel
    {
        /// <summary>
        /// Username
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }

    /// <summary>
    /// RegisterExternalBindingModel
    /// </summary>
    public class RegisterExternalBindingModel
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
    }

    /// <summary>
    /// RemoveLoginBindingModel
    /// </summary>
    public class RemoveLoginBindingModel
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

    /// <summary>
    /// SetPasswordBindingModel
    /// </summary>
    public class SetPasswordBindingModel
    {
        /// <summary>
        /// NewPassword
        /// </summary>
        public string NewPassword { get; set; }

        /// <summary>
        /// ConfirmPassword
        /// </summary>
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// ParsedExternalAccessToken
    /// </summary>
    public class ParsedExternalAccessToken
    {
        /// <summary>
        /// user_id
        /// </summary>
        public string user_id { get; set; }

        /// <summary>
        /// app_id
        /// </summary>
        public string app_id { get; set; }
    }

    /// <summary>
    /// ForgotPasswordBindingModel
    /// </summary>
    public class ForgotPasswordBindingModel
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
    }

    /// <summary>
    /// ResetPasswordBindingModel
    /// </summary>
    public class ResetPasswordBindingModel
    {
        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        public string UserId { get; set; }
    }
}