using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using bcquant.Domain.Interfaces;
using bcquant.ModelView;
using bcquant.Util.ObjetoAuxiliar;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace bcquant.Controllers
{
    public class InsumoController : Controller
    {
        #region variaveis globais
        private IInsumoRepository _repositoryIInsumoRepository;
        //private ILogRepository _repositoryLog;
        private IUnidadeDeMedidaRepository _repositoryIUnidadeDeMedida;
        private IPosicaoRepository _repositoryIPosicao;
        private IItensDeLevantamentoRepository _repositoryIItensDeLevantamentoRepository;
        private IMateriaPrimaRepository _repositoryIMateriaPrimaRepository;
        private ICorRepository _repositoryICorRepository;
        private IFabricanteRepository _repositoryIFabricanteRepository;

        #endregion

        #region construtor
        public InsumoController(
                                IInsumoRepository repositoryIInsumoRepository,
                                ILogRepository repositoryLog,
                                IUnidadeDeMedidaRepository repositoryIUnidadeDeMedida,
                                IPosicaoRepository repositoryIPosicao,
                                IItensDeLevantamentoRepository repositoryIItensDeLevantamentoRepository,
                                IMateriaPrimaRepository repositoryIMateriaPrimaRepository,
                                ICorRepository repositoryICorRepository,
                                IFabricanteRepository repositoryIFabricanteRepository
                                 )
        {
            this._repositoryIInsumoRepository = repositoryIInsumoRepository;
            this._repositoryIUnidadeDeMedida = repositoryIUnidadeDeMedida;
            this._repositoryIPosicao = repositoryIPosicao;
            this._repositoryIItensDeLevantamentoRepository = repositoryIItensDeLevantamentoRepository;
            this._repositoryICorRepository = repositoryICorRepository;
            this._repositoryIFabricanteRepository = repositoryIFabricanteRepository;
            this._repositoryIMateriaPrimaRepository = repositoryIMateriaPrimaRepository;

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

            InsumoModelView model = new InsumoModelView();

            model.insumos = _repositoryIInsumoRepository.ListarTodos();
            model.unidadeMedidas = _repositoryIUnidadeDeMedida.ListarTodos();
            model.posicoes = _repositoryIPosicao.ListarTodos();
            model.itensLevantamentos = _repositoryIItensDeLevantamentoRepository.ListarTodos();
            model.cores = _repositoryICorRepository.ListarTodos();
            model.fabricantes = _repositoryIFabricanteRepository.ListarTodos();
            model.materiaPrimas = _repositoryIMateriaPrimaRepository.ListarTodos();

            var json = JsonConvert.SerializeObject(model);

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(InsumoModelView model)
        {

            string resultado = null;

            try
            {
                model.insumo.TbStatusGeralCodStatusGeral = 1;
                if (model.arquivoImg != null)//verifica se tem imagem salvar no disco
                {
                    string extensao = Path.GetExtension(model.arquivoImg.FileName);

                    string[] externoesPermitidas = { "jpg", "jpeg", "png" };

                    bool verificaExtensao = TratamentoDeArquivos.VerificaExtensao(externoesPermitidas, Path.GetExtension(model.arquivoImg.FileName));//chama o metodo pra veficar extensão
                    
                    if (verificaExtensao != false)//se a extensão for valida ele insere no disco
                    {
                        var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot/images",
                            DateTime.Now.ToString("ddMMyyhhmmsstt") + "." + extensao);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            model.arquivoImg.CopyToAsync(stream);//salva o arquivo na psta com o novo nome
                        }

                    }
                    else
                    {
                        resultado = "{\"bool\":\"false\",\"retorno\":\"Extensão do arquivo não é válido!\"}";

                        return Json(resultado);
                    }
                }

                _repositoryIInsumoRepository.Inserir(model.insumo);
                _repositoryIInsumoRepository.Salvar();


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
        public IActionResult Editar(InsumoModelView model)
        {

            string resultado = null;

            try
            {
                model.insumo.TbStatusGeralCodStatusGeral = 1;

                _repositoryIInsumoRepository.Alterar(model.insumo);
                _repositoryIInsumoRepository.Salvar();


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
        public IActionResult Deletar(InsumoModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryIInsumoRepository.Excluir(model.insumo.CodInsumoBcQuant);
                _repositoryIInsumoRepository.Salvar();


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