using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Models;

namespace bcquant.ModelView
{
    public class GrupoDeServicoModelView
    {
        public List<TbGrupoServico> grupoDeServicos { get; set; }
        public TbGrupoServico grupoDeServico { get; set; }
        public TbStatusGeral statusGeral{ get; set; }

    }
}
