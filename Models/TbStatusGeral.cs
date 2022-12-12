using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbStatusGeral
    {
        public TbStatusGeral()
        {
            TbAmbienteBasico = new HashSet<TbAmbienteBasico>();
            TbConstrutor = new HashSet<TbConstrutor>();
            TbCores = new HashSet<TbCores>();
            TbFabricantes = new HashSet<TbFabricantes>();
            TbGrupoInsumo = new HashSet<TbGrupoInsumo>();
            TbGrupoServico = new HashSet<TbGrupoServico>();
            TbInsumoBcQuant = new HashSet<TbInsumoBcQuant>();
            TbItensLevantamento = new HashSet<TbItensLevantamento>();
            TbMateriaPrima = new HashSet<TbMateriaPrima>();
            TbObra = new HashSet<TbObra>();
            TbPavimentoUc = new HashSet<TbPavimentoUc>();
            TbPavimentos = new HashSet<TbPavimentos>();
            TbPerfil = new HashSet<TbPerfil>();
            TbPosicao = new HashSet<TbPosicao>();
            TbServicoBc = new HashSet<TbServicoBc>();
            TbTipologia = new HashSet<TbTipologia>();
            TbTiposLevantamento = new HashSet<TbTiposLevantamento>();
            TbUcObra = new HashSet<TbUcObra>();
            TbUnidade = new HashSet<TbUnidade>();
            TbUnidadeConstrutiva = new HashSet<TbUnidadeConstrutiva>();
            TbUnidadeMedida = new HashSet<TbUnidadeMedida>();
            TbUsuario = new HashSet<TbUsuario>();
        }

        public int CodStatusGeral { get; set; }
        public string Nome { get; set; }

        public ICollection<TbAmbienteBasico> TbAmbienteBasico { get; set; }
        public ICollection<TbConstrutor> TbConstrutor { get; set; }
        public ICollection<TbCores> TbCores { get; set; }
        public ICollection<TbFabricantes> TbFabricantes { get; set; }
        public ICollection<TbGrupoInsumo> TbGrupoInsumo { get; set; }
        public ICollection<TbGrupoServico> TbGrupoServico { get; set; }
        public ICollection<TbInsumoBcQuant> TbInsumoBcQuant { get; set; }
        public ICollection<TbItensLevantamento> TbItensLevantamento { get; set; }
        public ICollection<TbMateriaPrima> TbMateriaPrima { get; set; }
        public ICollection<TbObra> TbObra { get; set; }
        public ICollection<TbPavimentoUc> TbPavimentoUc { get; set; }
        public ICollection<TbPavimentos> TbPavimentos { get; set; }
        public ICollection<TbPerfil> TbPerfil { get; set; }
        public ICollection<TbPosicao> TbPosicao { get; set; }
        public ICollection<TbServicoBc> TbServicoBc { get; set; }
        public ICollection<TbTipologia> TbTipologia { get; set; }
        public ICollection<TbTiposLevantamento> TbTiposLevantamento { get; set; }
        public ICollection<TbUcObra> TbUcObra { get; set; }
        public ICollection<TbUnidade> TbUnidade { get; set; }
        public ICollection<TbUnidadeConstrutiva> TbUnidadeConstrutiva { get; set; }
        public ICollection<TbUnidadeMedida> TbUnidadeMedida { get; set; }
        public ICollection<TbUsuario> TbUsuario { get; set; }
    }
}
