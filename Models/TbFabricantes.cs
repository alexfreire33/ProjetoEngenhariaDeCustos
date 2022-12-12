using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbFabricantes
    {
        public TbFabricantes()
        {
            TbInsumoBcQuant = new HashSet<TbInsumoBcQuant>();
        }

        public int CodFabricantes { get; set; }
        public string NomeFabricantes { get; set; }
        public int? TbStatusGeralCodStatusGeral { get; set; }

        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
        public ICollection<TbInsumoBcQuant> TbInsumoBcQuant { get; set; }
    }
}
