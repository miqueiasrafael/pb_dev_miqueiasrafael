using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using Newtonsoft.Json;

namespace PBWebApi.DataAccess.Models
{
    /// <summary>
    /// Create model sample of Address to Persons 
    /// Author: Miquéias Rafael
    /// 
    /// Adaptar service for consulting CEP in https://viacep.com.br/ws/83706160/json/
    /// </summary>
    public class Endereco
    {
        public int Id { get; set; }

        [MaxLength(10)]
        public string CEP { get; set; }

        [Required]
        [MaxLength(2)]
        public string UF { get; set; }

        [Required]
        [MaxLength(25)]
        public string Cidade { get; set; }

        [MaxLength(30)]
        public string Bairro { get; set; }

        [MaxLength(80)]
        public string Logradouro { get; set; }

        [MaxLength(6)]
        public string Numero { get; set; }

        [MaxLength(30)]
        public string Complemento { get; set; }

        //[JsonIgnore]
        [ForeignKey("PessoaForeignKey")]
        public Pessoa Pessoa_Id { get; set; }

        public int PessoaForeignKey { get; set; }
    }

    public enum PessoaFake
    {
        Null = 0,
        Temporario = 1
    }


}
