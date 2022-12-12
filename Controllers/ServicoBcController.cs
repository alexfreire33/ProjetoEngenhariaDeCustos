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
    public class ServicoBcController : Controller
    {
        #region variaveis globais
        private IServicoBcRepositoryRepository _repositoryIServicoBc;
        private ILogRepository _repositoryLog;
        private IGrupoDeServicoRepository _repositoryIGrupoDeServico;
        private IUnidadeDeMedidaRepository _repositoryIUnidadeDeMedida;
        private IPosicaoRepository _repositoryIPosicao;

        #endregion

        #region construtor
        public ServicoBcController(IServicoBcRepositoryRepository repositoryTipologia, ILogRepository logRepository,
                                    IGrupoDeServicoRepository repositoryIGrupoDeServico,
                                    IUnidadeDeMedidaRepository repositoryIUnidadeDeMedida,
                                    IPosicaoRepository repositoryIPosicao
                                    )
        {
            this._repositoryIServicoBc = repositoryTipologia;
            this._repositoryLog = logRepository;
            this._repositoryIGrupoDeServico = repositoryIGrupoDeServico;
            this._repositoryIUnidadeDeMedida = repositoryIUnidadeDeMedida;
            this._repositoryIPosicao = repositoryIPosicao;
         
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

            ServicoBcModelView model = new ServicoBcModelView();

            model.servicoBcs = _repositoryIServicoBc.ListarTodos();
            model.grupoDeServicos = _repositoryIGrupoDeServico.ListarTodos();
            model.unidadeMedidas = _repositoryIUnidadeDeMedida.ListarTodos();
            model.posicoes = _repositoryIPosicao.ListarTodos();

            var json = JsonConvert.SerializeObject(model);

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(ServicoBcModelView model)
        {
            model.servicoBc.CodServicoBc = 0;//aqui é para caso se o valor da primary key vier preenchido ele zera antes de inserir
            model.servicoBc.TbStatusGeralCodStatusGeral = 1;
            string resultado = null;


            try
            {
                _repositoryIServicoBc.Inserir(model.servicoBc);
                _repositoryIServicoBc.Salvar();


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
        public IActionResult Editar(ServicoBcModelView model)
        {

            string resultado = null;

            try
            {
                model.servicoBc.TbStatusGeralCodStatusGeral = 1;

                _repositoryIServicoBc.Alterar(model.servicoBc);
                _repositoryIServicoBc.Salvar();


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
        public IActionResult Deletar(ServicoBcModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryIServicoBc.Excluir(model.servicoBc.CodServicoBc);
                _repositoryIServicoBc.Salvar();


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