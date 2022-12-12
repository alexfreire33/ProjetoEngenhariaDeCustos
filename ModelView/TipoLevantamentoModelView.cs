using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Models;

namespace bcquant.ModelView
{
    public class TipoLevantamentoModelView
    {
        public List<TbTiposLevantamento> tipoLevantamentos { get; set; }
        public TbTiposLevantamento tipoLevantamento { get; set; }
        public TbStatusGeral statusGeral{ get; set; }

    }
}
