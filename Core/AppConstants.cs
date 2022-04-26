namespace Core
{
    /// <summary>
    /// AppConstants
    /// </summary>
    public class AppConstants
    {
        /// <summary>
        /// Indicates a new entry should be returned;
        /// </summary>
        public const int NewId = -1111;

        /// <summary>
        /// BucketNameStart
        /// </summary>
        public const string BucketNameStart = "geniustms";

        /// <summary>
        /// CorsOriginsSettingKey
        /// </summary>
        public const string CorsOriginsSettingKey = "CorsOriginsSettingKey";

        /// <summary>
        /// NoUserImageUrl
        /// </summary>
        public const string NoUserImageUrl = "../../../images/user.jpg";
    }

    /// <summary>
    /// MessageConstants
    /// </summary>
    public class MessageConstants
    {
        /// <summary>
        /// UnhandledError
        /// </summary>
        public const string UnhandledError = "An unhandled error occured.";

        /// <summary>
        /// UnSupportedMediaType
        /// </summary>
        public const string UnSupportedMediaType = "Unsupported media type.";

        /// <summary>
        /// S3FileDoesNotExists
        /// </summary>
        public const string S3FileDoesNotExists = "File doesn't exists in S3";

        /// <summary>
        /// ItemDoesNotExists
        /// </summary>
        public const string ItemDoesNotExists = "Item does not exists";

        /// <summary>
        /// ProviderBucketDoesNotExists
        /// </summary>
        public const string ProviderBucketDoesNotExists = "Bucket could not be found with your ProviderId and SecurityId.";

        /// <summary>
        /// ProviderBucketExists
        /// </summary>
        public const string ProviderBucketExists = "There is already a bucket for this ProviderId and SecurityId.";
    }
}
