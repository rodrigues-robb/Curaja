using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Curaja.Entities
{
    public class Joint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public long Id { set; get; }

        public float X { set; get; }

        public float Y { set; get; }

        public float Z { set; get; }

        public long EnumJointId { set; get; }

        public virtual EnumJoint EnumJoint { set; get; }

        public long EstadoEsqueletoId { set; get; }

        public virtual EstadoEsqueleto EstadoEsqueleto { set; get; }
    }
}