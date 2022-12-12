using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbLog
    {
        public int CodLog { get; set; }
        public DateTime? DataLog { get; set; }
        public string Texto { get; set; }
        public string TipoDoLog { get; set; }
        public string NomeDaPagina { get; set; }
        public string IpLog { get; set; }
        public string NumeroDaLinha { get; set; }
        public string VelocidadeDeExecucao { get; set; }
        public string So { get; set; }
        public string Navegador { get; set; }
        public int? TbUsuarioCodUsuario { get; set; }

        public TbUsuario TbUsuarioCodUsuarioNavigation { get; set; }
    }
}
