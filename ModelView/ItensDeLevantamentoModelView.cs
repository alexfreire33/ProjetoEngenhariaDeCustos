using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Models;

namespace bcquant.ModelView
{
    public class ItensDeLevantamentoModelView
    {
        public List<TbItensLevantamento> itensDeLevantamentos { get; set; }
        public TbItensLevantamento itensDeLevantamento { get; set; }
        public TbStatusGeral statusGeral{ get; set; }
        public List<TbGrupoInsumo> grupoDeInsumos { get; set; }
        public List<TbUnidadeMedida> unidadeMedidas { get; set; }

    }
}
