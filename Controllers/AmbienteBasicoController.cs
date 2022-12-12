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
    public class AmbienteBasicoController : Controller
    {
        #region variaveis globais
        private IAmbienteBasicoRepository _repositoryAmbienteBasico;
        private ILogRepository _repositoryLog;

        #endregion

        #region construtor
        public AmbienteBasicoController(IAmbienteBasicoRepository repositoryAmbienteBasico, ILogRepository logRepository )
        {
            this._repositoryAmbienteBasico = repositoryAmbienteBasico;
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

            AmbienteBasicoModelView model = new AmbienteBasicoModelView();

            model.ambienteBasicos = _repositoryAmbienteBasico.ListarTodos();

            var json = JsonConvert.SerializeObject(model.ambienteBasicos);

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(AmbienteBasicoModelView model)
        {
            model.ambienteBasico.CodAmbienteBasico = 0;//aqui é para caso se o valor da primary key vier preenchido ele zera antes de inserir
            model.ambienteBasico.TbStatusGeralCodStatusGeral = 1;

            string resultado = null;

            try
            {
                _repositoryAmbienteBasico.Inserir(model.ambienteBasico);
                _repositoryAmbienteBasico.Salvar();

                
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
        public IActionResult Editar(AmbienteBasicoModelView model)
        {

            string resultado = null;
            model.ambienteBasico.TbStatusGeralCodStatusGeral = 1;

            try
            {
                _repositoryAmbienteBasico.Alterar(model.ambienteBasico);
                _repositoryAmbienteBasico.Salvar();


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
        public IActionResult Deletar(AmbienteBasicoModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryAmbienteBasico.Excluir(model.ambienteBasico.CodAmbienteBasico);
                _repositoryAmbienteBasico.Salvar();


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