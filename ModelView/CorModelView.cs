using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Models;

namespace bcquant.ModelView
{
    public class CorModelView
    {
        public List<TbCores> cores { get; set; }
        public TbCores cor { get; set; }
        public TbStatusGeral statusGeral{ get; set; }

    }
}
