using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbConstrutor
    {
        public TbConstrutor()
        {
            TbObra = new HashSet<TbObra>();
        }

        public int CodConstrutor { get; set; }
        public string NomeConstrutor { get; set; }
        public string CnpjConstrutor { get; set; }
        public string RuaConstrutor { get; set; }
        public string BairroConstrutor { get; set; }
        public string CepConstrutor { get; set; }
        public string NumeroConstrutor { get; set; }
        public string EstadoConstrutor { get; set; }
        public string CidadeConstrutor { get; set; }
        public string TelefoneConstrutor { get; set; }
        public string EmailConstrutor { get; set; }
        public int? DddConstrutor { get; set; }
        public int TbStatusGeralCodStatusGeral { get; set; }

        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
        public ICollection<TbObra> TbObra { get; set; }
    }
}
