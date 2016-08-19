using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curaja.Entities
{
    public abstract class Pessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public long Id { set; get; }

        [Required]
        [MaxLength(255)]
        public string Nome { set; get; }

        [Required]
        [DisplayName("Gênero")]
        public char Genero { set; get; }

        [MaxLength(18)]
        [DisplayName("Telefone Residencial")]
        public string Telefone { set; get; }

        [MaxLength(19)]
        [DisplayName("Telefone Celular")]
        public string Celular { set; get; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { set; get; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        [Index(IsUnique = true)]
        [DisplayName("E-mail")]
        public string Email { set; get; }

        [Required]
        [MaxLength(11)]
        [Index(IsUnique = true)]
        public string Cpf { set; get; }

        [ForeignKey("Usuario")]
        public long UsuarioId { set; get; }

        public virtual Usuario Usuario { set; get; }
    }
}