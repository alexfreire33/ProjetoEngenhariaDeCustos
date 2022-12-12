using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbItensLevantamento
    {
        public TbItensLevantamento()
        {
            TbInsumoBcQuant = new HashSet<TbInsumoBcQuant>();
        }

        public int CodItensLevantamento { get; set; }
        public string NomeItensLevantamento { get; set; }
        public int TbStatusGeralCodStatusGeral { get; set; }
        public int TbGrupoInsumoCodGrupoInsumo { get; set; }
        public int TbUnidadeMedidaCodUnidadeMedida { get; set; }

        public TbGrupoInsumo TbGrupoInsumoCodGrupoInsumoNavigation { get; set; }
        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
        public TbUnidadeMedida TbUnidadeMedidaCodUnidadeMedidaNavigation { get; set; }
        public ICollection<TbInsumoBcQuant> TbInsumoBcQuant { get; set; }
    }
}
