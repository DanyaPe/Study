namespace Study__MVC_.Models
{
    public class CardProfModel: Card
    {
        string[] Variants = { "Робототехник", "Дизайнер", "Полицейский", "Геолог", "Браконьер" };

        Random random = new Random();

        public CardProfModel(string Name)
        {
            Type = "Профессия";
            Desc = Variants[random.Next(4)];
            Owner = Name;
        }
    }
}
