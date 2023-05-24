using System.ComponentModel.DataAnnotations;

namespace Study__MVC_.Models
{
    public class PlayerViewModelStatic
    {
        [Key]
        [Required(ErrorMessage = "Обязательное поле")]
        [MinLength(2, ErrorMessage = "Минимальная длина имени 2 символа")]
        public string Name { get; set; }

        //public List<Card> Hand { get; set; }

        public int sys_status { get; set; }

        public string CookieUrl { get; set; }

        // Выдаем карты на руки
        /*public void GetCards()
        {
            CardHealthModel Health = new CardHealthModel(this.Name);
            CardInventoryModel Inventory = new CardInventoryModel(this.Name);
            CardBiologyModel Biology = new CardBiologyModel(this.Name);
            CardFactsModel Fact = new CardFactsModel(this.Name);
            CardHobbyModel Hobby = new CardHobbyModel(this.Name);
            CardProfModel Prof = new CardProfModel(this.Name);

            Hand = new List<Card> { Health, Inventory, Biology, Fact, Hobby, Prof};
        }*/
    }
}
