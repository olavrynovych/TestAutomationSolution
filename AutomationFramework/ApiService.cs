
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
        public abstract void CreateClient();
        public abstract void CreateRequest(string resourse);
    }
}
