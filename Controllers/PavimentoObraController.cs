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
    public class PavimentoObraController : Controller
    {
        #region variaveis globais
        private IPavimentoObraRepository _repositoryIPavimentoObra;
        private IPavimentoRepository _repositoryPavimento;
        #endregion

        #region construtor
        public PavimentoObraController(IPavimentoObraRepository repositoryUnidadeConstrutivaObra,
           
              IPavimentoRepository repositoryPavimento)
        {
            this._repositoryIPavimentoObra = repositoryUnidadeConstrutivaObra;
            this._repositoryPavimento = repositoryPavimento;

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

            PavimentoObraModelView model = new PavimentoObraModelView();

            model.pavimentoUcs = _repositoryIPavimentoObra.ListarTodos();
            model.pavimentos = _repositoryPavimento.ListarTodos();

            var json = JsonConvert.SerializeObject(model);

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(PavimentoObraModelView model)
        {
            string resultado = null;
            model.pavimentoUc.TbStatusGeralCodStatusGeral = 1;
            try
            {
                _repositoryIPavimentoObra.Inserir(model.pavimentoUc);
                _repositoryIPavimentoObra.Salvar();


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
        public IActionResult Editar(PavimentoObraModelView model)
        {

            string resultado = null;

            try
            {
                model.pavimentoUc.TbStatusGeralCodStatusGeral = 1;

                _repositoryIPavimentoObra.Alterar(model.pavimentoUc);
                _repositoryIPavimentoObra.Salvar();


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
        public IActionResult Deletar(PavimentoObraModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryIPavimentoObra.Excluir(model.pavimentoUc.CodPavimentoUc);
                _repositoryIPavimentoObra.Salvar();


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