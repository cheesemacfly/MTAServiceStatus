using MTAServiceStatus.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using MTAServiceStatus.Extensions;

namespace MTAServiceStatus.Repositories
{
    public class MTARepository
    {
        private readonly Uri _baseUri;

        /// <summary>
        /// Create an new MTARepository
        /// </summary>
        /// <param name="baseUrl">Url for the service status</param>
        public MTARepository(string baseUrl = "http://web.mta.info/status/serviceStatus.txt")
        {
            _baseUri = new Uri(baseUrl);
        }

        /// <summary>
        /// Get the status from the MTA website
        /// </summary>
        /// <returns>A Service object containing the least updated service status from the MTA</returns>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.InvalidOperationException"/>
        /// <exception cref="System.InvalidOperationException"/>
        public async Task<Service> GetStatusAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, _baseUri);

            var result = await client.SendAsync(request);

            if(result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var document = XDocument.Parse(content);
                var serializer = new XmlSerializer(typeof(Service));

                var service = serializer.Deserialize<Service>(document.Root.CreateReader());

                return service;
            }

            return null;
        }
    }
}
