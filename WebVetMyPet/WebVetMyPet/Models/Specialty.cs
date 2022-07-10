using System.ComponentModel.DataAnnotations;

namespace WebVetMyPet.Models
{
    public class Specialty
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(30, ErrorMessage = "Digite um valor menor"), MinLength(1, ErrorMessage = "Digite um valor maior")]
         public string Name { get; set; }
        

        public Specialty() { }

        public Specialty(int id , string name)
        {
            Id = id;   
            Name = name;
        }
       
    }
}
