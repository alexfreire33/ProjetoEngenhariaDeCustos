using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Models;

namespace bcquant.ModelView
{
    public class AmbienteBasicoModelView
    {
        public List<TbAmbienteBasico> ambienteBasicos { get; set; }
        public TbAmbienteBasico ambienteBasico { get; set; }
        public TbStatusGeral statusGeral{ get; set; }

    }
}
