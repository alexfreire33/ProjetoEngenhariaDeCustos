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
    public class MateriaPrimaController : Controller
    {
        #region variaveis globais
        private IMateriaPrimaRepository _repositoryMateriaPrima;
        private ILogRepository _repositoryLog;
          
        #endregion

        #region construtor
        public MateriaPrimaController(IMateriaPrimaRepository repositoryMateriaPrima, ILogRepository logRepository )
        {
            this._repositoryMateriaPrima = repositoryMateriaPrima;
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

            MateriaPrimaModelView model = new MateriaPrimaModelView();

            model.materiasPrimas = _repositoryMateriaPrima.ListarTodos();

            var json = JsonConvert.SerializeObject(model.materiasPrimas);

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(MateriaPrimaModelView model)
        {
            model.materiaPrima.CodMateriaPrima = 0;//aqui é para caso se o valor da primary key vier preenchido ele zera antes de inserir
            model.materiaPrima.TbStatusGeralCodStatusGeral = 1;
            string resultado = null;

            try
            {
                _repositoryMateriaPrima.Inserir(model.materiaPrima);
                _repositoryMateriaPrima.Salvar();

                
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
        public IActionResult Editar(MateriaPrimaModelView model)
        {

            string resultado = null;

            try
            {
                model.materiaPrima.TbStatusGeralCodStatusGeral = 1;

                _repositoryMateriaPrima.Alterar(model.materiaPrima);
                _repositoryMateriaPrima.Salvar();


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
        public IActionResult Deletar(MateriaPrimaModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryMateriaPrima.Excluir(model.materiaPrima.CodMateriaPrima);
                _repositoryMateriaPrima.Salvar();


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