using System.ComponentModel.DataAnnotations;

namespace etec_delivery_backend.Models
{
    public class Cliente
    {
        [Key]
        public int Id_Cliente { get; set; }
        [Required]
        public string Nome_Cliente { get; set; }
        public string Contato_Telefonico_Cliente { get; set; }
        [Required]
        public string Endereco_Completo_Cliente { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}