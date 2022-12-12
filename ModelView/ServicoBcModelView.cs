using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Models;

namespace bcquant.ModelView
{
    public class ServicoBcModelView
    {
        public List<TbServicoBc> servicoBcs { get; set; }
        public TbServicoBc servicoBc { get; set; }
        public TbStatusGeral statusGeral{ get; set; }
        public List<TbGrupoServico> grupoDeServicos { get; set; }
        public List<TbPosicao> posicoes { get; set; }
        public List<TbUnidadeMedida> unidadeMedidas { get; set; }
        
    }
}
