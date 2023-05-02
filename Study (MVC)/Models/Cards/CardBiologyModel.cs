namespace Study__MVC_.Models
{
    public class CardBiologyModel: Card
    {
        string[] Variants = { "Мужчина: 101 год", "Девушка: 21 год", "Гуманоид", "Кот-гендер", "Гомосексуальная женщина: 34 года" };

        Random random = new Random();

        public CardBiologyModel(string Name)
        {
            Type = "Биология";
            Desc = Variants[random.Next(4)];
            Owner = Name;
        }
    }
}
