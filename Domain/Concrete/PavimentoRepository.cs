using bcquant.Domain.Interfaces;
using bcquant.Models;
using bcquant.Util.ObjetoAuxiliar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bcquant.Domain.Concrete
{
    public class PavimentoRepository : RepositoryBase<TbPavimentos>, IPavimentoRepository
    {

        #region Listar com include

        public override List<TbPavimentos> ListarTodos(int pagina = 0, int nrItensPorPagina = 0, List<SearchField> parametrosFiltro = null)
        {

            var consulta = from i in context.TbPavimentos.Include(u => u.TbPavimentoUc)
                           where i.TbPavimentoUc.Any(t => t.TbPavimentosCodPavimentos == i.CodPavimentos)
                           select i;

            try
            {


                if (parametrosFiltro != null)
                {
                    //consulta = from f in consulta
                    //           .Where(base.Filtros(parametrosFiltro))
                    //           select f;
                }

                if (pagina == 0 && nrItensPorPagina == 0)
                {

                    var s = consulta.ToList();
                    return s;
                }
                else
                {
                    return consulta.Skip((pagina - 1) * nrItensPorPagina)
                                       .Take(nrItensPorPagina)
                                       .ToList();
                }
            }
            catch (Exception e)
            {
                var s = e;

                return consulta.ToList();
            }
        }
        #endregion

    }
}
