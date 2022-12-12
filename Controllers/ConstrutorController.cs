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
    public class ConstrutorController : Controller
    {
        #region variaveis globais
        private IConstrutorRepository repositoryConstrutor;
        private ILogRepository _repositoryLog;

        #endregion

        #region construtor
        public ConstrutorController(IConstrutorRepository repositoryAmbienteBasico, ILogRepository logRepository )
        {
            this.repositoryConstrutor = repositoryAmbienteBasico;
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

            ConstrutorModelView model = new ConstrutorModelView();

            model.construtores = repositoryConstrutor.ListarTodos();

            var json = JsonConvert.SerializeObject(model.construtores);

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(ConstrutorModelView model)
        {
            model.construtor.CodConstrutor = 0;//aqui é para caso se o valor da primary key vier preenchido ele zera antes de inserir
            model.construtor.TbStatusGeralCodStatusGeral = 1;
            string resultado = null;

            //if (ModelState.IsValid)
            //{
                try
                {
                    repositoryConstrutor.Inserir(model.construtor);
                    repositoryConstrutor.Salvar();


                    resultado = "{\"bool\":\"true\",\"retorno\":\"Processo realizado com sucesso!\"}";

                }
                catch (Exception e)
                {
                    resultado = "{\"bool\":\"false\",\"retorno\":\"Aconteceu algum problema, favor tentar novamente!!\"}";

                }

            //}
            //else
            //{

            //    var errors = ModelState.Select(x => x.Value.Errors)
            //              .Where(y => y.Count > 0)
            //              .ToList();

            //    resultado = "{\"bool\":\"false\",\"retorno\":\"Por favor preencha os campos obrigatórios!!\"}";
            //}

            return Json(resultado);
            
        }

        #endregion

        #region Editar
        [HttpPost]
        public IActionResult Editar(ConstrutorModelView model)
        {

            string resultado = null;

            try
            {
                model.construtor.TbStatusGeralCodStatusGeral = 1;

                repositoryConstrutor.Alterar(model.construtor);
                repositoryConstrutor.Salvar();


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
        public IActionResult Deletar(ConstrutorModelView model)
        {

            string resultado = null;

            try
            {
                repositoryConstrutor.Excluir(model.construtor.CodConstrutor);
                repositoryConstrutor.Salvar();


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