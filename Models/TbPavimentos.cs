using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbPavimentos
    {
        public TbPavimentos()
        {
            TbPavimentoUc = new HashSet<TbPavimentoUc>();
        }

        public int CodPavimentos { get; set; }
        public string NomePavimentos { get; set; }
        public int TbStatusGeralCodStatusGeral { get; set; }

        [JsonIgnore]
        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
        public ICollection<TbPavimentoUc> TbPavimentoUc { get; set; }
    }
}
