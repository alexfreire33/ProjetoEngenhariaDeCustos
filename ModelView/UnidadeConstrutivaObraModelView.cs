using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Models;

namespace bcquant.ModelView
{
    public class UnidadeConstrutivaObraModelView
    {
        public List<TbUcObra> unidadeConstrutivaObras { get; set; }
        public TbUcObra unidadeConstrutivaObra { get; set; }
        public List<TbUnidadeConstrutiva> unidadeConstrutivas { get; set; }
        public List<TbObra> obras { get; set; }

    }
}
