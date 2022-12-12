using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbTransacao
    {
        public TbTransacao()
        {
            TbPerfilHasTbTransacao = new HashSet<TbPerfilHasTbTransacao>();
        }

        public int CodTransacao { get; set; }
        public string Sigla { get; set; }
        public string Url { get; set; }
        public string Menu { get; set; }
        public int? IdMenu { get; set; }
        public string Icone { get; set; }
        public string Acao { get; set; }

        public ICollection<TbPerfilHasTbTransacao> TbPerfilHasTbTransacao { get; set; }
    }
}
