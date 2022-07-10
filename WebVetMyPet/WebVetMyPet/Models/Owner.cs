using System.ComponentModel.DataAnnotations;

namespace WebVetMyPet.Models
{
    public class Owner
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(14, ErrorMessage = "Digite um valor menor"), MinLength(11, ErrorMessage = "Digite um valor maior")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(30, ErrorMessage = "Digite um valor menor"), MinLength(1, ErrorMessage = "Digite um valor maior")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(15, ErrorMessage = "Digite um valor menor"), MinLength(8, ErrorMessage = "Digite um valor maior")]
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public ICollection<Animal> Animal { get; set; } = new List<Animal>();
        public Owner() { }

        public Owner(int id, string cpf, string name, string cellphone, string email, string adress)
        {
            Id = id;
            Cpf = cpf;
            Name = name;
            Cellphone = cellphone;
            Email = email;
            Adress = adress;
        }
    }
}
