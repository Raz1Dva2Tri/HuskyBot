using HuskyBot_.Controllers;
using Telegram.Bot.Types;

namespace HuskyBot_
{
    public interface ITelegramUpdateListener
    {
          Task GetUpdate(Update update, ApplicationContext db);
    }
}
