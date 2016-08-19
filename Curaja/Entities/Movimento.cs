using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curaja.Entities
{
    public class Movimento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public long Id { set; get; }

        [Required]
        [MaxLength(75)]
        [DisplayName("Título")]
        public string Titulo { set; get; }

        [MaxLength(255)]
        [DisplayName("Descrição")]
        public string Descricao { set; get; }

        [Required]
        [DisplayName("Tempo de Execução Máximo")]
        public int TempoExecucaoMaximo { set; get; }

        [DisplayName("Tempo de Execução Mínimo")]
        public int TempoExecucaoMinimo { set; get; }

        [DataType(DataType.Url)]
        public string imagem { set; get; }

        public long CategoriaId { set; get; }

        public virtual Categoria Categoria { set; get; }

        [MaxLength]
        [DataType(DataType.Text)]
        [DisplayName("Contra-indicação")]
        public string ContraIndicacao { set; get; }

        public bool Status { set; get; }

        public virtual List<MovimentoSequencia> MovimentoSequencias { set; get; }

        public virtual List<EstadoEsqueleto> EstadosEsqueleto { set; get; }
    }
}