using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutomationFramework
{
    public class RestService : ApiService
    {
        public string baseUrl { get; private set; }
        public RestClient Client { get; private set; }
        public RestRequest Request { get; private set; }
        private Method method { get; set; }

        public RestService(string baseUrl, Method method)
        {
            this.baseUrl = baseUrl;
            this.method = method;
        }

        public void AddBody(object body)
        {
            Request.AddJsonBody(body);
        }

        public void AddHeaaders(IDictionary<string, string> headers)
        {
            foreach (var item in headers)
            {
                Request.AddHeader(item.Key, item.Value);
            }
        }

        public override void CreateClient()
        {
            Client = new RestClient(baseUrl);
        }

        public async Task<IRestResponse> ExecuteRequest()
        {
            return await Client.ExecuteAsync(Request, method);
        }

        public override void CreateRequest(string resourse)
        {
            Request = new RestRequest(resourse);
        }
    }
}
