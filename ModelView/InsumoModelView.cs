using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Models;
using Microsoft.AspNetCore.Http;

namespace bcquant.ModelView
{
    public class InsumoModelView
    {
        public List<TbInsumoBcQuant> insumos { get; set; }
        public TbInsumoBcQuant insumo { get; set; }
        public TbStatusGeral statusGeral{ get; set; }
        public List<TbUnidadeMedida> unidadeMedidas { get; set; }
        public List<TbItensLevantamento> itensLevantamentos { get; set; }
        public List<TbMateriaPrima> materiaPrimas { get; set; }
        public List<TbCores> cores { get; set; }
        public List<TbFabricantes> fabricantes { get; set; }
        public List<TbPosicao> posicoes { get; set; }
        public IFormFile arquivoImg { get; set; }
    }
}
