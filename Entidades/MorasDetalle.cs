using System;
using System.ComponentModel.DataAnnotations;

namespace RPrestamos.Entidades
{
    public class MorasDetalle
    {
        [Key]
        public int Id { get; set; }

        public int MoraId { get; set; }

        public int PrestamoId { get; set; }

        public Decimal Valor { get; set; }

        

        
    }

}