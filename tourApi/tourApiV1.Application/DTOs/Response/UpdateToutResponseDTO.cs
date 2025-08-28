using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace tourApiV1.Application.DTOs.Response
{
    public class UpdateTourResponseDTO
    {
        [JsonIgnore]
        public string Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Destination { get; set; }

        public decimal Price { get; set; }

        public int DurationDays { get; set; }

        public DateTime StartTime { get; set; }

        public int AvailableSeats { get; set; }
    }

}

