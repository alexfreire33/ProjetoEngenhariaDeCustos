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
    public class ObraController : Controller
    {
        #region variaveis globais
        private IObraRepository _repositoryObra;
        private ILogRepository _repositoryLog;
        private IConstrutorRepository _repositoryConstrutor;
        private ITipologiaRepository _repositoryTipologia;


        #endregion

        #region construtor
        public ObraController(IObraRepository repositoryObra,
                            IConstrutorRepository repositoryConstrutor,
                            ITipologiaRepository repositoryTipologia,
                            ILogRepository logRepository
            )
        {
            this._repositoryObra = repositoryObra;
            this._repositoryLog = logRepository;
            this._repositoryConstrutor = repositoryConstrutor;
            this._repositoryTipologia = repositoryTipologia;
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

            ObraModelView model = new ObraModelView();

            model.obras = _repositoryObra.ListarTodos();
            model.construtores = _repositoryConstrutor.ListarTodos();
            model.tipologias = _repositoryTipologia.ListarTodos();

            var json = JsonConvert.SerializeObject(model);

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(ObraModelView model)
        {

            string resultado = null;

            try
            {
                model.obra.TbStatusGeralCodStatusGeral = 1;
                _repositoryObra.Inserir(model.obra);
                _repositoryObra.Salvar();


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
        public IActionResult Editar(ObraModelView model)
        {

            string resultado = null;

            try
            {
                model.obra.TbStatusGeralCodStatusGeral = 1;

                _repositoryObra.Alterar(model.obra);
                _repositoryObra.Salvar();


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
        public IActionResult Deletar(ObraModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryObra.Excluir(model.obra.CodObra);
                _repositoryObra.Salvar();


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