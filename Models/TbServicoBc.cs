using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbServicoBc
    {
        public int CodServicoBc { get; set; }
        public string CodigoInternoServicoBc { get; set; }
        public string DescricaoServicoBc { get; set; }
        public string ObservacaoServicoBc { get; set; }
        public int TbGrupoServicoCodGrupoServico { get; set; }
        public int TbUnidadeMedidaCodUnidadeMedida { get; set; }
        public int TbPosicaoCodPosicao { get; set; }
        public int TbStatusGeralCodStatusGeral { get; set; }

        public TbGrupoServico TbGrupoServicoCodGrupoServicoNavigation { get; set; }
        public TbPosicao TbPosicaoCodPosicaoNavigation { get; set; }
        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
        public TbUnidadeMedida TbUnidadeMedidaCodUnidadeMedidaNavigation { get; set; }
    }
}
