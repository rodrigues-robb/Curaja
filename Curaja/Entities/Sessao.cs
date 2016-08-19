using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curaja.Entities
{
    public class Sessao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public long Id { set; get; }

        [DataType(DataType.DateTime)]
        [DisplayName("Data e Hora de Início")]
        public DateTime DataHoraInicio { set; get; }

        [DataType(DataType.DateTime)]
        [DisplayName("Data e Hora de Finalização")]
        public DateTime DataHoraFim { set; get; }

        public long SequenciaId { set; get; }

        public virtual Sequencia Sequencia { set; get; }

        public long TratamentoId { set; get; }

        public virtual Tratamento Tratamento { set; get; }

        public virtual List<EsqueletoResultadoSessao> EsqueloResultadosSessao { set; get; }
    }
}