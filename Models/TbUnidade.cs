using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbUnidade
    {
        public int CodTbUnidade { get; set; }
        public string Nome { get; set; }
        public int TbStatusGeralCodStatusGeral { get; set; }

        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
    }
}
