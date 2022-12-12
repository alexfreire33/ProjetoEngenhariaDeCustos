using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bcquant.Util.ObjetoAuxiliar
{
    public class SearchField
    {
        public const string TYPE_TEXT = "TEXT";
        public const string TYPE_NUMBER = "NUMBER";
        public const string TYPE_REAL = "REAL";
        public const string TYPE_DATE = "DATE";
        public const string TYPE_HIDDEN = "HIDDEN";

        public string label { get; set; }

        public string name { get; set; }

        public string value { get; set; }

        public string type { get; set; }

        public string placeholder { get; set; }

        public string mask { get; set; }

        public bool required { get; set; }
    }
}
