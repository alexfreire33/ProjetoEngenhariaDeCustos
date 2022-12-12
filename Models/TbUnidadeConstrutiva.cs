using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbUnidadeConstrutiva
    {
        public TbUnidadeConstrutiva()
        {
            TbUcObra = new HashSet<TbUcObra>();
        }

        public int CodUnidadeConstrutiva { get; set; }
        public string NomeUnidadeConstrutiva { get; set; }
        public int TbStatusGeralCodStatusGeral { get; set; }

        [JsonIgnore]
        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }

        public ICollection<TbUcObra> TbUcObra { get; set; }
    }
}
