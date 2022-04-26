using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Web.Extends.Results
{
    /// <summary>
    /// FileActionResult
    /// </summary>
    public class FileActionResult : IHttpActionResult
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        public FileActionResult(DownloadFile file)
        {
            DownloadFile = file;
        }

        /// <summary>
        /// 
        /// </summary>
        public DownloadFile DownloadFile { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(DownloadFile.Content)
            };
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition.FileName = DownloadFile.FileName;

            // NOTE: Here I am just setting the result on the Task and not really doing any async stuff. 
            // But let's say you do stuff like contacting a File hosting service to get the file, then you would do 'async' stuff here.

            return Task.FromResult(response);
        }
    }

    /// <summary>
    /// DownloadFile
    /// </summary>
    public class DownloadFile
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="content"></param>
        public DownloadFile(string name, Stream content)
        {
            Content = content;
            FileName = name;
        }

        /// <summary>
        /// 
        /// </summary>
        public Stream Content { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string FileName { get; private set; }
    }
}