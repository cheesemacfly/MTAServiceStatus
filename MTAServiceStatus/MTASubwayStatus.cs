using AutoMapper;
using MTAServiceStatus.Models;
using MTAServiceStatus.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAServiceStatus
{
    public class MTASubwayStatus
    {
        private readonly string[] SubwayNames = new[] { "1", "2", "3", "A", "C", "E", "B", "D", "F", "M", "G", "J", "Z", "L", "N", "Q", "R", "S", "SIR" };
        private readonly MTARepository _repo;

        /// <summary>
        /// Creates a default MTASubwayStatus object
        /// </summary>
        public MTASubwayStatus()
        {
            _repo = new MTARepository();
        }

        /// <summary>
        /// Creates a MTASubwayStatus object using the repository passed as a parameter
        /// </summary>
        /// <param name="repository">MTARepository object to use</param>
        public MTASubwayStatus(MTARepository repository)
        {
            _repo = repository;
        }

        /// <summary>
        /// Returns each MTA Subway lines and their status. The text of the alert is used to determine the status per line
        /// </summary>
        /// <returns>List of lines and associated status</returns>
        public async Task<List<SubwayLine>> GetLinesAsync()
        {
            var service = await _repo.GetServiceAsync();

            var result = new List<SubwayLine>();
            foreach (var name in SubwayNames)
            {
                var line = service.Subway.OrderBy(s => s.Name).FirstOrDefault(s => s.Name.Contains(name));

                var subwayLine = new SubwayLine 
                { 
                    Name = name, 
                    Status = null == line ? 
                        ServiceStatus.UNKNOWN : line.Text.Contains(string.Format("[{0}]", name)) ? 
                            line.Status : ServiceStatus.GOOD_SERVICE
                };
                
                result.Add(subwayLine);
            }

            return result;
        }

    }
}
