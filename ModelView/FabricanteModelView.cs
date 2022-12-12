using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Models;

namespace bcquant.ModelView
{
    public class FabricanteModelView
    {
        public List<TbFabricantes> fabricantes { get; set; }
        public TbFabricantes fabricante { get; set; }
        public TbStatusGeral statusGeral{ get; set; }

    }
}
