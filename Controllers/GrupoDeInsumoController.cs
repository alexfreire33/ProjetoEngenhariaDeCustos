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
    public class GrupoDeInsumoController : Controller
    {
        #region variaveis globais
        private IGrupoDeInsumoRepository _repositoryGrupoDeInsumo;
        private ILogRepository _repositoryLog;
             
        #endregion

        #region construtor
        public GrupoDeInsumoController(IGrupoDeInsumoRepository repositoryGrupoDeInsumo, ILogRepository logRepository )
        {
            this._repositoryGrupoDeInsumo = repositoryGrupoDeInsumo;
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

            GrupoDeInsumoModelView model = new GrupoDeInsumoModelView();

            model.grupoDeInsumos = _repositoryGrupoDeInsumo.ListarTodos();

            var json = JsonConvert.SerializeObject(model.grupoDeInsumos);

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(GrupoDeInsumoModelView model)
        {
            model.grupoDeInsumo.CodGrupoInsumo = 0;//aqui é para caso se o valor da primary key vier preenchido ele zera antes de inserir
            model.grupoDeInsumo.TbStatusGeralCodStatusGeral = 1;
            string resultado = null;

            try
            {
                _repositoryGrupoDeInsumo.Inserir(model.grupoDeInsumo);
                _repositoryGrupoDeInsumo.Salvar();

                
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
        public IActionResult Editar(GrupoDeInsumoModelView model)
        {

            string resultado = null;
            model.grupoDeInsumo.TbStatusGeralCodStatusGeral = 1;

            try
            {
                _repositoryGrupoDeInsumo.Alterar(model.grupoDeInsumo);
                _repositoryGrupoDeInsumo.Salvar();


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
        public IActionResult Deletar(GrupoDeInsumoModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryGrupoDeInsumo.Excluir(model.grupoDeInsumo.CodGrupoInsumo);
                _repositoryGrupoDeInsumo.Salvar();


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