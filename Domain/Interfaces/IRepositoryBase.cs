using bcquant.Util.ObjetoAuxiliar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bcquant.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {

        #region ListarTodos
        /// <summary>
        /// Obtém todos os objeto do tipo da Entity da base
        /// </summary>
        /// <param name="pagina">identificação da paginação da pagina</param>
        /// <param name="nrItensPorPagina">Numero de item por pagina</param>
        /// <param name="parametrosFiltro">Parametros para filtro</param>
        /// <returns>Lista da Entity</returns>
        List<TEntity> ListarTodos(int pagina = 0, int nrItensPorPagina = 0, List<SearchField> parametrosFiltro = null);
        #endregion

        #region Quantidade
        /// <summary>
        /// Obtém a quantidade de registos da Entity na base
        /// </summary>
        /// <returns>Quantidade de registros da Entity na base</returns>
        int Quantidade();
        #endregion

        #region Inserir
        /// <summary>
        /// Insere um novo Objeto no contexto
        /// </summary>
        /// <param name="entidade">Entidade</param>
        void Inserir(TEntity entidade);
        #endregion

        #region ObterPorChave
        /// <summary>
        /// Obtém uma Entity apartir de sua chave
        /// </summary>
        /// <param name="chave">Chave de identificação da Entity</param>
        /// <returns>Entidade requisitada</returns>
        TEntity ObterPorChave(int chave);
        #endregion

        #region Alterar
        /// <summary>
        /// Altera uma Entity no contexto
        /// </summary>
        /// <param name="entidade">Entidade</param>
        void Alterar(TEntity entidade);
        #endregion

        #region Excluir
        /// <summary>
        /// Exclui uma Entity do contexto
        /// </summary>
        /// <param name="chave">Chave de identificação da Entity</param>
        void Excluir(int chave);
        #endregion

        #region Salvar
        /// <summary>
        /// Salva as alterações do contexto na base de dados
        /// </summary>
        /// <returns>Numero de linhas afetadas. Se não conseguir executar nada retorna negativo.</returns>
        int Salvar();
        #endregion


    }
}
