using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbMateriaPrima
    {
        public TbMateriaPrima()
        {
            TbInsumoBcQuant = new HashSet<TbInsumoBcQuant>();
        }

        public int CodMateriaPrima { get; set; }
        public string NomeMateriaPrima { get; set; }
        public int TbStatusGeralCodStatusGeral { get; set; }

        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
        public ICollection<TbInsumoBcQuant> TbInsumoBcQuant { get; set; }
    }
}
