using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbInsumoBcQuant
    {
        public int CodInsumoBcQuant { get; set; }
        public string NomeInsumoBcQuant { get; set; }
        public string ObservacaoInsumoBcQuant { get; set; }
        public string CodigoInternoInsumoBcQuant { get; set; }
        public decimal? Peso { get; set; }
        public string ImagemInsumo { get; set; }
        public DateTime? DataCadastroInsumoBc { get; set; }
        public int? TbItensLevantamentoCodItensLevantamento { get; set; }
        public int? TbMateriaPrimaCodMateriaPrima { get; set; }
        public int? TbCoresCodCores { get; set; }
        public int? TbFabricantesCodFabricantes { get; set; }
        public int? TbUnidadeMedidaCodUnidadeMedida { get; set; }
        public int? TbStatusGeralCodStatusGeral { get; set; }
        public int? TbPosicaoCodPosicao { get; set; }

        public TbFabricantes TbFabricantesCodFabricantesNavigation { get; set; }
        public TbItensLevantamento TbItensLevantamentoCodItensLevantamentoNavigation { get; set; }
        public TbMateriaPrima TbMateriaPrimaCodMateriaPrimaNavigation { get; set; }
        public TbPosicao TbPosicaoCodPosicaoNavigation { get; set; }
        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
        public TbUnidadeMedida TbUnidadeMedidaCodUnidadeMedidaNavigation { get; set; }
    }
}
