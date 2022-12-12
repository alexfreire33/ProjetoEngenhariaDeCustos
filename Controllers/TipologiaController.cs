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
    public class TipologiaController : Controller
    {
        #region variaveis globais
        private ITipologiaRepository _repositoryTipologia;
        private ILogRepository _repositoryLog;
            
        #endregion

        #region construtor
        public TipologiaController(ITipologiaRepository repositoryTipologia, ILogRepository logRepository )
        {
            this._repositoryTipologia = repositoryTipologia;
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

            TipologiaModelView model = new TipologiaModelView();

            model.tipologias = _repositoryTipologia.ListarTodos();

            var json = JsonConvert.SerializeObject(model.tipologias);

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(TipologiaModelView model)
        {
            model.tipologia.CodTipologia = 0;//aqui é para caso se o valor da primary key vier preenchido ele zera antes de inserir
            model.tipologia.TbStatusGeralCodStatusGeral = 1;
            string resultado = null;

            try
            {
                _repositoryTipologia.Inserir(model.tipologia);
                _repositoryTipologia.Salvar();

                
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
        public IActionResult Editar(TipologiaModelView model)
        {

            string resultado = null;

            try
            {
                model.tipologia.TbStatusGeralCodStatusGeral = 1;

                _repositoryTipologia.Alterar(model.tipologia);
                _repositoryTipologia.Salvar();


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
        public IActionResult Deletar(TipologiaModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryTipologia.Excluir(model.tipologia.CodTipologia);
                _repositoryTipologia.Salvar();


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