using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Domain.Interfaces;
using bcquant.ModelView;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace bcquant.Controllers
{
    public class ItensDeLevantamentoController : Controller
    {
        #region variaveis globais
        private IItensDeLevantamentoRepository _repositoryItensDeLevantamento;
        private IGrupoDeInsumoRepository _repositoryGrupoDeInsumo;
        private IUnidadeDeMedidaRepository _repositoryUnidadeDeMedida;

        private ILogRepository _repositoryLog;
             
        #endregion

        #region construtor
        public ItensDeLevantamentoController(IItensDeLevantamentoRepository repositoryItensDeLevantamento, ILogRepository logRepository,
            IGrupoDeInsumoRepository repositoryGrupoDeInsumo, IUnidadeDeMedidaRepository repositoryUnidadeDeMedida)
        {
            this._repositoryItensDeLevantamento = repositoryItensDeLevantamento;
            this._repositoryLog = logRepository;
            this._repositoryGrupoDeInsumo = repositoryGrupoDeInsumo;
            this._repositoryUnidadeDeMedida = repositoryUnidadeDeMedida;

        }
        #endregion

        #region start incial da pagina
        public IActionResult Start()
        {
            return View();
        }

        #endregion

        #region listar
        [HttpPost]
        public IActionResult Listar()
        {

            ItensDeLevantamentoModelView model = new ItensDeLevantamentoModelView();

            model.itensDeLevantamentos = _repositoryItensDeLevantamento.ListarTodos();
            model.grupoDeInsumos = _repositoryGrupoDeInsumo.ListarTodos();
            model.unidadeMedidas = _repositoryUnidadeDeMedida.ListarTodos();

            var json = JsonConvert.SerializeObject(model);

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(ItensDeLevantamentoModelView model)
        {
            model.itensDeLevantamento.CodItensLevantamento  = 0;//aqui é para caso se o valor da primary key vier preenchido ele zera antes de inserir
            model.itensDeLevantamento.TbStatusGeralCodStatusGeral = 1;
            string resultado = null;

            try
            {
                _repositoryItensDeLevantamento.Inserir(model.itensDeLevantamento);
                _repositoryItensDeLevantamento.Salvar();

                
                resultado = "{\"bool\":\"true\",\"retorno\":\"Processo realizado com sucesso!\"}";

            }
            catch (Exception e)
            {
                resultado = "{\"bool\":\"false\",\"retorno\":\"Aconteceu algum problema, favor tentar novamente!!\"}";

            }

            return Json(resultado);
            
        }

        #endregion

        #region Editar
        [HttpPost]
        public IActionResult Editar(ItensDeLevantamentoModelView model)
        {

            string resultado = null;

            try
            {
                model.itensDeLevantamento.TbStatusGeralCodStatusGeral = 1;

                _repositoryItensDeLevantamento.Alterar(model.itensDeLevantamento);
                _repositoryItensDeLevantamento.Salvar();


                resultado = "{\"bool\":\"true\",\"retorno\":\"Processo realizado com sucesso!\"}";

            }
            catch (Exception e)
            {
                resultado = "{\"bool\":\"false\",\"retorno\":\"Aconteceu algum problema, favor tentar novamente!!\"}";

            }

            ViewBag.resultado = "some string";

            return Json(resultado);

        }

        #endregion

        #region Deletar
        [HttpPost]
        public IActionResult Deletar(ItensDeLevantamentoModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryItensDeLevantamento.Excluir(model.itensDeLevantamento.CodItensLevantamento);
                _repositoryItensDeLevantamento.Salvar();


                resultado = "{\"bool\":\"true\",\"retorno\":\"Processo realizado com sucesso!\"}";

            }
            catch (Exception e)
            {
                resultado = "{\"bool\":\"false\",\"retorno\":\"Aconteceu algum problema, favor tentar novamente!!\"}";

            }

            return Json(resultado);
        }


        #endregion

    }
}