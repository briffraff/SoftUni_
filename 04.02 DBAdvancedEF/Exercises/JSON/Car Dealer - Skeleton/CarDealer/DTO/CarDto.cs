using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Text;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer.DTO
{
    public class CarDto
    {

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        [JsonIgnore]
        public List<int> PartsId { get; set; }

    }
}
