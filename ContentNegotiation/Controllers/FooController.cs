using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace ContentNegotiation.Controllers
{
    public class FooController : ApiController
    {
        [Route("{name}")]
        public Foo Get(string name)
        {
            return new Foo {Name = name};
        }
    }

    public class Foo
    {
        public string Name { get; set; }
    }

    public class FooFormatter : MediaTypeFormatter
    {
        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return typeof(Foo).IsAssignableFrom(type);
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
        }

        public FooFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeWithQualityHeaderValue("wala/foo"));
        }

        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            var foo = (Foo) value;
            using (var writer = new StreamWriter(writeStream))
            {
                await writer.WriteAsync(string.Format("This is '{0}' in foo format!", foo.Name));
            }
        }
    }
}
