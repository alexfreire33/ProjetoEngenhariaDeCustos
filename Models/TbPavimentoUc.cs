using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbPavimentoUc
    {
        public TbPavimentoUc()
        {
            TbAmbiente = new HashSet<TbAmbiente>();
        }

        public int CodPavimentoUc { get; set; }
        public int? NumeroRepeticoesPavimento { get; set; }
        public int TbPavimentosCodPavimentos { get; set; }
        public int TbStatusGeralCodStatusGeral { get; set; }
        public int TbUcObraCodUcObra { get; set; }

        public TbPavimentos TbPavimentosCodPavimentosNavigation { get; set; }
        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
        public TbUcObra TbUcObraCodUcObraNavigation { get; set; }
        public ICollection<TbAmbiente> TbAmbiente { get; set; }
    }
}
