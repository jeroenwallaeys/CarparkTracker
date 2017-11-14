using System;
using CarparkTracker.Business.Handlers.Contracts;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Text;

namespace CarparkTracker.Business.Handlers
{
    public class WebRequestHandler : IWebRequestHandler
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

        public TDto GetXmlRequest<TDto>(string url) where TDto : class
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TDto));
                return (TDto)serializer.Deserialize(GetRequest(url));
            }
            catch ( Exception exception )
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private Stream GetRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            return response.GetResponseStream();
        }
    }
}