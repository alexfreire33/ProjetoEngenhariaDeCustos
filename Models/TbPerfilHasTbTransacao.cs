using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbPerfilHasTbTransacao
    {
        public int TbPerfilCodPerfil { get; set; }
        public int TbTransacaoCodTransacao { get; set; }
        public int? Ordem { get; set; }

        public TbPerfil TbPerfilCodPerfilNavigation { get; set; }
        public TbTransacao TbTransacaoCodTransacaoNavigation { get; set; }
    }
}
