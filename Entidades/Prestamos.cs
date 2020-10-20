using System;
using System.ComponentModel.DataAnnotations;

namespace RPrestamos.Entidades
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public int PersonaId { get; set; }

        public string Concepto { get; set; }

        public Decimal Monto { get; set; }

        public Decimal Balance { get; set; }

        public int Mora { get; set; } = 0;

    }
}
