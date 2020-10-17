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

        

        public MorasDetalle( int moraId, int prestamoId, Decimal valor)
        {
            Id =0;
            MoraId = moraId;
            PrestamoId = prestamoId;
            Valor = valor;
            
        }
    }

}