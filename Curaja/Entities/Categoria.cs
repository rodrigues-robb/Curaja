using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curaja.Entities
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public long Id { set; get; }

        [MaxLength(55)]
        public string Nome { set; get; }

        public virtual List<Movimento> Movimentos { set; get; }
    }
}