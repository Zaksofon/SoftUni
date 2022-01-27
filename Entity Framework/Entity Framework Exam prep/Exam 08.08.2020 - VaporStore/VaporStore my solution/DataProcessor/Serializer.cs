using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.Dto.Export;

namespace VaporStore.DataProcessor
{
    using System;
    using Data;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genre = context.Genres
                .ToList()
                .Where(g => genreNames.Contains(g.Name))
                .Select(g => new
                {
                    Id = g.Id,
                    Genre = g.Name,
                    Games = g.Games.Select(x => new
                    {
                        Id = x.Id,
                        Title = x.Name,
                        Developer = x.Developer.Name,
                        Tags = string.Join(", ", x.GameTags.Select(t => t.Tag.Name)),
                        Players = x.Purchases.Count()
                    })
                        .Where(x => x.Players > 0)
                        .OrderByDescending(x => x.Players)
                        .ThenBy(x => x.Id),
                    TotalPlayers = g.Games.Sum(g => g.Purchases.Count())
                })
                .OrderByDescending(g => g.TotalPlayers)
                .ThenBy(g => g.Id)
                .ToList();

            return JsonConvert.SerializeObject(genre, Formatting.Indented);
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var users = context.Users
                .ToList()
                .Where(u => u.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == storeType)))
                .Select(u => new UserPurchaseGameExportDto()
                {
                    Username = u.Username,
                    TotalSpent = u.Cards.Sum(p => p.Purchases
                        .Where(p => p.Type.ToString() == storeType)
                        .Sum(g => g.Game.Price)),
                    Purchases = u.Cards.SelectMany(c => c.Purchases)
                        .Where(p => p.Type.ToString() == storeType)
                        .Select(p => new PurchaseGameExportDto()
                        {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new GameExportDto()
                            {
                                Title = p.Game.Name,
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price
                            }
                        })
                        .OrderBy(u => u.Date)
                        .ToArray()
                })
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username).ToArray();

            return XmlConverter.Serialize(users, "Users");
        }
    }
}