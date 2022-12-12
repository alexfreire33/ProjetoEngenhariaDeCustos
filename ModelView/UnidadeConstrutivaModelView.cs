using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Models;

namespace bcquant.ModelView
{
    public class UnidadeConstrutivaModelView
    {
        public List<TbUnidadeConstrutiva> unidadeConstrutivas { get; set; }
        public TbUnidadeConstrutiva unidadeConstrutiva { get; set; }
        public TbPerfil perfil{ get; set; }

    }
}
