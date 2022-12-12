using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbTipologia
    {
        public TbTipologia()
        {
            TbObra = new HashSet<TbObra>();
        }

        public int CodTipologia { get; set; }
        public string NomeTipologia { get; set; }
        public int TbStatusGeralCodStatusGeral { get; set; }

        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
        public ICollection<TbObra> TbObra { get; set; }
    }
}
