using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curaja.Entities
{
    public class EstadoEsqueleto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public long Id { set; get; }

        [ForeignKey("Movimento")]
        public long MovimentoId { set; get; }

        public virtual Movimento Movimento { set; get; }

        [ForeignKey("EsqueletoResultadoSessao")]
        public long EsqueletoResultadoSessaoId { set; get; }

        public virtual EsqueletoResultadoSessao EsqueletoResultadoSessao { set; get; }
    }
}