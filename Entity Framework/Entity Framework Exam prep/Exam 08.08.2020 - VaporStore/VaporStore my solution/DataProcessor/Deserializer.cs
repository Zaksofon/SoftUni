using System.Globalization;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.Dto;
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

            foreach (var jsonGame in gamesJsonAsString)
            {
                if (!IsValid(jsonGame) || !jsonGame.Tags.Any())
                {
                    sb.AppendLine("Invalid Data");
					continue;
                }

                var developer = context.Developers.FirstOrDefault(d => d.Name == jsonGame.Developer)
                                ?? new Developer() { Name = jsonGame.Developer };

                var genre = context.Genres.FirstOrDefault(g => g.Name == jsonGame.Genre)
                            ?? new Genre() { Name = jsonGame.Genre };

                var game = new Game()
                {
                    Name = jsonGame.Name,
                    Price = jsonGame.Price,
                    ReleaseDate = jsonGame.ReleaseDate.Value,
                    Developer = developer,
                    Genre = genre,
                };

                foreach (var jsonTag in jsonGame.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(t => t.Name == jsonTag)
                              ?? new Tag() { Name = jsonTag };

                    game.GameTags.Add(new GameTag(){Tag = tag});
                }

                context.Games.Add(game);
                context.SaveChanges();
                sb.AppendLine($"Added {jsonGame.Name} ({jsonGame.Genre}) with {jsonGame.Tags.Count()} tags"!);
            }

            return sb.ToString().TrimEnd();
        }

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var usersCardsJsonAsString = 
                JsonConvert.DeserializeObject<IEnumerable<UsersCardsImportDto>>(jsonString);

            var sb = new StringBuilder();

            foreach (var userJson in usersCardsJsonAsString)
            {
                if (!IsValid(userJson) || !userJson.Cards.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var user = new User()
                {
                    FullName = userJson.FullName,
                    Username = userJson.Username,
                    Email = userJson.Email,
                    Age = userJson.Age,
                    Cards = userJson.Cards.Select(c => new Card()
                    {
                        Number = c.Number,
                        Cvc = c.CVC,
                        Type = c.Type.Value
                    }).ToList()
                };

                context.Users.Add(user);
                context.SaveChanges();
                sb.AppendLine($"Imported {userJson.Username} with {userJson.Cards.Count()} cards"!);
            }

            return sb.ToString().TrimEnd();
        }

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var purchasesXmlAsString =
                XmlConverter.Deserializer<PurchasesImportDto>(xmlString, "Purchases");

            var sb = new StringBuilder();

            foreach (var purchaseXml in purchasesXmlAsString)
            {
                if (!IsValid(purchaseXml))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime.TryParseExact(purchaseXml.Date, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime purchaseDate);

                var purchase = new Purchase()
                {
                    Game = context.Games.FirstOrDefault(g => g.Name == purchaseXml.GameName),
                    Type = purchaseXml.Type.Value,
                    ProductKey = purchaseXml.Key,
                    Card = context.Cards.FirstOrDefault(c => c.Number == purchaseXml.Card),
                    Date = purchaseDate
                };

                var userName = context.Users.Where(u => u.Id == purchase.Card.UserId)
                    .Select(u => u.Username).FirstOrDefault();

                context.Purchases.Add(purchase);
                context.SaveChanges();
                sb.AppendLine($"Imported {purchaseXml.GameName} for {userName}"!);
            }

            return sb.ToString().TrimEnd();
        }

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}