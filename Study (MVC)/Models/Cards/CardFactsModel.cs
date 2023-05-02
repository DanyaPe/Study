namespace Study__MVC_.Models
{
    public class CardFactsModel: Card
    {
        string[] Variants = { "Врет и преувеличивает", "Бродяжничал 2 года", "Подходит сзади и дышит", "Наркодиллер", "Гинофобия - боится женщин" };

        Random random = new Random();

        public CardFactsModel(string Name)
        {
            Type = "Факт";
            Desc = Variants[random.Next(4)];
            Owner = Name;
        }
    }
}
