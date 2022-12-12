using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbGrupoServico
    {
        public TbGrupoServico()
        {
            TbServicoBc = new HashSet<TbServicoBc>();
        }

        public int CodGrupoServico { get; set; }
        public string NomeGrupoServico { get; set; }
        public string SigaGrupoServico { get; set; }
        public int TbStatusGeralCodStatusGeral { get; set; }

        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
        public ICollection<TbServicoBc> TbServicoBc { get; set; }
    }
}
