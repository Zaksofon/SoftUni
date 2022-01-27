using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Theatre.Data.Models;
using Theatre.Data.Models.Enums;
using Theatre.DataProcessor.ImportDto;

namespace Theatre.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Theatre.Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var playsXmlAsString =
                XmlConverter.Deserializer<PlayImportDto>(xmlString, "Plays");

            var sb = new StringBuilder();

            foreach (var playXml in playsXmlAsString)
            {
                if (!IsValid(playXml) || playXml.Genre != "Drama"
                                      && playXml.Genre != "Comedy"
                                      && playXml.Genre != "Romance"
                                      && playXml.Genre != "Musical")
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var play = new Play()
                {
                    Title = playXml.Title,
                    Duration = TimeSpan.ParseExact(playXml.Duration, "c", CultureInfo.InvariantCulture),
                    Rating = playXml.Rating,
                    Genre = Enum.Parse<Genre>(playXml.Genre),
                    Description = playXml.Description,
                    Screenwriter = playXml.Screenwriter
                };

                context.Plays.Add(play);
                context.SaveChanges();
                sb.AppendLine(
                    $"Successfully imported {playXml.Title} with genre {playXml.Genre} and a rating of {playXml.Rating}!");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var castsXmlAsString =
                XmlConverter.Deserializer<CastImportDto>(xmlString, "Casts");

            var sb = new StringBuilder();

            foreach (var castXml in castsXmlAsString)
            {
                if (!IsValid(castXml))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var result = castXml.IsMainCharacter == false ? "lesser" : "main";

                var cast = new Cast()
                {
                    FullName = castXml.FullName,
                    IsMainCharacter = castXml.IsMainCharacter,
                    PhoneNumber = castXml.PhoneNumber,
                    PlayId = castXml.PlayId
                };

                context.Casts.Add(cast);
                context.SaveChanges();
                sb.AppendLine(
                    $"Successfully imported actor {castXml.FullName} as a {result} character!");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var theatreJsonAsString = JsonConvert.DeserializeObject<IEnumerable<TheatreImportDto>>(jsonString);

            var sb = new StringBuilder();

            foreach (var theatreJson in theatreJsonAsString)
            {
                if (!IsValid(theatreJson))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var theatre = new Data.Models.Theatre()
                {
                    Name = theatreJson.Name,
                    NumberOfHalls = theatreJson.NumberOfHalls,
                    Director = theatreJson.Director,
                    Tickets = new List<Ticket>()
                };

                context.Theatres.Add(theatre);
                context.SaveChanges();

                foreach (var ticketJson in theatreJson.Tickets)
                {
                    if (!IsValid(ticketJson))
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    var tickets = new Ticket()
                    {
                        Price = ticketJson.Price,
                        RowNumber = ticketJson.RowNumber,
                        PlayId = ticketJson.PlayId,
                        TheatreId = theatre.Id
                    };

                    context.Tickets.Add(tickets);
                    context.SaveChanges();
                }
                sb.AppendLine(
                    $"Successfully imported theatre {theatreJson.Name} with #{theatre.Tickets.Count()} tickets!");
            }

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
