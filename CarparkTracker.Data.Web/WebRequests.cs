using CarparkTracker.Data.Contracts.WebRequests;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace CarparkTracker.Data.Web
{
    public class WebRequests : IWebRequests
    {
        public TDto GetJsonRequest<TDto>(string url) where TDto : class
        {
            try
            {
                var stream = GetRequest(url);

                if ( stream == null )
                    return null;

                string text;
                using ( var reader = new StreamReader(stream, Encoding.ASCII) )
                {
                    text = reader.ReadToEnd();
                }

                return JsonConvert.DeserializeObject<TDto>(text);
            }
            catch ( Exception exception )
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private Stream GetRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            using ( var response = (HttpWebResponse)request.GetResponse() )
            {
                return response.GetResponseStream();
            }       
        }
    }
}
