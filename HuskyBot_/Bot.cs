using Telegram.Bot;

namespace HuskyBot_
{
    public class Bot
    {
        private static TelegramBotClient client { get; set; }

        public static TelegramBotClient GetTelegramBot()
        {
            if (client != null)
            {
                return client;
            }
            client = new TelegramBotClient("6687269821:AAG-XdhR1Hvx0E2fgDywqDiBC1DodzYR7pM");
            return client;
        }
    }
}
