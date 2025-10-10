using System.ComponentModel.DataAnnotations;

namespace etec_delivery_back.Models
{
    public class Cliente
    {
        [Key]
        public int Id_Cliente { get; set; }

        [Required]
        public string Nome_Cliente { get; set; }
        public string Telefone_Cliente { get; set; }
        [Required]
        public string Endereco_Cliente { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}