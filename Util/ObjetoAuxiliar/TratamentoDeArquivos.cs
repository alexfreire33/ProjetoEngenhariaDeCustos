using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bcquant.Util.ObjetoAuxiliar
{
    public class TratamentoDeArquivos
    {

        public static bool VerificaExtensao (string [] extensoesPermitidas,string extensao_do_arquivo)
        {
            bool isValidFile = false;

            for (int i = 0; i < extensoesPermitidas.Length; i++)
            {
                if (extensao_do_arquivo.ToUpper() == "." + extensoesPermitidas[i].ToUpper())
                {
                    isValidFile = true;
                    break;

                }

            }

            return isValidFile;

        }


    }
}
