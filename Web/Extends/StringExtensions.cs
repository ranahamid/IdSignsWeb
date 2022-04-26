using System.Text;
using System.Web;

namespace Web.Extends
{
    /// <summary>
    /// StringExtensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Base64ForUrlEncode
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64ForUrlEncode(this string str)
        {
            byte[] encbuff = Encoding.UTF8.GetBytes(str);
            return HttpServerUtility.UrlTokenEncode(encbuff);
        }

        /// <summary>
        /// Base64ForUrlDecode
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64ForUrlDecode(this string str)
        {
            byte[] decbuff = HttpServerUtility.UrlTokenDecode(str);
            return Encoding.UTF8.GetString(decbuff);
        }
    }
}