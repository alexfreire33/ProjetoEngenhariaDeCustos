using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Models;

namespace bcquant.ModelView
{
    public class UnidadeDeMedidaModelView
    {
        public List<TbUnidadeMedida> unidadeDeMedidas { get; set; }
        public TbUnidadeMedida unidadeDeMedida { get; set; }
        public TbStatusGeral statusGeral{ get; set; }

    }
}
