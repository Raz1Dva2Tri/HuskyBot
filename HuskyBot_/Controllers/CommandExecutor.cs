using HuskyBot_;
using HuskyBot_.Controllers;
using HuskyBot_.Controllers.Commands;
using Telegram.Bot.Types;

namespace HuskyBot_.Controllers
{
    public class CommandExecutor : ITelegramUpdateListener
    {
        private List<ICommand> commands;

        public CommandExecutor()
        {
            commands = new List<ICommand>()
            {
                new StartCommand(),
                new GeoLocationCommand(),
            };
        }

        public async Task GetUpdate(Update update, ApplicationContext db)
        {



            Message? msg = update.Message;
            if (msg == null) //такое бывает, во избежании ошибок делаем проверку
                return;

            ////if (db.Users.Find(msg.From.Id) == null)
            ////{
            ////    db.Users.Add(new Models.UserModel() { Id = msg.From.Id, FirstName = m/sg.From.FirstName, ///IsBot = msg.From.IsBot, LastName = msg.From.LastName, Username = m/sg.From.Username });
            ////    await db.SaveChangesAsync();
            ////    long chatId = update.Message.Chat.Id;
            ////
            ////}

            if ("/start" == msg.Text)
            {
                await new StartCommand().Execute(update);
            }
            if (msg.Location != null)
            {

            await new GeoLocationCommand().Execute(update, db);
            }
            
        }
    }
}
