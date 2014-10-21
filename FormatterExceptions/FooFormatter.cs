using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FormatterExceptions.Controllers;

namespace FormatterExceptions
{
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

        public FooFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/foo"));
        }

        public async override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            var foo = (Foo) value;
            if (foo.Name.Equals("bar", StringComparison.InvariantCultureIgnoreCase))
                throw new Exception(string.Format("NOOO... You can't choose a Foo with name '{0}'!!!", foo.Name));
        }
    }
}