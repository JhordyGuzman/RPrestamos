using System;
using System.ComponentModel.DataAnnotations;

namespace RPrestamos.Entidades
{
    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }

        public String Nombres { get; set; }

        public String Balance { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;


    }
}