using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace etec_delivery_back.Models
{
    public class RotaEntrega
    {
        [Key]
        public int Id_RotaEntrega { get; set; }

        [Required]
        public string Nome_RotaEntrega { get; set; }
        public DateTime Criado_em_RotaEntrega { get; set; }
        public ICollection<Cliente> Clientes = new List<Cliente>();

        public int Id_Usuario { get; set; }
        [ForeignKey("Id_Usuario")]
        public Usuario Usuario { get; set; }
    }
}