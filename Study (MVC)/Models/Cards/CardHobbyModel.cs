namespace Study__MVC_.Models
{
    public class CardHobbyModel: Card
    {
        string[] Variants = { "Грибы и гомеопатия", "Паркур", "Спортивные танцы", "Гадание на таро", "Компьютерные игры" };

        Random random = new Random();

        public CardHobbyModel(string Name)
        {
            Type = "Хобби";
            Desc = Variants[random.Next(4)];
            Owner = Name;
        }
    }
}
