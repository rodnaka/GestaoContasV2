using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using GestaoContasV2.Models;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;

namespace GestaoContas.Controllers
{
    
    public class FaturaDetalheController : ApiController
    {        
        [HttpGet]
        public HttpResponseMessage selecionarFatura(int codigoFatura)
        {
            FaturaModel model = new FaturaModel();

            List<TBCCC_006_FATU> lstFatura = new List<TBCCC_006_FATU>();
            HttpResponseMessage result = null;

            TBCCC_006_FATU conta = model.find(null, 0, codigoFatura)[0];

            if (conta == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            else
            {
                //Request.Headers.Clear();
                //Request.Content.Headers.Clear();
                
                result = Request.CreateResponse(HttpStatusCode.OK);                
                result.Content = new ByteArrayContent(conta.IMG_BOLE_FATU);
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline");
                result.Content.Headers.ContentDisposition.FileName = "Boleto.pdf";
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            }

            return result;
        }

        
    }
}
