using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbObra
    {
        public TbObra()
        {
            TbLevantamento = new HashSet<TbLevantamento>();
            TbUcObra = new HashSet<TbUcObra>();
        }

        public int CodObra { get; set; }
        public string NomeObra { get; set; }
        public string EstadoObra { get; set; }
        public string CidadeObra { get; set; }
        public string RuaObra { get; set; }
        public string BairroObra { get; set; }
        public string NumeroObra { get; set; }
        public string DescricaoObra { get; set; }
        public int? AreaConstruida { get; set; }
        public string Cep { get; set; }
        public int TbConstrutorCodConstrutor { get; set; }
        public int TbTipologiaCodTipologia { get; set; }
        public int TbStatusGeralCodStatusGeral { get; set; }

        public TbConstrutor TbConstrutorCodConstrutorNavigation { get; set; }
        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
        public TbTipologia TbTipologiaCodTipologiaNavigation { get; set; }
        public ICollection<TbLevantamento> TbLevantamento { get; set; }
        public ICollection<TbUcObra> TbUcObra { get; set; }
    }
}
