using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curaja.Entities
{
    public class Tratamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public long Id { set; get; }

        [Required]
        [MaxLength(75)]
        public string Patologia { set; get; }

        [Required]
        [DisplayName("Número de Sessões")]
        public int NumSessoes { set; get; }

        [Required]
        [MaxLength(50)]
        public string Status { set; get; }

        [MaxLength(255)]
        [DisplayName("Motivo")]
        public string MotivoStatus { set; get; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataCadastro { set; get; }

        public long FisioterapeutaId { set; get; }

        public virtual Fisioterapeuta Fisioterapeuta { set; get; }

        public long PacienteId { set; get; }

        public virtual Paciente Paciente { set; get; }

        public virtual List<Sessao> Sessoes { set; get; }
    }
}