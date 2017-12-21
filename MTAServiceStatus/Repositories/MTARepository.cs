using AutoMapper;
using MTAServiceStatus.Models;
using MTAServiceStatus.Resolvers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MTAServiceStatus
{
    public sealed class MTARepository
    {
        private readonly Uri _baseUri;
        private readonly IConfigurationProvider _mapperConfiguration;

        /// <summary>
        /// Create a new MTARepository
        /// </summary>
        /// <param name="baseUrl">Url for the service status</param>
        public MTARepository(string baseUrl = "http://web.mta.info/status/serviceStatus.txt")
        {
            _mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<RawService, Service>()
                    .ForMember(dest => dest.TimeStamp, opt => opt.MapFrom(s => DateTime.Parse(s.TimeStamp)));
                config.CreateMap<RawLine, Line>()
                    .ForMember(dest => dest.Status, opt => opt.ResolveUsing<ServiceStatusResolver>())
                    .ForMember(dest => dest.Date, opt => opt.ResolveUsing<LineDateTimeResolver>());
            });

            _baseUri = new Uri(baseUrl);
        }

        /// <summary>
        /// Get the current service status from the MTA website. 
        /// This methode returns raw data parsed from the XML feed.
        /// To obtain converted data, call GetServiceAsync()
        /// </summary>
        /// <returns>A RawService object containing the latest updated service status from the MTA</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"/>
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
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"/>
        /// <exception cref="AutoMapperMappingException"/>
        public async Task<Service> GetServiceAsync()
        {
            var mapper = _mapperConfiguration.CreateMapper();
            var rawService = await GetRawServiceAsync();

            return mapper.Map<Service>(rawService);
        }
    }
}
