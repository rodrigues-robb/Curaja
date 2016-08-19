using System.Collections.Generic;

namespace Curaja.Entities
{
    public class Fisioterapeuta : Pessoa
    {
        public virtual List<Sequencia> Sequencias { set; get; }

        public virtual List<Tratamento> Tratamentos { set; get; }
    }
}