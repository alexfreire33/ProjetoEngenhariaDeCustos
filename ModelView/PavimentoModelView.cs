using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Models;

namespace bcquant.ModelView
{
    public class PavimentoModelView
    {
        public List<TbPavimentos> pavimentos { get; set; }
        public TbPavimentos pavimento { get; set; }
        public TbStatusGeral statusGeral{ get; set; }

    }
}
