using Newtonsoft.Json;
using Telegram.Bot.Types;

namespace HuskyBot_.Models
{
    public class UserModel 
    {

        public long Id { get; set; }


        public bool IsBot { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Username { get; set; }

    }
}
