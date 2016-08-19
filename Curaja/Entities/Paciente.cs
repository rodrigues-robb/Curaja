using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Curaja.Entities
{
    public class Paciente : Pessoa
    {
        [MaxLength(50)]
        [DisplayName("Profissão")]
        public string Profissao { set; get; }

        [MaxLength(255)]
        [DisplayName("Responsável")]
        public string Responsavel { set; get; }

        public virtual List<Tratamento> Tratamentos { set; get; }
    }
}