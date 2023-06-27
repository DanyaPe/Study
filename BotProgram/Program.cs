using System.Text;
using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotProgram
{
    class Program
    {
        private static string token = "5996036976:AAHK7Cx5LbOEu5rvR8a2nt1jX7owrIWzLJU";
        private static string my_id = "5133411380";
        static string pattern1 = @"^(\d*)\s(заявок)";
        static string pattern2 = @"(книга - )([а-яА-я0-9\s]*)";
        static string pattern3 = @"^(\d*)\s(штук)";
        static string? artname;

        static void Main()
        {
            var client = new TelegramBotClient(token);
            client.StartReceiving(Update, Error);
            TimeTaskCheck(client);
            Console.ReadLine();
        }

        async static Task Update(ITelegramBotClient client, Update update, CancellationToken token)
        {
            //Обработка сообщений
            if (update.Message != null)
            {
                if (update.Message.Text != null)
                {
                    if (update.Message.Text.ToLower().Contains("тест"))
                    {
                        //Console.WriteLine("Я живой");
                        //client.SendTextMessageAsync(my_id, $"Начитаный получается, что же ты читал?\nНапиши 'Книга - ' и название произведения, к примеру последняя запись у нас {artname}");
                    }
                    //Запись количества заявок
                    else if (Regex.IsMatch(update.Message.Text, pattern1, RegexOptions.IgnoreCase))
                    {
                        client.SendTextMessageAsync(my_id, $"Количество завок на {System.DateTime.Today.ToShortDateString()} записано в файл TicketValue.XML");
                        PrintToFile("TicketValue", update.Message.Text);
                        client.SendTextMessageAsync(my_id, $"А просрочки есть?", replyMarkup:GetButtons("Да", "Нет", "myCommand5", "myCommand6"))
                    }
                    //Запись произведения на сегодня
                    else if (Regex.IsMatch(update.Message.Text, pattern2, RegexOptions.IgnoreCase))
                    {
                        client.SendTextMessageAsync(my_id, $"Произведение на {System.DateTime.Today.ToShortDateString()} записано в файл Art.XML");
                        PrintToFile("Art", update.Message.Text);
                        artname = update.Message.Text;
                    }
                    else if (Regex.IsMatch(update.Message.Text, pattern3, RegexOptions.IgnoreCase))
                    {
                        client.SendTextMessageAsync(my_id, $"Количество просроков на {System.DateTime.Today.ToShortDateString()} записано в файл Deadline.XML");
                        PrintToFile("Deadline", update.Message.Text);
                    }
                    //Обработка другого сообщения
                    else
                    {
                        client.SendTextMessageAsync(my_id, $"Данек, ничего не понял, давай по новой");
                    }
                }
            }
            //Обработка кнопок
            else if(update.CallbackQuery.Data != null)
            {
                //Запись того что успел на работу
                if (update.CallbackQuery.Data == "myCommand1")
                {
                    client.SendTextMessageAsync(my_id, $"Ля красава, записал тебе плюсик в файлик AudtationList.XML\nЯ еще цинкану в 18:20");
                    PrintToFile("AudtationList", "Успел");
                }
                //Запись того что опоздал на работу
                else if (update.CallbackQuery.Data == "myCommand2")
                {
                    client.SendTextMessageAsync(my_id, $"Другалечек ну ты что, тебе минусик в файлик AudtationList.XML\nЯ еще цинкану в 18:20");
                    PrintToFile("AudtationList", "Опоздал");
                }
                //Обработка кнопки "Читал"
                else if (update.CallbackQuery.Data == "myCommand3")
                {
                    client.SendTextMessageAsync(my_id, $"Начитаный получается, что же ты читал?\nНапиши 'Книга - ' и название произведения, к примеру последняя запись у нас {artname}");
                }
                //Обработка кнопки "Не читал"
                else if (update.CallbackQuery.Data == "myCommand4")
                {
                    client.SendTextMessageAsync(my_id, $"Да уж, не быть тебе русским романтиком\nТак и запишем в файлик Art.XML - 'не читал'");
                    PrintToFile("Art", "Не читал");
                }
                //Кнопка "Да" на вопрос о просроках
                else if (update.CallbackQuery.Data == "myCommand5")
                {
                    client.SendTextMessageAsync(my_id, $"Это больно\nСколько штук?");
                }
                //Кнопка "Нет" на вопрос о просроках
                else if (update.CallbackQuery.Data == "myCommand6")
                {
                    client.SendTextMessageAsync(my_id, $"Ля красава");
                }
            }
        }

        async static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {

        }

        static InlineKeyboardMarkup GetButtons(string text1, string text2, string value1, string value2)
        {
            var ikm = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData(text1, value1),
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData(text2, value2),
                },
            });
            return ikm;
        }

        async static Task TimeTaskCheck(ITelegramBotClient client)
        {
            do
            {
                Console.WriteLine("Выполняю проверку по времени");
                //Сообщение в начале дня
                if (System.DateTime.Now.Hour == 10 && System.DateTime.Now.Minute == 00 && System.DateTime.Now.DayOfWeek != DayOfWeek.Sunday && System.DateTime.Now.DayOfWeek != DayOfWeek.Saturday)
                {
                    client.SendTextMessageAsync(my_id, $"С началом рабочего дня, сегодня - {System.DateTime.Today.ToShortDateString()}, успел на работу?", replyMarkup: GetButtons("Успел", "Опоздал :(", "myCommand1", "myCommand2"));
                    Console.WriteLine($"Сообщение о начале дня отправлено в {System.DateTime.Now}");
                    System.Threading.Thread.Sleep(60000);
                }
                //Сообщение в конце рабочего дня
                else if(System.DateTime.Now.Hour == 18 && System.DateTime.Now.Minute == 20 && System.DateTime.Now.DayOfWeek != DayOfWeek.Sunday && System.DateTime.Now.DayOfWeek != DayOfWeek.Saturday)
                {
                    client.SendTextMessageAsync(my_id, $"Смену отпахал, уважаемо, время - {System.DateTime.Now.ToLongTimeString()}, пора бы и честь знать, сколько заявочек решил?\nНапиши число и через пробел 'заявок'");
                    Console.WriteLine($"Сообщение о конце рабочего дня отправлено в {System.DateTime.Now}");
                    System.Threading.Thread.Sleep(60000);
                }
                //Сообщение перед сном
                else if (System.DateTime.Now.Hour == 23 && System.DateTime.Now.Minute == 00 && System.DateTime.Now.DayOfWeek != DayOfWeek.Sunday && System.DateTime.Now.DayOfWeek != DayOfWeek.Saturday)
                {
                    client.SendTextMessageAsync(my_id, $"Время позднее, а точнее - {System.DateTime.Now.ToLongTimeString()}, скажи мне читал ли чего-нибудь сегодня?", replyMarkup: GetButtons("Читал", "Не до того", "myCommand3", "myCommand4"));
                    Console.WriteLine($"Сообщение перед сном отправлено в {System.DateTime.Now}");
                    System.Threading.Thread.Sleep(60000);
                }
                //Ожидаем подходящего времени
                else
                {
                    Console.WriteLine("Ожидаю");
                    System.Threading.Thread.Sleep(60000);
                }
            } while(true);
        }

        async static public void PrintToFile(string filename, string value)
        {
            string text = $"\n{value}, {System.DateTime.Today.ToShortDateString()}";
            using (FileStream fstream = new FileStream($"{filename}.xml", FileMode.Append))
            {
                byte[] buffer = Encoding.Default.GetBytes(text);
                fstream.WriteAsync(buffer, 0, buffer.Length);
                Console.WriteLine($"Текст записан в файл - {fstream.Name}");
            }
        }
    }
}