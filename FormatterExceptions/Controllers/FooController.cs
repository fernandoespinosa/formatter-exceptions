using System.Web.Http;

namespace FormatterExceptions.Controllers
{
    public class FooController : ApiController
    {
        [Route("foo/{name}")]
        public Foo Get(string name)
        {
            return new Foo { Name = name };
        }
    }

    public class Foo
    {
        public string Name { get; set; }
    }
}
