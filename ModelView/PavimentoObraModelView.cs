using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Models;

namespace bcquant.ModelView
{
    public class PavimentoObraModelView
    {
      
        public List<TbPavimentos> pavimentos { get; set; }
        public TbPavimentoUc pavimentoUc { get; set; }
        public List<TbPavimentoUc> pavimentoUcs { get; set; }

    }
}
