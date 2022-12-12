using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Models;

namespace bcquant.ModelView
{
    public class ObraModelView
    {
        public List<TbObra> obras { get; set; }
        public List<TbConstrutor> construtores { get; set; }
        public List<TbTipologia> tipologias { get; set; }
        public TbObra obra { get; set; }

    }
}
