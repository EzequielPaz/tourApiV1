using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace tourApiV1.Application.DTOs.Request
{
    public class UpdateTourRequestDTO
    {

        [JsonIgnore] // ← Esto evita que Swagger lo muestre en el body
        public string Id { get; set; } // ← Solo para identificar el tour, no para editar

            public string Name { get; set; }
            public string Description { get; set; }
            public string Destination { get; set; }
            public decimal Price { get; set; }
            public int DurationDays { get; set; }
            public int AvailableSeats { get; set; }
            public DateTime StartTime { get; set; }
        

    }

}

