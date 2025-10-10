using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace etec_delivery_back.Models
{
    public class Usuario
    {
        [Key]
        public int Id_Usuario { get; set; }

        [Required]
        public string Nome_Usuario { get; set; }
        [Required]
        public string Email_Usuario { get; set; }
        [Required]
        public string Senha_Hash_Usuario { get; set; }
        [InverseProperty("Usuario")]
        public ICollection<RotaEntrega> Rota_Entregas { get; set; } =
            new List<RotaEntrega>();
    }
}
