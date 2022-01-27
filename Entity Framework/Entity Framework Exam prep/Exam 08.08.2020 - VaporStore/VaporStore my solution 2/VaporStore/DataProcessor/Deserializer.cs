using System.Linq;
using System.Text;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.Dto.Import;

namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;

	public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gamesJsonAsString = JsonConvert.DeserializeObject<IEnumerable<GamesImportDto>>(jsonString);

            var sb = new StringBuilder();

            foreach (var gameJson in gamesJsonAsString)
            {
                if (!IsValid(gameJson) || gameJson.Tags.Count() < 1)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var developer = context.Developers.FirstOrDefault(d => d.Name == gameJson.Developer)
                                ?? new Developer { Name = gameJson.Name };

                var genre = context.Genres.FirstOrDefault(g => g.Name == gameJson.Genre)
                            ?? new Genre { Name = gameJson.Name };

                var game = new Game
                {
                    Name = gameJson.Name,
                    Price = gameJson.Price,
                    ReleaseDate = gameJson.ReleaseDate.Value,
                    Developer = developer,
                    Genre = genre
                };

                foreach (var tagJson in gameJson.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(t => t.Name == tagJson)
                              ?? new Tag { Name = tagJson };

                    game.GameTags.Append(new GameTag { Tag = tag }).ToArray();
                }

                context.Games.Add(game);
                context.SaveChanges();
                sb.AppendLine($"Added {gameJson.Name} ({gameJson.Genre}) with {gameJson.Tags.Count()} tags");
            }

            return sb.ToString().TrimEnd();
        }

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var usersJsonAsString = JsonConvert.DeserializeObject<IEnumerable<UsersCardsImportDto>>(jsonString);

            var sb = new StringBuilder();

            foreach (var userJson in usersJsonAsString)
            {
                if (!IsValid(userJson) || !userJson.Cards.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User()
                {
                    Age = userJson.Age,
                    Email = userJson.Email,
                    FullName = userJson.FullName,
                    Username = userJson.Username,
                    Cards = userJson.Cards.Select(c => new Card()
                    {
                        Cvc = c.CVC,
                        Number = c.Number,
                        Type = c.Type.Value,

                    }).ToList()
                };

                context.Users.Add(user);
                sb.AppendLine($"Imported {userJson.Username} with {userJson.Cards.Count()} cards");
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			throw new NotImplementedException();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}