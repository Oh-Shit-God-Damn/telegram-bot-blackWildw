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
            botClient = new TelegramBotClient("916400270:AAEEmmT9E52kdIDyKVw-sj0eGg-cHwEIWk4");
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Bot id: {me.Id}. Bot name: {me.FirstName} ");
            botClient.OnMessage += Bot_OnMessege;
            botClient.StartReceiving();
            Console.ReadKey();
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
                await botClient.SendTextMessageAsync(e.Message.Chat.Id, e.Message.Chat.Username +", Hey Pidor" + "\n" + "/help - A list of my commands").ConfigureAwait(false);
                //await botClient.SendTextMessageAsync(e.Message.Chat.Id, "sadas").ConfigureAwait(false);
                return;

            }
             if (text == "/Baton")
            {
                await botClient.SendPhotoAsync(e.Message.Chat.Id, "https://sun9-57.userapi.com/c625819/v625819495/20533/nkJHRbVW_Yo.jpg","I'am BIG BOSS").ConfigureAwait(false);
                return;
            }
            if (text == "/Yakuba")
            {
               await botClient.SendAudioAsync(chatId: e.Message.Chat.Id,"https://github.com/TelegramBots/book/raw/master/src/docs/audio-guitar.mp3");
            }
            if (text == "/help")
            {
                await botClient.SendTextMessageAsync(e.Message.Chat,"/Baton" + "- calling Baton");
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId: e.Message.Chat, text: $"I don't know what is    <{text}> :(").ConfigureAwait(false);
            }
        }
    }
}
    