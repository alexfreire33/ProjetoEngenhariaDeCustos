using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbCores
    {
        public int CodCores { get; set; }
        public string NomeCores { get; set; }
        public int TbStatusGeralCodStatusGeral { get; set; }

        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
    }
}
