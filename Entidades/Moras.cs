using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPrestamos.Entidades
{
    public class Moras
    {
        [Key]
        public int MoraId { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public Decimal Total { get; set; }

        [ForeignKey("MoraId")]
        public virtual List<MorasDetalle> MorasDetalle { get; set; } = new List<MorasDetalle>();

    }
}