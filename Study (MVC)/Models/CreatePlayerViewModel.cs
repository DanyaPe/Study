using System.ComponentModel.DataAnnotations;

namespace Study__MVC_.Models
{
    public class CreatePlayerViewModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [MinLength(2, ErrorMessage = "Минимальная длина имени 2 символа")]
        public string Name { get; set; }
    }
}
