using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbAmbienteBasico
    {
        public TbAmbienteBasico()
        {
            TbAmbiente = new HashSet<TbAmbiente>();
        }

        public int CodAmbienteBasico { get; set; }
        public string NomeAmbienteBasico { get; set; }
        public int TbStatusGeralCodStatusGeral { get; set; }

        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
        public ICollection<TbAmbiente> TbAmbiente { get; set; }
    }
}
