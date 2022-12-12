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
    public class UnidadeDeMedidaController : Controller
    {
        #region variaveis globais
        private IUnidadeDeMedidaRepository _repositoryUnidadeDeMedida;
        private ILogRepository _repositoryLog;
             
        #endregion

        #region construtor
        public UnidadeDeMedidaController(IUnidadeDeMedidaRepository repositoryUnidadeDeMedida, ILogRepository logRepository )
        {
            this._repositoryUnidadeDeMedida = repositoryUnidadeDeMedida;
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

            UnidadeDeMedidaModelView model = new UnidadeDeMedidaModelView();

            model.unidadeDeMedidas = _repositoryUnidadeDeMedida.ListarTodos();

            var json = JsonConvert.SerializeObject(model.unidadeDeMedidas);

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(UnidadeDeMedidaModelView model)
        {
            model.unidadeDeMedida.CodUnidadeMedida = 0;//aqui é para caso se o valor da primary key vier preenchido ele zera antes de inserir
            model.unidadeDeMedida.TbStatusGeralCodStatusGeral = 1;
            string resultado = null;

            try
            {
                _repositoryUnidadeDeMedida.Inserir(model.unidadeDeMedida);
                _repositoryUnidadeDeMedida.Salvar();

                
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
        public IActionResult Editar(UnidadeDeMedidaModelView model)
        {

            string resultado = null;

            try
            {
                model.unidadeDeMedida.TbStatusGeralCodStatusGeral = 1;

                _repositoryUnidadeDeMedida.Alterar(model.unidadeDeMedida);
                _repositoryUnidadeDeMedida.Salvar();


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
        public IActionResult Deletar(UnidadeDeMedidaModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryUnidadeDeMedida.Excluir(model.unidadeDeMedida.CodUnidadeMedida);
                _repositoryUnidadeDeMedida.Salvar();


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