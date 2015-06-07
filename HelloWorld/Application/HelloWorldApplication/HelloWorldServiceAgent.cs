using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class HelloWorldServiceAgent
    {
        public virtual async Task<string> GetMessageAsync()
        {
            var httpClient = new HttpClient();
            var uri = "http://localhost:9000/api/message";
            var response = await httpClient.GetAsync(uri);
            var content = await response.Content.ReadAsAsync<dynamic>();
            string message = content.Message;
            return message;
        }
    }
}
