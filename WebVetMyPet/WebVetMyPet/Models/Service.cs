using System.ComponentModel.DataAnnotations;

namespace WebVetMyPet.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public double Value { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(1, ErrorMessage = "Insufficient Note !")]
        public string Note { get; set; }

        [Display(Name = "Veterinarian")]
        public int VeterinarianId { get; set; }
        public Veterinarian Veterinarian { get; set; }

        [Display(Name = "Animal")]
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        public Service() { }

        public Service(int id , DateTime date, double value , string note, Veterinarian veterinarian, Animal animal) 
        {
            Id = id;
            Date = date;
            Value = value;
            Note = note;
            Veterinarian = veterinarian;
            Animal = animal;
        }

    }
}
