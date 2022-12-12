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
    public class PavimentoController : Controller
    {
        #region variaveis globais
        private IPavimentoRepository _repositoryPavimento;
        private ILogRepository _repositoryLog;

        #endregion

        #region construtor
        public PavimentoController(IPavimentoRepository repositoryPavimento, ILogRepository logRepository)
        {
            this._repositoryPavimento = repositoryPavimento;
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
            string json = "";

            try
            {
                PavimentoModelView model = new PavimentoModelView();

                model.pavimentos = _repositoryPavimento.ListarTodos();

                json = JsonConvert.SerializeObject(model.pavimentos, Formatting.None,
                    new JsonSerializerSettings()
                    {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            }
            catch (Exception e)
            {
                var x = e;
            }

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(PavimentoModelView model)
        {
            model.pavimento.CodPavimentos = 0;//aqui é para caso se o valor da primary key vier preenchido ele zera antes de inserir
            model.pavimento.TbStatusGeralCodStatusGeral = 1;
            string resultado = null;

            try
            {
                _repositoryPavimento.Inserir(model.pavimento);
                _repositoryPavimento.Salvar();


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
        public IActionResult Editar(PavimentoModelView model)
        {

            string resultado = null;

            try
            {
                model.pavimento.TbStatusGeralCodStatusGeral = 1;

                _repositoryPavimento.Alterar(model.pavimento);
                _repositoryPavimento.Salvar();


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
        public IActionResult Deletar(PavimentoModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryPavimento.Excluir(model.pavimento.CodPavimentos);
                _repositoryPavimento.Salvar();


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