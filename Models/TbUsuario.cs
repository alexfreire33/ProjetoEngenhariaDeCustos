using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbUsuario
    {
        public TbUsuario()
        {
            TbLog = new HashSet<TbLog>();
        }

        public int CodUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
        public DateTime? DataCadastroUsuario { get; set; }
        public int TbStatusGeralCodStatusGeral { get; set; }
        public int TbPerfilCodPerfil { get; set; }

        public TbPerfil TbPerfilCodPerfilNavigation { get; set; }
        public TbStatusGeral TbStatusGeralCodStatusGeralNavigation { get; set; }
        public ICollection<TbLog> TbLog { get; set; }
    }
}
