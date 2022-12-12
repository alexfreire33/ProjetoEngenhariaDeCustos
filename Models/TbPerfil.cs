using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbPerfil
    {
        public TbPerfil()
        {
            InverseTbPerfilCodPerfilNavigation = new HashSet<TbPerfil>();
            TbPerfilHasTbTransacao = new HashSet<TbPerfilHasTbTransacao>();
            TbUsuario = new HashSet<TbUsuario>();
        }

        public int CodPerfil { get; set; }
        public string Nome { get; set; }
        public string Master { get; set; }
        public int TbPerfilCodPerfil { get; set; }
        public int TbStatusGeralCodStatusGeral { get; set; }

        public TbPerfil TbPerfilCodPerfilNavigation { get; set; }
        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
        public ICollection<TbPerfil> InverseTbPerfilCodPerfilNavigation { get; set; }
        public ICollection<TbPerfilHasTbTransacao> TbPerfilHasTbTransacao { get; set; }
        public ICollection<TbUsuario> TbUsuario { get; set; }
    }
}
