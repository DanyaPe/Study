namespace Study__MVC_.Models
{
    public class CardHealthModel : Card
    {
        string[] Variants = { "Раздвоение личности", "Суициадальные мысли", "Карлик", "Лунатизм", "Мания преследования" };

        Random random = new Random();

        public CardHealthModel(string Name)
        {
            Type = "Здоровье";
            Desc = Variants[random.Next(4)];
            Owner = Name;
        }
    }
}
