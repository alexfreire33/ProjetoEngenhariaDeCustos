using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbUcObra
    {
        public TbUcObra()
        {
            TbAmbiente = new HashSet<TbAmbiente>();
            TbLevantamento = new HashSet<TbLevantamento>();
            TbPavimentoUc = new HashSet<TbPavimentoUc>();
        }

        public int CodUcObra { get; set; }
        public int? NumeroRepeticoesUc { get; set; }
        public decimal? AreaConstruidaUc { get; set; }
        public int TbStatusGeralCodStatusGeral { get; set; }
        public int TbObraCodObra { get; set; }
        public int TbUnidadeConstrutivaCodUnidadeConstrutiva { get; set; }

        public TbObra TbObraCodObraNavigation { get; set; }
        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
        public TbUnidadeConstrutiva TbUnidadeConstrutivaCodUnidadeConstrutivaNavigation { get; set; }
        public ICollection<TbAmbiente> TbAmbiente { get; set; }
        public ICollection<TbLevantamento> TbLevantamento { get; set; }
        public ICollection<TbPavimentoUc> TbPavimentoUc { get; set; }
    }
}
