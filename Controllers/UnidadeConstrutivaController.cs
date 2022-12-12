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
    public class UnidadeConstrutivaController : Controller
    {
        #region variaveis globais
        private IUnidadeConstrutivaRepository _repositoryUnidadeConstrutiva;
        private ILogRepository _repositoryLog;

        #endregion

        #region construtor
        public UnidadeConstrutivaController(IUnidadeConstrutivaRepository repositoryUnidadeConstrutiva,ILogRepository logRepository )
        {
            this._repositoryUnidadeConstrutiva = repositoryUnidadeConstrutiva;
            this._repositoryLog = logRepository;

        }
        #endregion

        #region start incial da pagina
        public IActionResult Start()
        {
            //UnidadeConstrutivaModelView model = new UnidadeConstrutivaModelView();

            return View();
        }

        #endregion

        #region listar
        [HttpPost]
        public IActionResult Listar()
        {

            UnidadeConstrutivaModelView model = new UnidadeConstrutivaModelView();

            model.unidadeConstrutivas = _repositoryUnidadeConstrutiva.ListarTodos();

            var json = JsonConvert.SerializeObject(model.unidadeConstrutivas, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(UnidadeConstrutivaModelView model)
        {

            model.unidadeConstrutiva.CodUnidadeConstrutiva = 0;//aqui é para caso se o valor da primary key vier preenchido ele zera antes de inserir
            model.unidadeConstrutiva.TbStatusGeralCodStatusGeral = 1;
            string resultado = null;

            try
            {
                _repositoryUnidadeConstrutiva.Inserir(model.unidadeConstrutiva);
                _repositoryUnidadeConstrutiva.Salvar();

                
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
        public IActionResult Editar(UnidadeConstrutivaModelView model)
        {

            string resultado = null;

            try
            {
                model.unidadeConstrutiva.TbStatusGeralCodStatusGeral = 1;

                _repositoryUnidadeConstrutiva.Alterar(model.unidadeConstrutiva);
                _repositoryUnidadeConstrutiva.Salvar();


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
        public IActionResult Deletar(UnidadeConstrutivaModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryUnidadeConstrutiva.Excluir(model.unidadeConstrutiva.CodUnidadeConstrutiva);
                _repositoryUnidadeConstrutiva.Salvar();


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