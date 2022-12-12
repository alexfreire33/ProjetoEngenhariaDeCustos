using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Models;
using Microsoft.AspNetCore.Http;

namespace bcquant.ModelView
{
    public class LevantamentoModelView
    {
        public List<TbLevantamento> levantamentos { get; set; }
        public TbLevantamento levantamento { get; set; }
        public List<TbTiposLevantamento> tiposLevantamentos { get; set; }
        public List<TbObra> obras { get; set; }
        public List<TbUcObra> ucObras { get; set; }
        public List<TbStatusLevantamento> statusLevantamentos { get; set; }
        public IFormFile arquivoImg { get; set; }
    }
}
