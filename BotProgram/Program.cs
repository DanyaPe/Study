using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Text;
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
            client.StartReceiving(Update, Error);
            TimeTaskCheck(client);
            Console.ReadLine();
        }

        async static Task Update(ITelegramBotClient client, Update update, CancellationToken token)
        {
            if (update.Message != null)
            {
                if (update.Message.Text.ToLower().Contains("тест"))
                {
                    Console.WriteLine("Я живой");
                }
            }
            else if(update.CallbackQuery.Data == "myCommand1")
            {
                client.SendTextMessageAsync(my_id, $"Отрабатываю кнопку 'Да'");
            }
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
                    InlineKeyboardButton.WithCallbackData(text2, "myCommand2"),
                },
            });
            return ikm;
        }

        async static Task TimeTaskCheck(ITelegramBotClient client)
        {
            do
            {
                Console.WriteLine("Выполняю проверку по времени");
                if (System.DateTime.Now.Hour == 23 && System.DateTime.Now.Minute == 23 /*&& System.DateTime.Now.Second == 05 && System.DateTime.Now.DayOfWeek != DayOfWeek.Sunday && System.DateTime.Now.DayOfWeek != DayOfWeek.Saturday*/)
                {
                    client.SendTextMessageAsync(my_id, $"Доброе утро, время {System.DateTime.Now}, давай проверим выполнил ли ты все нужные дела!", replyMarkup: GetButtons("yes", "no"));
                    Console.WriteLine($"Сообщение отправлено в {System.DateTime.Now}, ожидаю") ;
                    System.Threading.Thread.Sleep(60000);
                }
                else
                {
                    Console.WriteLine("Ожидаю");
                    System.Threading.Thread.Sleep(60000);
                }
            } while(true);
        }

        //async static public void myCommand1()
        //{
        //    string text = $"Положительный ответ, {System.DateTime.Now}";
        //    using (FileStream fstream = new FileStream("info.xml", FileMode.Append))
        //    {
        //        byte[] buffer = Encoding.Default.GetBytes(text);
        //        fstream.WriteAsync(buffer, 0, buffer.Length);
        //        Console.WriteLine($"Текст записан в файл - {fstream.Name}");
        //    }
        //}
    }
}