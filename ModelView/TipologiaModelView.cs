using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Models;

namespace bcquant.ModelView
{
    public class TipologiaModelView
    {
        public List<TbTipologia> tipologias { get; set; }
        public TbTipologia tipologia { get; set; }
        public TbStatusGeral statusGeral{ get; set; }

    }
}
