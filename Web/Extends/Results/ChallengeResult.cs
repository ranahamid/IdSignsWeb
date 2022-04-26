using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Web.Extends.Results
{
    /// <summary>
    /// ChallengeResult
    /// </summary>
    public class ChallengeResult : IHttpActionResult
    {
        /// <summary>
        /// ChallengeResult
        /// </summary>
        /// <param name="loginProvider"></param>
        /// <param name="controller"></param>
        public ChallengeResult(string loginProvider, ApiController controller)
        {
            LoginProvider = loginProvider;
            Request = controller.Request;
        }

        /// <summary>
        /// LoginProvider
        /// </summary>
        public string LoginProvider { get; set; }

        /// <summary>
        /// Request
        /// </summary>
        public HttpRequestMessage Request { get; set; }

        /// <summary>
        /// ExecuteAsync
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            Request.GetOwinContext().Authentication.Challenge(LoginProvider);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.RequestMessage = Request;
            return Task.FromResult(response);
        }
    }
}