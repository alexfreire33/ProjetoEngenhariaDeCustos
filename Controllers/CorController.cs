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
    public class CorController : Controller
    {
        #region variaveis globais
        private ICorRepository _repositoryCor;
        private ILogRepository _repositoryLog;
         
        #endregion

        #region construtor
        public CorController(ICorRepository repositoryCor, ILogRepository logRepository )
        {
            this._repositoryCor = repositoryCor;
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
            CorModelView model = new CorModelView();

            model.cores  = _repositoryCor.ListarTodos();

            var json = JsonConvert.SerializeObject(model.cores);

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(CorModelView model)
        {
            model.cor.CodCores = 0;//aqui é para caso se o valor da primary key vier preenchido ele zera antes de inserir

            model.cor.TbStatusGeralCodStatusGeral = 1;
            string resultado = null;

            try
            {
                _repositoryCor.Inserir(model.cor);
                _repositoryCor.Salvar();

                
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
        public IActionResult Editar(CorModelView model)
        {

            string resultado = null;

            try
            {
                model.cor.TbStatusGeralCodStatusGeral = 1;

                _repositoryCor.Alterar(model.cor);
                _repositoryCor.Salvar();


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
        public IActionResult Deletar(CorModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryCor.Excluir(model.cor.CodCores);
                _repositoryCor.Salvar();


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