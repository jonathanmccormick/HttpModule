using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ApiModule
{
    class HttpModule
    {
        List<string> _urlList = new List<string>();
        static HttpClient client = new HttpClient();
        int activeRequests = 0;

        public void QueueRequest(string url)
        {
            _urlList.Add(url);
            CheckStatus();
            Console.WriteLine("Request queued");
        }

        private async void CheckStatus()
        {
            if (activeRequests < 2 && _urlList.Count > 0)
            {
                Console.WriteLine("Status checked");
                Console.WriteLine($"In Queue: {_urlList.Count}");


                var url = _urlList.First();
                _urlList.Remove(_urlList[0]);
                await ExecuteRequest(url);
                CheckStatus();
            }
        }

        private async Task<bool> ExecuteRequest(string url)
        {
            ++activeRequests;
            bool boolResult;
            Boolean.TryParse(await client.GetStringAsync(url), out boolResult);
            --activeRequests;
            Console.WriteLine("Request executed");
            return boolResult;
        }
    }
}
