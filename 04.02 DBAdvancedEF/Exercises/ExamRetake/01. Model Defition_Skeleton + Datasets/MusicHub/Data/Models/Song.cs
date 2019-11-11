using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using MusicHub.Data.Models.Enums;

namespace MusicHub.Data.Models
{
    public class Song
    {

        public Song()
        {
            this.SongPerformers = new HashSet<SongPerformer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3),MaxLength(20)]
        public string Name { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime CreatedOn { get; set; }

        public Genre Genre { get; set; }

        public int? AlbumId { get; set; }
        public Album Album { get; set; }

        public int WriterId { get; set; }
        public Writer Writer { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public ICollection<SongPerformer> SongPerformers { get; set; }

        
       //    •	Id – integer, Primary Key
       //•	Name – text with min length 3 and max length 20 (required)
       //•	Duration – TimeSpan(required)
       //•	CreatedOn – Date(required)
       //•	Genre ¬– Genre enumeration with possible values: "" (required)
       //•	AlbumId– integer foreign key
       //•	Album– the song’s album
       //•	WriterId - integer, foreign key(required)
       //•	Writer – the song’s writer
       //•	Price – decimal (non-negative, minimum value: 0) (required)
       //•	SongPerformers - collection of type SongPerformer

    }
}
