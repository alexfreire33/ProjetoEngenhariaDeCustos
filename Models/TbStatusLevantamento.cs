using System;
using System.Collections.Generic;

namespace bcquant.Models
{
    public partial class TbStatusLevantamento
    {
        public TbStatusLevantamento()
        {
            TbLevantamento = new HashSet<TbLevantamento>();
        }

        public int CodStatusLevantamento { get; set; }
        public string NomeStatusLevantamento { get; set; }

        public ICollection<TbLevantamento> TbLevantamento { get; set; }
    }
}
