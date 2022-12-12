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
    public class FabricanteController : Controller
    {
        #region variaveis globais
        private IFabricanteRepository _repositoryFabricante;
        private ILogRepository _repositoryLog;
          
        #endregion

        #region construtor
        public FabricanteController(IFabricanteRepository repositoryFabricante, ILogRepository logRepository )
        {
            this._repositoryFabricante = repositoryFabricante;
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

            FabricanteModelView model = new FabricanteModelView();

            model.fabricantes = _repositoryFabricante.ListarTodos();

            var json = JsonConvert.SerializeObject(model.fabricantes);

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(FabricanteModelView model)
        {
            model.fabricante.CodFabricantes = 0;//aqui é para caso se o valor da primary key vier preenchido ele zera antes de inserir
                                                // model.fabricante.TbStatusGeralCodStatusGeral = 2;//aqui é para caso se o valor da primary key vier preenchido ele zera antes de inserir
            model.fabricante.TbStatusGeralCodStatusGeral = 1;
            string resultado = null;

            try
            {
                _repositoryFabricante.Inserir(model.fabricante);
                _repositoryFabricante.Salvar();

                
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
        public IActionResult Editar(FabricanteModelView model)
        {

            string resultado = null;

            try
            {
                model.fabricante.TbStatusGeralCodStatusGeral = 1;

                _repositoryFabricante.Alterar(model.fabricante);
                _repositoryFabricante.Salvar();


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
        public IActionResult Deletar(FabricanteModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryFabricante.Excluir(model.fabricante.CodFabricantes);
                _repositoryFabricante.Salvar();


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