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
    public class UnidadeConstrutivaObraController : Controller
    {
        #region variaveis globais
        private IUnidadeConstrutivaObraRepository _repositoryUnidadeConstrutivaObra;
        private ILogRepository _repositoryLog;
        private IUnidadeConstrutivaRepository _repositoryUnidadeConstrutiva;
        private IObraRepository _repositoryObraRepository;
        private IPavimentoRepository _repositoryPavimento;

        #endregion

        #region construtor
        public UnidadeConstrutivaObraController(IUnidadeConstrutivaObraRepository repositoryUnidadeConstrutivaObra,
            ILogRepository logRepository, IUnidadeConstrutivaRepository repositoryUnidadeConstrutiva,
             IObraRepository repositoryObraRepository,
              IPavimentoRepository repositoryPavimento)
        {
            this._repositoryUnidadeConstrutivaObra = repositoryUnidadeConstrutivaObra;
            this._repositoryLog = logRepository;
            this._repositoryUnidadeConstrutiva = repositoryUnidadeConstrutiva;
            this._repositoryObraRepository = repositoryObraRepository;
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

            UnidadeConstrutivaObraModelView model = new UnidadeConstrutivaObraModelView();

            model.unidadeConstrutivaObras = _repositoryUnidadeConstrutivaObra.ListarTodos();
            model.unidadeConstrutivas = _repositoryUnidadeConstrutiva.ListarTodos();
            model.obras = _repositoryObraRepository.ListarTodos();

            var json = JsonConvert.SerializeObject(model);

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(UnidadeConstrutivaObraModelView model)
        {
            string resultado = null;
            model.unidadeConstrutivaObra.TbStatusGeralCodStatusGeral = 1;
            try
            {
                _repositoryUnidadeConstrutivaObra.Inserir(model.unidadeConstrutivaObra);
                _repositoryUnidadeConstrutivaObra.Salvar();


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
        public IActionResult Editar(UnidadeConstrutivaObraModelView model)
        {

            string resultado = null;

            try
            {
                model.unidadeConstrutivaObra.TbStatusGeralCodStatusGeral = 1;

                _repositoryUnidadeConstrutivaObra.Alterar(model.unidadeConstrutivaObra);
                _repositoryUnidadeConstrutivaObra.Salvar();


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
        public IActionResult Deletar(UnidadeConstrutivaObraModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryUnidadeConstrutivaObra.Excluir(model.unidadeConstrutivaObra.CodUcObra);
                _repositoryUnidadeConstrutivaObra.Salvar();


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