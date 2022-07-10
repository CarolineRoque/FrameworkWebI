using System.ComponentModel.DataAnnotations;

namespace WebVetMyPet.Models
{
    public class Veterinarian
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(14, ErrorMessage = "Digite um valor menor"), MinLength(1, ErrorMessage = "Digite um valor maior")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "Digite um valor menor"), MinLength(11, ErrorMessage = "Digite um valor maior")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(11, ErrorMessage = "Digite um valor menor"), MinLength(1, ErrorMessage = "Digite um valor maior")]
        public string Cellphone { get; set; }
        
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Crmv { get; set; }

        [Display(Name = "Specialty")]
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }

        public Veterinarian() { }
        public Veterinarian(int id, string name , string cpf , string cellphone , string email, string crmv, Specialty specialty)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            Cellphone = cellphone;
            Email = email;
            Crmv = crmv;
            Specialty = specialty;
        }
    }
}
