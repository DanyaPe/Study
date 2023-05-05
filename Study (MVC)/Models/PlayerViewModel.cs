using System.ComponentModel.DataAnnotations;

namespace Study__MVC_.Models
{
    public class PlayerViewModel
    {
        public string Name;

        public List<Card> Hand;

        // Выдаем карты на руки
        public void GetCards()
        {
            CardHealthModel Health = new CardHealthModel(this.Name);
            CardInventoryModel Inventory = new CardInventoryModel(this.Name);
            CardBiologyModel Biology = new CardBiologyModel(this.Name);
            CardFactsModel Fact = new CardFactsModel(this.Name);
            CardHobbyModel Hobby = new CardHobbyModel(this.Name);
            CardProfModel Prof = new CardProfModel(this.Name);

            Hand = new List<Card> { Health, Inventory, Biology, Fact, Hobby, Prof};
        }
    }
}
