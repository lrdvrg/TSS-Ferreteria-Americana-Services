using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSS_FAMERICANA.DTOs
{
    public class DetailDTO
    {
        public long IdEmpleado { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public decimal Salario { get; set; }
        public string Moneda { get; set; }
        public int IdHeader { get; set; }
    }
}