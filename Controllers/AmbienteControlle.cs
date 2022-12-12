using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bcquant.Domain.Interfaces;
using bcquant.Models;
using bcquant.ModelView;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace bcquant.Controllers
{
    public class AmbienteController : Controller
    {
        #region variaveis globais
        private IAmbienteRepository _repositoryAmbienteRepository;
        private IUnidadeConstrutivaObraRepository _repositoryUnidadeConstrutivaObra;
        private ILogRepository _repositoryLog;
        private IUnidadeConstrutivaRepository _repositoryUnidadeConstrutiva;
        private IObraRepository _repositoryObraRepository;
        private IPavimentoRepository _repositoryPavimento;
        private IAmbienteBasicoRepository _repositoryAmbienteBasico;
        

        #endregion

        #region construtor
        public AmbienteController(IAmbienteRepository repositoryAmbienteRepository,
            ILogRepository logRepository, IUnidadeConstrutivaRepository repositoryUnidadeConstrutiva,
            IObraRepository repositoryObraRepository,
            IPavimentoRepository repositoryPavimento,
            IUnidadeConstrutivaObraRepository repositoryUnidadeConstrutivaObra,
            IAmbienteBasicoRepository repositoryAmbienteBasico)
        {
            this._repositoryAmbienteRepository = repositoryAmbienteRepository;
            this._repositoryLog = logRepository;
            this._repositoryUnidadeConstrutiva = repositoryUnidadeConstrutiva;
            this._repositoryObraRepository = repositoryObraRepository;
            this._repositoryPavimento = repositoryPavimento;
            this._repositoryUnidadeConstrutivaObra = repositoryUnidadeConstrutivaObra;
            this._repositoryAmbienteBasico = repositoryAmbienteBasico;

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
            var json = "";

            try
            {

                AmbienteModelView model = new AmbienteModelView();

                model.ambientes = _repositoryAmbienteRepository.ListarTodos();
                model.obras = _repositoryObraRepository.ListarTodos();
                model.ambienteBasicos = _repositoryAmbienteBasico.ListarTodos();
                model.unidadeConstrutivaObras = _repositoryUnidadeConstrutivaObra.ListarTodos();
                model.pavimentos = _repositoryPavimento.ListarTodos();
                model.unidadeConstrutivas = _repositoryUnidadeConstrutiva.ListarTodos();

                json = JsonConvert.SerializeObject(model, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
            }
            catch (Exception e)
            {
                return Json(json);

            }

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(AmbienteModelView model)
        {
            string resultado = null;

            try
            {
                _repositoryAmbienteRepository.Inserir(model.ambiente);
                _repositoryAmbienteRepository.Salvar();
                var cod_ambiente= model.ambiente.CodAmbiente;


                resultado = "{\"bool\":\"true\",\"retorno\":"+ cod_ambiente + "}";

            }
            catch (Exception e)
            {
                resultado = "{\"bool\":\"false\",\"retorno\":\"Aconteceu algum problema, favor tentar novamente!!\"}";

            }

            return Json(resultado);

        }

        #endregion


        #region inserir posicoes ambiente
        [HttpPost]
        public IActionResult InserirPosicoesAmbiente([FromBody] List<TbPosicaoAmbiente> posicaoAmbientes)
        {
            string resultado = null;

            try
            {
                var context = new bcquant_localContext();

                posicaoAmbientes.ForEach(n => context.Add(n));

                context.SaveChanges();

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
        public IActionResult Editar(AmbienteModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryAmbienteRepository.Alterar(model.ambiente);
                _repositoryAmbienteRepository.Salvar();


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
        public IActionResult Deletar(AmbienteModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryAmbienteRepository.Excluir(model.ambiente.CodAmbiente);
                _repositoryAmbienteRepository.Salvar();


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