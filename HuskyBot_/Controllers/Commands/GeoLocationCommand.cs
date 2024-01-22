using Telegram.Bot.Types;
using Telegram.Bot;

namespace HuskyBot_.Controllers.Commands
{
    public class GeoLocationCommand : ICommand
    {
        
        public TelegramBotClient Client => Bot.GetTelegramBot();

        Location Location { get; set; }

        public string Name => "";

        public async Task Execute(Update update, ApplicationContext db)
        {





             Location = update.Message.Location;
             
             db.Locations.Add(new Models.LocationModel() { UserId = update.Message.From.Id, Latitude = Location.Latitude, Longitude = Location.Longitude, Username = update.Message.From.Username});
             await db.SaveChangesAsync();
            long chatId = update.Message.Chat.Id;
            
            await Client.SendTextMessageAsync(chatId, $"{Location.Latitude} {Location.Longitude}");
        }
    }
}
