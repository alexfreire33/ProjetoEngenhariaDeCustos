using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbPosicaoAmbiente
    {
        public int CodPosicaoAmbiente { get; set; }
        public string Posicao { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public decimal? PerimetroDoAmbiente { get; set; }
        public decimal? PerimetroDaObra { get; set; }
        public decimal? Largura { get; set; }
        public decimal? Comprimento { get; set; }
        public decimal? ComprimentoADescontar { get; set; }
        public decimal? AreaDoAmbiente { get; set; }
        public decimal? AreaDaObra { get; set; }
        public decimal? AreaADescontar { get; set; }
        public decimal? Descontos { get; set; }
        public decimal? PeDireito { get; set; }
        public int TbAmbienteCodAmbiente { get; set; }

        [JsonIgnore]
        public TbAmbiente TbAmbienteCodAmbienteNavigation { get; set; }
    }
}
