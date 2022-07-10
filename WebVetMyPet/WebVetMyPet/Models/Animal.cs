using System.ComponentModel.DataAnnotations;

namespace WebVetMyPet.Models
{
    public class Animal
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "Digite um valor menor"), MinLength(1, ErrorMessage = "Digite um valor maior")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "Digite um valor menor"), MinLength(1, ErrorMessage = "Digite um valor maior")]
        public string Specie { get; set; }

        public string Gender { get; set; }

        public decimal Weight { get; set; }

        [Display(Name= "Birth Date")] 
        public DateTime BirthDate { get; set; }


        [Display(Name = "Owner")]
        public int OwnerId {get; set; }
        public Owner Owner { get; set; }
        
        public Animal() { }

        public Animal(int id, string name, string specie, string gender, decimal weight, DateTime birthDate, Owner owner)
        {
            Id = id;
            Name = name;
            Specie = specie;
            Gender = gender;
            Weight = weight;
            BirthDate = birthDate;
            Owner = owner;
        }
    }
}
