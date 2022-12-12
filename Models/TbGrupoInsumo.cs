using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbGrupoInsumo
    {
        public TbGrupoInsumo()
        {
            TbItensLevantamento = new HashSet<TbItensLevantamento>();
        }

        public int CodGrupoInsumo { get; set; }
        public string NomeGrupoInsumo { get; set; }
        public string SiglaGrupoInsumo { get; set; }
        public int TbStatusGeralCodStatusGeral { get; set; }

        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
        public ICollection<TbItensLevantamento> TbItensLevantamento { get; set; }
    }
}
