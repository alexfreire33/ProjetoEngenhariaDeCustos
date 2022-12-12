using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Models;
using Microsoft.AspNetCore.Mvc;

namespace bcquant.ModelView
{
    public class AmbienteModelView
    {
       
        public List<TbAmbiente> ambientes { get; set; }
       
        public TbAmbiente ambiente { get; set; }
       
        public List<TbUcObra> unidadeConstrutivaObras { get; set; }
       
        public List<TbObra> obras { get; set; }
       
        public List<TbAmbienteBasico> ambienteBasicos { get; set; }
       
        public List<TbPavimentos> pavimentos { get; set; }
       
        public List<TbUnidadeConstrutiva> unidadeConstrutivas { get; set; }
       
        public List<TbCores> cores { get; set; }
       
        public TbPosicaoAmbiente posicaoAmbiente { get; set; }

    }
}
