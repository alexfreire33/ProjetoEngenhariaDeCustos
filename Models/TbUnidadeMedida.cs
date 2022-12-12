using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbUnidadeMedida
    {
        public TbUnidadeMedida()
        {
            TbInsumoBcQuant = new HashSet<TbInsumoBcQuant>();
            TbItensLevantamento = new HashSet<TbItensLevantamento>();
            TbServicoBc = new HashSet<TbServicoBc>();
        }

        public int CodUnidadeMedida { get; set; }
        public string NomeUnidadeMedida { get; set; }
        public int TbStatusGeralCodStatusGeral { get; set; }

        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
        public ICollection<TbInsumoBcQuant> TbInsumoBcQuant { get; set; }
        public ICollection<TbItensLevantamento> TbItensLevantamento { get; set; }
        public ICollection<TbServicoBc> TbServicoBc { get; set; }
    }
}
