using System.Net.Http;
using System.Web.Http;

namespace CacheCowAndBrowser.Controllers
{
    using System.Net.Http.Formatting;

    public class MyResponse
    {
        public string Name { get; set; }

        public string Title { get; set; }
    }

    public class ValuesController : ApiController
    {
        private MyResponse obj;

        public ValuesController()
        {
            this.obj = new MyResponse() { Name = "Test", Title = "Test" };
        }

        public HttpResponseMessage GetDefaultHeaders()
       {
           var response = new HttpResponseMessage()
               {
                   Content = new ObjectContent<MyResponse>(obj, new JsonMediaTypeFormatter())
               };

           return response;
       }

        public HttpResponseMessage GetWithNoCache()
        {
            var response = new HttpResponseMessage()
            {
                Content = new ObjectContent<MyResponse>(obj, new JsonMediaTypeFormatter())
            };

            response.Headers.Add("Cache-Control", "no-cache");

            return response;
        }

        public HttpResponseMessage GetWithPragmaExpires()
        {
            var response = new HttpResponseMessage()
            {
                Content = new ObjectContent<MyResponse>(obj, new JsonMediaTypeFormatter())
            };

            response.Headers.Add("Pragma", "no-cache");
            response.Content.Headers.TryAddWithoutValidation("Expires", "-1");

            return response;
        }
    }
}