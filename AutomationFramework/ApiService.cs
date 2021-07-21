
using System.Collections.Generic;

namespace AutomationFramework
{
    public abstract class ApiService
    {
        public void BuildRequest(string resourse)
        {
            CreateClient();
            CreateRequest(resourse);
        }
        //public void CreatePostRequest(IDictionary<string, string> headers, object body)
        //{
        //    CreateClient();
        //    CreateRequest();
        //    AddHeaaders(headers);
        //    AddBody(body);
        //}
        public abstract void CreateClient();
        public abstract void CreateRequest(string resourse);
        //public abstract void AddHeaaders(IDictionary<string, string> headers);
        //public abstract void AddBody(object body);
    }
}
