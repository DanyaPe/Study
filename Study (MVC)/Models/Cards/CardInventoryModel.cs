namespace Study__MVC_.Models
{
    public class CardInventoryModel : Card
    {
        string[] Variants = { "Шапочка из фольги", "Гитара", "Пистолет", "Мешок зерна", "Дилдо" };

        Random random = new Random();

        public CardInventoryModel(string Name)
        {
            Type = "Инвентарь";
            Desc = Variants[random.Next(4)];
            Owner = Name;
        }
    }
}
