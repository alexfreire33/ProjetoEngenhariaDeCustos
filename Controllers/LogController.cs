using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using bcquant.Domain.Interfaces;
using bcquant.ModelView;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace bcquant.Controllers
{
    public class LogController : Controller
    {
        #region variaveis globais
        private ILogRepository _repositoryLog;

        #endregion

        #region construtor
        public LogController(ILogRepository logRepository )
        {
            this._repositoryLog = logRepository;
        }
        #endregion

        #region inserir
        [HttpPost]
        public void Inserir(string dataForm)
        {
            try
            {

                string dono_repositorio = HttpUtility.ParseQueryString(dataForm).ToString();

                LogModelView model = new LogModelView();


                string remoteIpAddress = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.ToString();


                model.log.NomeDaPagina = HttpContext.Request.Path;
                model.log.IpLog = remoteIpAddress;
                model.log.IpLog = remoteIpAddress;

                _repositoryLog.Inserir(model.log);
                _repositoryLog.Salvar();


            }
            catch (Exception e)
            {

            }
        }

        #endregion

    }
}