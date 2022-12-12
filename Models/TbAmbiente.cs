using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbAmbiente
    {
        public TbAmbiente()
        {
            TbPosicaoAmbiente = new HashSet<TbPosicaoAmbiente>();
        }

        public int CodAmbiente { get; set; }
        public int? NumeroRepeticaoPavimento { get; set; }
        public int? NumeroRepeticaoObra { get; set; }
        public string ObsAmbiente { get; set; }
        public string NomePiso { get; set; }
        public int TbAmbienteBasicoCodAmbienteBasico { get; set; }
        public int TbUcObraCodUcObra { get; set; }
        public int TbPavimentoUcCodPavimentoUc { get; set; }

        [JsonIgnore]
        public TbAmbienteBasico TbAmbienteBasicoCodAmbienteBasicoNavigation { get; set; }
        [JsonIgnore]
        public TbPavimentoUc TbPavimentoUcCodPavimentoUcNavigation { get; set; }
        [JsonIgnore]
        public TbUcObra TbUcObraCodUcObraNavigation { get; set; }
        public ICollection<TbPosicaoAmbiente> TbPosicaoAmbiente { get; set; }
    }
}
