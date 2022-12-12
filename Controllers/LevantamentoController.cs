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
    public class LevantamentoController : Controller
    {
        #region variaveis globais
        private ILevantamentoRepository _repositoryLevantamentoRepository;
        private ITipoLevantamentoRepository _repositoryTipoLevantamentoRepository;
        private IObraRepository _repositoryObra;
        private IStatusLevantamentoRepository _repositoryStatusLevantamento;
        private IUnidadeConstrutivaObraRepository _repositoryUnidadeConstrutivaObraRepository;
        #endregion

        #region construtor
        public LevantamentoController(
                                ILevantamentoRepository repositoryLevantamentoRepository,
                                ITipoLevantamentoRepository repositoryTipoLevantamentoRepository,
                                IObraRepository repositoryObra,
                                IUnidadeConstrutivaObraRepository repositoryUnidadeConstrutivaObraRepository,
                                IStatusLevantamentoRepository repositoryStatusLevantamento
                                 )
        {
            this._repositoryLevantamentoRepository = repositoryLevantamentoRepository;
            this._repositoryTipoLevantamentoRepository = repositoryTipoLevantamentoRepository;
            this._repositoryObra = repositoryObra;
            this._repositoryUnidadeConstrutivaObraRepository = repositoryUnidadeConstrutivaObraRepository;
            this._repositoryStatusLevantamento = repositoryStatusLevantamento;
             
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

            LevantamentoModelView model = new LevantamentoModelView();

            model.levantamentos = _repositoryLevantamentoRepository.ListarTodos();
            model.tiposLevantamentos = _repositoryTipoLevantamentoRepository.ListarTodos();
            model.obras= _repositoryObra.ListarTodos();
            model.ucObras = _repositoryUnidadeConstrutivaObraRepository.ListarTodos();
            model.statusLevantamentos = _repositoryStatusLevantamento.ListarTodos();

            var json = JsonConvert.SerializeObject(model);

            return Json(json);
        }

        #endregion

        #region inserir
        [HttpPost]
        public IActionResult Inserir(LevantamentoModelView model)
        {

            string resultado = null;
            model.levantamento.TbStatusLevantamentoCodStatusLevantamento = 1;
            try
            {
                if (model.arquivoImg != null)//verifica se tem imagem salvar no disco
                {
                    string extensao = Path.GetExtension(model.arquivoImg.FileName);

                    string[] externoesPermitidas = { "jpg", "jpeg", "png" };

                    bool verificaExtensao = TratamentoDeArquivos.VerificaExtensao(externoesPermitidas, Path.GetExtension(model.arquivoImg.FileName));//chama o metodo pra veficar extensão

                    if (verificaExtensao != false)//se a extensão for valida ele insere no disco
                    {
                        var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "Documentos/Levantamento",
                            DateTime.Now.ToString("ddMMyyhhmmsstt") + "." + extensao);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            model.arquivoImg.CopyToAsync(stream);//salva o arquivo na psta com o novo nome
                        }

                        model.levantamento.UrlArquivoLevantamento = path;//coloca a url da imagem na propriedade 

                    }
                    else
                    {
                        resultado = "{\"bool\":\"false\",\"retorno\":\"Extensão do arquivo não é válido!\"}";

                        return Json(resultado);
                    }
                }

                _repositoryLevantamentoRepository.Inserir(model.levantamento);
                _repositoryLevantamentoRepository.Salvar();


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
        public IActionResult Editar(LevantamentoModelView model)
        {

            string resultado = null;
            model.levantamento.TbStatusLevantamentoCodStatusLevantamento = 1;

            try
            {
                _repositoryLevantamentoRepository.Alterar(model.levantamento);
                _repositoryLevantamentoRepository.Salvar();


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
        public IActionResult Deletar(LevantamentoModelView model)
        {

            string resultado = null;

            try
            {
                _repositoryLevantamentoRepository.Excluir(model.levantamento.CodLevantamento);
                _repositoryLevantamentoRepository.Salvar();


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