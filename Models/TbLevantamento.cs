using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbLevantamento
    {
        public int CodLevantamento { get; set; }
        public string NomeResponsavel { get; set; }
        public string EmailResponsavel { get; set; }
        public string TelefoneResponsavel { get; set; }
        public DateTime? DataInicioLevantamento { get; set; }
        public DateTime? DataConclusaoLevantamento { get; set; }
        public DateTime? DataAtualizacaoLevantamento { get; set; }
        public string NumeroVersaoLevantamento { get; set; }
        public string UrlArquivoLevantamento { get; set; }
        public string ObservacaoLevantamento { get; set; }
        public int TbTiposLevantamentoCodTiposLevantamento { get; set; }
        public int TbObraCodObra { get; set; }
        public int TbUcObraCodUcObra { get; set; }
        public int TbStatusLevantamentoCodStatusLevantamento { get; set; }

        public TbObra TbObraCodObraNavigation { get; set; }
        public TbStatusLevantamento TbStatusLevantamentoCodStatusLevantamentoNavigation { get; set; }
        public TbTiposLevantamento TbTiposLevantamentoCodTiposLevantamentoNavigation { get; set; }
        public TbUcObra TbUcObraCodUcObraNavigation { get; set; }
    }
}
