using bcquant.Domain.Interfaces;
using bcquant.Models;
using bcquant.Util.ObjetoAuxiliar;
using bcquant.Util.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace bcquant.Domain.Concrete
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        #region Váriaveis
        protected bcquant_localContext context;
        #endregion

        #region Construtor
        public RepositoryBase()
        {
            context = new bcquant_localContext();
        }
        #endregion


        #region ListarTodos
        /// <summary>
        /// Obtém todos os objeto do tipo da Entity da base
        /// </summary>
        /// <param name="pagina">identificação da paginação da pagina</param>
        /// <param name="nrItensPorPagina">Numero de item por pagina</param>
        /// <param name="parametrosFiltro">Parametros para filtro</param>
        /// <returns>Lista da Entity</returns>
        public virtual List<TEntity> ListarTodos(int pagina = 0, int nrItensPorPagina = 0, List<SearchField> parametrosFiltro = null)
        {

            var consulta = from x in context.Set<TEntity>()
                           .OrderBy(x => (true))
                           select x;

            if (parametrosFiltro != null)
            {
                consulta = from f in consulta
                           .Where(this.Filtros(parametrosFiltro))
                           select f;
            }

            if (pagina == 0 && nrItensPorPagina == 0)
            {
                return consulta.ToList();
            }
            else
            {
                return consulta.Skip((pagina - 1) * nrItensPorPagina)
                               .Take(nrItensPorPagina)
                               .ToList();
            }
        }
        #endregion

        #region Quantidade
        /// <summary>
        /// Obtém a quantidade de registos da Entity na base
        /// </summary>
        /// <returns>Quantidade de registros da Entity na base</returns>
        public virtual int Quantidade()
        {
            var consulta = context.Set<TEntity>();

            return consulta.Count();
        }
        #endregion

        #region Inserir
        /// <summary>
        /// Insere um novo Objeto no contexto
        /// </summary>
        /// <param name="entidade">Entidade</param>
        public virtual void Inserir(TEntity entidade)
        {
            context.Set<TEntity>().Add(entidade);
        }
        #endregion

        #region ObterPorChave
        /// <summary>
        /// Obtém uma Entity apartir de sua chave
        /// </summary>
        /// <param name="chave">Chave de identificação da Entity</param>
        /// <returns>Entidade requisitada</returns>
        public virtual TEntity ObterPorChave(int chave)
        {
            var consulta = context.Set<TEntity>().Find(chave);

            return consulta;
        }
        #endregion

        #region Alterar
        /// <summary>
        /// Altera uma Entity no contexto
        /// </summary>
        /// <param name="entidade">Entidade</param>
        public virtual void Alterar(TEntity entidade)
        {
            var entry = context.Entry(entidade);
            context.Set<TEntity>().Attach(entidade);
            entry.State = EntityState.Modified;
        }
        #endregion

        #region Excluir
        /// <summary>
        /// Exclui uma Entity do contexto
        /// </summary>
        /// <param name="chave">Chave de identificação da Entity</param>
        public virtual void Excluir(int chave)
        {
            TEntity entity = ObterPorChave(chave);
            context.Set<TEntity>().Remove(entity);
        }
        #endregion

        #region Salvar
        /// <summary>
        /// Salva as alterações do contexto na base de dados
        /// </summary>
        /// <returns>Numero de linhas afetadas. Se não conseguir executar nada retorna negativo.</returns>
        public virtual int Salvar()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Filtros
        /// <summary>
        /// Gera expressions de Where
        /// </summary>
        /// <param name="parametros">Lista de parametros</param>
        /// <returns>Expressão</returns>
        public virtual Expression<Func<TEntity, bool>> Filtros(List<SearchField> parametros)
        {
            return ExpressionHelper.GenerateWhereExpressions<TEntity>(parametros.ToDictionary(p => p.name, p => p.value));
        }
        #endregion



    }
}
