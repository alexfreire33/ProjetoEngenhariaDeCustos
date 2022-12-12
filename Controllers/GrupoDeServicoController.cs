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
    public class GrupoDeServicoController : Controller
    {
        #region variaveis globais
        private IGrupoDeServicoRepository _repositoryGrupoDeServico;
        private ILogRepository _repositoryLog;
            
         
        #endregion

        #region construtor
        public GrupoDeServicoController(IGrupoDeServicoRepository repositoryGrupoDeServico, ILogRepository logRepository )
        {
            this._repositoryGrupoDeServico = repositoryGrupoDeServico;
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

            GrupoDeServicoModelView model = new GrupoDeServicoModelView();

            model.grupoDeServicos = _repositoryGrupoDeServico.ListarTodos();

            var json = JsonConvert.SerializeObject(model.grupoDeServicos);

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(GrupoDeServicoModelView model)
        {
            model.grupoDeServico.CodGrupoServico = 0;//aqui é para caso se o valor da primary key vier preenchido ele zera antes de inserir
            model.grupoDeServico.TbStatusGeralCodStatusGeral = 1;
            string resultado = null;

            try
            {
                _repositoryGrupoDeServico.Inserir(model.grupoDeServico);
                _repositoryGrupoDeServico.Salvar();

                
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
        public IActionResult Editar(GrupoDeServicoModelView model)
        {

            string resultado = null;

            try
            {
                model.grupoDeServico.TbStatusGeralCodStatusGeral = 1;

                _repositoryGrupoDeServico.Alterar(model.grupoDeServico);
                _repositoryGrupoDeServico.Salvar();


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
        public IActionResult Deletar(GrupoDeServicoModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryGrupoDeServico.Excluir(model.grupoDeServico.CodGrupoServico);
                _repositoryGrupoDeServico.Salvar();


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