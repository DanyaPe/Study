using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BotProgram
{
    class Program
    {
        private static string token = "5996036976:AAHK7Cx5LbOEu5rvR8a2nt1jX7owrIWzLJU";
        private static string my_id = "5133411380";

        static void Main()
        {
            var client = new TelegramBotClient(token);
            client.ReceiveAsync(Update, Error);
            Console.ReadLine();
        }

        async static Task Update(ITelegramBotClient client, Update update, CancellationToken token)
        {
            Console.WriteLine("Выполняю Attention");
            do
            {
                if (System.DateTime.Now.Hour == 19 /*&& System.DateTime.Now.Minute == 58*/)
                {
                    Console.WriteLine($"Направляю уведомление, время - {System.DateTime.Now}");
                    client.SendTextMessageAsync(my_id, $"Доброе утро, время {System.DateTime.Now}, давай проверим выполнил ли ты все нужные дела!", replyMarkup: GetButtons("yes", "no"));
                }
                System.Threading.Thread.Sleep(60000); ;
            } while (true);
            //var message = update.Message;
            //Console.WriteLine(DateTime.Now);
            //if (message.Text != null && message.Text.Contains("test"))
            //{
            //    await client.SendTextMessageAsync(my_id, "Я живой"); 
            //}
        }

        async static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {

        }


        static InlineKeyboardMarkup GetButtons(string text1, string text2)
        {
            var ikm = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData(text1, "myCommand1"),
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData(text2, "myCommand1"),
                },
            });
            return ikm;
        }
    }
}