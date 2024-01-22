using System.ComponentModel.DataAnnotations;
using Telegram.Bot.Types;

namespace HuskyBot_.Models
{
    public class LocationModel 
    {

        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public  long UserId { get; set; }


        public string? Username { get; set; }


    }



}
