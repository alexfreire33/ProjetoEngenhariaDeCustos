using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Models;

namespace bcquant.ModelView
{
    public class GrupoDeInsumoModelView
    {
   
        public List<TbGrupoInsumo> grupoDeInsumos { get; set; }
        public TbGrupoInsumo grupoDeInsumo { get; set; }
        public TbStatusGeral statusGeral { get; set; }
    }
}
