using NLog;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.ModelBinding;
using System.Net.Http.Formatting;

namespace Web.Extends.Handlers
{
    /// <summary>
    /// ApiGlobalExceptionHandler
    /// </summary>
    public class ApiGlobalExceptionHandler : ExceptionHandler
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void Handle(ExceptionHandlerContext context)
        {
            ApiError apiError;

            logger.Error(context.Exception);

            if(context.Exception is ApiException)
            {
                var exception = context.Exception as ApiException;
                apiError = new ApiError(exception.Message)
                {
                    Errors = exception.Errors
                };
            }
            else
            {
                #if !DEBUG
                    var msg = "An unhandled error occurred.";                
                    string stack = null;
                #else
                    var msg = context.Exception.GetBaseException().Message;
                    string stack = context.Exception.StackTrace;
                #endif

                apiError = new ApiError(msg)
                {
                    Detail = stack
                };
            }

            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new ObjectContent<ApiError>(apiError, new JsonMediaTypeFormatter())
            };

            context.Result = new ErrorMessageResult(context.Request, response);
        }
    }

    /// <summary>
    /// ErrorMessageResult
    /// </summary>
    public class ErrorMessageResult : IHttpActionResult
    {
        private HttpRequestMessage _request;
        private HttpResponseMessage _httpResponseMessage;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="httpResponseMessage"></param>
        public ErrorMessageResult(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
        {
            _request = request;
            _httpResponseMessage = httpResponseMessage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_httpResponseMessage);
        }
    }

    /// <summary>
    /// ApiException
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string[] Errors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        /// <param name="errors"></param>
        public ApiException(
            string message,
            int statusCode = 500,
            string[] errors = null) :
            base(message)
        {
            StatusCode = statusCode;
            Errors = errors;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="statusCode"></param>
        public ApiException(Exception ex, int statusCode = 500) : base(ex.Message)
        {
            StatusCode = statusCode;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ApiError
    {
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string[] Errors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ApiError(string message)
        {
            Message = message;
            IsError = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelState"></param>
        public ApiError(ModelStateDictionary modelState)
        {
            IsError = true;
            if (modelState != null && modelState.Any(m => m.Value.Errors.Count > 0))
            {
                Message = "Please correct the specified errors and try again.";
                Errors = modelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToArray();
            }
        }
    }
}