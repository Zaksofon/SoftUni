using System.Globalization;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Xml;
using Newtonsoft.Json;
using Theatre.Data.Models;
using Theatre.DataProcessor.ExportDto;
using Formatting = Newtonsoft.Json.Formatting;

namespace Theatre.DataProcessor
{
    using System;
    using Theatre.Data;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .ToList()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count() >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                        .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                        .Sum(x => x.Price),
                    Tickets = t.Tickets
                        .Where(t => t.RowNumber >= 1 && t.RowNumber <= 5)
                        .Select(x => new
                        {
                            Price = decimal.Parse(x.Price.ToString("f2")),
                            RowNumber = x.RowNumber
                        })
                        .OrderByDescending(t => t.Price)
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToList();

            return JsonConvert.SerializeObject(theatres, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                .ToArray()
                .Where(p => p.Rating <= rating)
                .Select(p => new PlayExportDto()
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                        .Where(a => a.IsMainCharacter)
                        .Select(a => new ActorExportDto
                        {
                            FullName = a.FullName,
                            MainCharacter = $"Plays main character in '{a.Play.Title}'." 
                        })
                        .OrderByDescending(a => a.FullName)
                        .ToArray()
                })
                .OrderBy(o => o.Title)
                .ThenByDescending(o => o.Genre)
                .ToList();

            return XmlConverter.Serialize(plays, "Plays");
        }
    }
}
