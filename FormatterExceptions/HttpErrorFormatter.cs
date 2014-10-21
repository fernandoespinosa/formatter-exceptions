using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace FormatterExceptions
{
    public class HttpErrorFormatter : MediaTypeFormatter
    {
        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return typeof(HttpError).IsAssignableFrom(type);
        }

        public async override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            var httpError = (HttpError) value;
            using (var writer = new StreamWriter(writeStream))
            {
                await writer.WriteAsync(httpError.InnerException.ToString());
            }
        }

        public HttpErrorFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeWithQualityHeaderValue("application/json", 1));
        }
    }
}