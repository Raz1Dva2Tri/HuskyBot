using HuskyBot_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Telegram.Bot;
using Telegram.Bot.Types;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace HuskyBot_.Controllers
{
    [ApiController]
    [Route("/")]
    public class BotController : Controller
    {


        public ApplicationContext db { get; set; }
        public BotController(ApplicationContext context)
        {

            db = context;
        }


        private TelegramBotClient bot = Bot.GetTelegramBot();
        private UpdateDistributor<CommandExecutor> updateDistributor = new UpdateDistributor<CommandExecutor>();


        [HttpPost]
        public async void Post(Telegram.Bot.Types.Update update)
        {




            if (update.Message == null) //и такое тоже бывает, делаем проверку
                return;


            

            await updateDistributor.GetUpdate(update, db);

            //TelegramBotClient Client = Bot.GetTelegramBot();
            //
            //Location loc = update.Message.Location;
            //
            //db.Locations.Add(new Models.LocationModel() { UserId = 000, Latitude = loc.Latitude, Longitude /=/ loc.Longitude });
            //await db.SaveChangesAsync();
            //long chatId = update.Message.Chat.Id;
            //
            //await Client.SendTextMessageAsync(chatId, $"{loc.Latitude} {loc.Longitude}");


        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return View(await db.Locations.ToListAsync());
        }




        [HttpPost("/Bot/Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
        LocationModel location = await db.Locations.FirstOrDefaultAsync(p => p.Id == id);
                if (location != null)
                {
                    db.Locations.Remove(location);
                    await db.SaveChangesAsync();
                    

           TelegramBotClient Client = Bot.GetTelegramBot();

        long chatId = location.UserId;

        await Client.SendTextMessageAsync(chatId, $"{location.Latitude} {location.Longitude} Удалена");
                    return RedirectToAction("Get");
                }



            }
            return NotFound();
        }

    }
}
