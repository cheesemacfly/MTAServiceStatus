using MTAServiceStatus.Models.Api;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using MTAServiceStatus.Extensions;
using AutoMapper;
using MTAServiceStatus.Configs;

namespace MTAServiceStatus.Repositories
{
    public class MTARepository
    {
        private readonly Uri _baseUri;

        /// <summary>
        /// Create a new MTARepository
        /// </summary>
        /// <param name="baseUrl">Url for the service status</param>
        public MTARepository(string baseUrl = "http://web.mta.info/status/serviceStatus.txt")
        {
            _baseUri = new Uri(baseUrl);
            AutoMapperConfig.CreateMaps();
        }

        /// <summary>
        /// Get the current service status from the MTA website. 
        /// This methode returns raw data parsed from the XML feed.
        /// To obtain converted data, call GetServiceAsync()
        /// </summary>
        /// <returns>A RawService object containing the latest updated service status from the MTA</returns>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.InvalidOperationException"/>
        public async Task<RawService> GetRawServiceAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, _baseUri);

            var result = await client.SendAsync(request);

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var document = XDocument.Parse(content);
                var serializer = new XmlSerializer(typeof(RawService));

                var service = serializer.Deserialize<RawService>(document.Root.CreateReader());

                return service;
            }

            throw new HttpRequestException("API unavailable. Please try again later.");
        }

        /// <summary>
        /// Get the current service status from the MTA website. 
        /// </summary>
        /// <returns>A Service object containing the latest updated service status from the MTA</returns>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.InvalidOperationException"/>
        /// <exception cref="AutoMapper.AutoMapperMappingException"/>
        public async Task<Service> GetServiceAsync()
        {
            var rawService = await GetRawServiceAsync();

            return Mapper.Map<Service>(rawService);
        }
    }
}
