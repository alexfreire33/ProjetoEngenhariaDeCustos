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
    public class TipoLevantamentoController : Controller
    {
        #region variaveis globais
        private ITipoLevantamentoRepository _repositoryTipoLevantamento;
        private ILogRepository _repositoryLog;
             
        #endregion

        #region construtor
        public TipoLevantamentoController(ITipoLevantamentoRepository repositoryTipoLevantamento, ILogRepository logRepository )
        {
            this._repositoryTipoLevantamento = repositoryTipoLevantamento;
            this._repositoryLog = logRepository;
                       
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

            TipoLevantamentoModelView model = new TipoLevantamentoModelView();

            model.tipoLevantamentos = _repositoryTipoLevantamento.ListarTodos();

            var json = JsonConvert.SerializeObject(model.tipoLevantamentos);

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(TipoLevantamentoModelView model)
        {
            model.tipoLevantamento.CodTiposLevantamento = 0;//aqui é para caso se o valor da primary key vier preenchido ele zera antes de inserir
            model.tipoLevantamento.TbStatusGeralCodStatusGeral = 1;
            string resultado = null;

            try
            {
                _repositoryTipoLevantamento.Inserir(model.tipoLevantamento);
                _repositoryTipoLevantamento.Salvar();

                
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
        public IActionResult Editar(TipoLevantamentoModelView model)
        {

            string resultado = null;

            try
            {
                model.tipoLevantamento.TbStatusGeralCodStatusGeral = 1;

                _repositoryTipoLevantamento.Alterar(model.tipoLevantamento);
                _repositoryTipoLevantamento.Salvar();


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
        public IActionResult Deletar(TipoLevantamentoModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryTipoLevantamento.Excluir(model.tipoLevantamento.CodTiposLevantamento);
                _repositoryTipoLevantamento.Salvar();


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