using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportWritersDTO
    {
        //"Name": "Mik Jonathan",
        //"Pseudonym": "The Mik"

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+$")]
        public string Pseudonym { get; set; }
    }
}
