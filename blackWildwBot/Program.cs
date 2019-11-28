using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace blackWildwBot
{
    class Program
    {
        private static ITelegramBotClient botClient;
        static void Main(string[] args)
        {
            string KEY_TOKEN = Environment.GetEnvironmentVariable("token");
            botClient = new TelegramBotClient(KEY_TOKEN);
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Bot id: {me.Id}. Bot name: {me.FirstName} ");
            botClient.OnMessage += Bot_OnMessege;
            botClient.StartReceiving();
            Console.Read();
            botClient.StopReceiving();
        }
        private static async void Bot_OnMessege(object sender, MessageEventArgs e)
        {
            var text = e?.Message.Text;
            if (text == null)
                return;
            Console.WriteLine($"You received new messege {text} from  {e.Message.Chat.FirstName} , {e.Message.Chat.Username}, {e.Message.Chat.Id} ");

            if (text == "/start")
            {
                await botClient.SendTextMessageAsync(e.Message.Chat.Id, e.Message.Chat.Username + " Hey Pidor").ConfigureAwait(false);
                return;
            }
            if (text == "/Baton")
            {
                await botClient.SendPhotoAsync(e.Message.Chat.Id, "https://sun9-57.userapi.com/c625819/v625819495/20533/nkJHRbVW_Yo.jpg", "I'am BIG BOSS").ConfigureAwait(false);
                return;
            }
            if (text == "/Yakuba")
            {
                await botClient.SendAudioAsync(e.Message.Chat.Id, "https://raw.githubusercontent.com/Oh-Shit-God-Damn/telegram-bot-blackWildw/master/blackWildwBot/music/Yakuba.mp3", "KING OF SPERMA");
                return;
            }
            if (text == "/YakubaFapTime")
            {
                await botClient.SendAnimationAsync(e.Message.Chat.Id, "https://2gifs.ru/images/p78.media.tumblr.com/43fdb08744c97936a8e0576ed8f3a357/tumblr_omde5oZxvG1v2bt9eo1_500.gif");
                return;
            }
            else
            {
                await botClient.SendTextMessageAsync(e.Message.Chat.Id, text: $"I don't know what is    <{text}> :(").ConfigureAwait(false);
                return;
            }
        }
    }
}
    