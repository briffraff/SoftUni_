using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using MusicHub.Data.Models;
using MusicHub.Data.Models.Enums;
using MusicHub.DataProcessor.ImportDtos;
using Newtonsoft.Json;

namespace MusicHub.DataProcessor
{
    using System;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersDTO = JsonConvert.DeserializeObject<ImportWritersDTO[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            var writers = new List<Writer>();

            foreach (var writerDto in writersDTO)
            {
                if (IsValid(writerDto) == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = new Writer
                {
                    Name = writerDto.Name,
                    Pseudonym = writerDto.Pseudonym
                };

                writers.Add(writer);
                sb.AppendFormat(SuccessfullyImportedWriter, writer.Name);
                sb.AppendLine();
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersDTO = JsonConvert.DeserializeObject<ImportProducersDTO[]>(jsonString);


            StringBuilder sb = new StringBuilder();
            var producersAlbums = new List<Producer>();

            foreach (var producerDto in producersDTO)
            {
                var isValidName = (producerDto.Name.Length >= 3 || producerDto.Name.Length <= 30);
                var isValidAlbum = producerDto.Albums.Select(a => IsValid(a) == false);

                if (IsValid(producerDto) == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var albums = new List<Album>();
                var toWrite = true;

                var producer = new Producer()
                {
                    Name = producerDto.Name,
                    Pseudonym = producerDto.Pseudonym,
                    PhoneNumber = producerDto.PhoneNumber
                };

                foreach (var producerDtoAlbum in producerDto.Albums)
                {
                    var albumName = producerDtoAlbum.Name;
                    var releaseDate = producerDtoAlbum.ReleaseDate;

                    if ((producerDtoAlbum.Name.Length > 3 && producerDtoAlbum.Name.Length < 30) == false)
                    {
                        toWrite = false;
                        break;
                    }

                    toWrite = true;
                    var album = new Album()
                    {
                        Name = albumName,
                        ReleaseDate = DateTime.ParseExact(releaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    };

                    albums.Add(album);
                }

                producer.Albums = albums;


                if (producer.PhoneNumber != null)
                {
                    if (toWrite == true)
                    {
                        sb.AppendLine($"Imported {producer.Name} with phone: {producer.PhoneNumber} produces {producer.Albums.Count} albums");
                    }
                    else
                    {
                        sb.AppendLine(ErrorMessage);
                    }
                }
                else
                {
                    if (toWrite == true)
                    {
                        sb.AppendLine($"Imported {producer.Name} with no phone number produces {producer.Albums.Count} albums");
                    }
                    else
                    {
                        sb.AppendLine(ErrorMessage);
                    }
                }

                if (toWrite != false)
                {
                    producersAlbums.Add(producer);
                }
            }

            context.Producers.AddRange(producersAlbums);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongsDTO[]), new XmlRootAttribute("Songs"));
            var songsDTO = (ImportSongsDTO[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var songs = new List<Song>();

            foreach (var songDto in songsDTO)
            {
                var songNameValidation = (songDto.Name.Length > 3 && songDto.Name.Length < 30);
                var songPriceValidation = songDto.Price > 0;
                var songGenreValidation = Enum.TryParse<Genre>(songDto.Genre, out Genre genreType);
                var albumIdExist = songDto.AlbumId != null;
                var writerIdExist = songDto.WriterId != 0;
                var validDto = IsValid(songDto);

                if (!validDto || 
                    !songNameValidation ||
                    !songPriceValidation ||
                    !songGenreValidation ||
                    !albumIdExist ||
                    !writerIdExist
                    )
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = new Song()
                {
                    Name = songDto.Name,
                    Duration = TimeSpan.Parse(songDto.Duration),
                    CreatedOn = DateTime.ParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre = Enum.Parse<Genre>(songDto.Genre),
                    AlbumId = songDto.AlbumId,
                    WriterId = songDto.WriterId,
                    Price = songDto.Price
                };

                songs.Add(song);
                sb.AppendFormat(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration.ToString("c"));
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
            //context.Songs.AddRange(songs);
            //context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);

            return isValid;
        }
    }
}