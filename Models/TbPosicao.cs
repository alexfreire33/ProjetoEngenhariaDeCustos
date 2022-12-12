using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbPosicao
    {
        public TbPosicao()
        {
            TbInsumoBcQuant = new HashSet<TbInsumoBcQuant>();
            TbServicoBc = new HashSet<TbServicoBc>();
        }

        public int CodPosicao { get; set; }
        public string NomePosicao { get; set; }
        public int? TbStatusGeralCodStatusGeral { get; set; }

        [JsonIgnore]
        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
        public ICollection<TbInsumoBcQuant> TbInsumoBcQuant { get; set; }
        public ICollection<TbServicoBc> TbServicoBc { get; set; }
    }
}
