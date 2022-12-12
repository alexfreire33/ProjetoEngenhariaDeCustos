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
    public class PosicaoController : Controller
    {
        #region variaveis globais
        private IPosicaoRepository _repositoryPosicao;
        private ILogRepository _repositoryLog;
           
        #endregion

        #region construtor
        public PosicaoController(IPosicaoRepository repositoryPosicao, ILogRepository logRepository )
        {
            this._repositoryPosicao = repositoryPosicao;
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

            PosicaoModelView model = new PosicaoModelView();

            model.posicoes = _repositoryPosicao.ListarTodos();

            //var json = JsonConvert.SerializeObject(model.posicoes);


            var json = JsonConvert.SerializeObject(model.posicoes, Formatting.None,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(PosicaoModelView model)
        {
            model.posicao.CodPosicao = 0;//aqui é para caso se o valor da primary key vier preenchido ele zera antes de inserir
            model.posicao.TbStatusGeralCodStatusGeral = 1;

            string resultado = null;

            try
            {
                _repositoryPosicao.Inserir(model.posicao);
                _repositoryPosicao.Salvar();

                
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
        public IActionResult Editar(PosicaoModelView model)
        {

            string resultado = null;

            try
            {
                model.posicao.TbStatusGeralCodStatusGeral = 1;


                _repositoryPosicao.Alterar(model.posicao);
                _repositoryPosicao.Salvar();


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
        public IActionResult Deletar(PosicaoModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryPosicao.Excluir(model.posicao.CodPosicao);
                _repositoryPosicao.Salvar();


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