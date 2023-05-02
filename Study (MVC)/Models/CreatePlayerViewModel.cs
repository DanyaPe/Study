using System.ComponentModel.DataAnnotations;

namespace Study__MVC_.Models
{
    public class CreatePlayerViewModel
    {
        [Required(ErrorMessage = "Необходи ввести хоть какое-то имя")]
        [MinLength(2, ErrorMessage = "Минимальная длина имени должна быть 2 символа")]
        public string Name { get; set; }
    }
}
