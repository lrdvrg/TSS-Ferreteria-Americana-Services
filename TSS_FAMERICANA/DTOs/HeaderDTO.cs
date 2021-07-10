using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSS_FAMERICANA.DTOs
{
    public class HeaderDTO
    {
        public int IdHeader { get; set; }
        public string Proceso { get; set; }
        public int RNC { get; set; }
        public System.DateTime PeriodoAutodeterminacion { get; set; }
        public System.DateTime FechaTransmision { get; set; }
    }
}