using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbTiposLevantamento
    {
        public TbTiposLevantamento()
        {
            TbLevantamento = new HashSet<TbLevantamento>();
        }

        public int CodTiposLevantamento { get; set; }
        public string NomeTiposLevantamento { get; set; }
        public int TbStatusGeralCodStatusGeral { get; set; }

        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
        public ICollection<TbLevantamento> TbLevantamento { get; set; }
    }
}
