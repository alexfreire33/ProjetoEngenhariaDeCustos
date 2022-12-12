using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Models;

namespace bcquant.ModelView
{
    public class MateriaPrimaModelView
    {
        public List<TbMateriaPrima> materiasPrimas { get; set; }
        public TbMateriaPrima materiaPrima { get; set; }
        public TbStatusGeral statusGeral{ get; set; }

    }
}
