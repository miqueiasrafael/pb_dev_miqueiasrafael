using System.ComponentModel.DataAnnotations;

namespace PBWebApi.DataAccess.Models
{
    /// <summary>
    /// Create model sample Person 
    /// Author: Miquéias Rafael
    /// </summary>
    public class Pessoa
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Telefone { get; set; }

        [Required]
        public Endereco Endereco { get; set; }
    }

   

}
